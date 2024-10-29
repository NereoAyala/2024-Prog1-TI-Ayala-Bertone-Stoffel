using SistemaData;
using SistemaDTO;
using SistemaEntities;
using SistemaShareds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaServices
{
    public class ViajeService
    {   
        public ResultadoEntity AgregarViaje(ViajeDTO viaje)
        {
            ResultadoEntity resultado = new ResultadoEntity() { Success = false };
            //validacion de fechas de entrada
            if (viaje.FechaEntregaDesde == viaje.FechaEntregaHasta)
            {
                resultado.Errores.Add("La fecha de inicio y la fecha de finalización no pueden ser iguales.");
            }
            if (viaje.FechaEntregaDesde < DateTime.Now)
            {
                resultado.Errores.Add("La fecha de inicio no puede ser menor a la fecha actual.");
            }

            if ((viaje.FechaEntregaHasta - viaje.FechaEntregaDesde).TotalDays > 7)
            {
                resultado.Errores.Add("La fecha de finalización solo puede ser como máximo 7 días después de la fecha de inicio.");
            }
            // Si hay errores de validación en las fechas, se devuelve el resultado de una
            if (resultado.Errores.Any())
            {
                resultado.Message = "Error al cargar el viaje.";
                return resultado;
            }
            List<ViajeEntity> viajes = ViajeFiles.LeerViajesDesdeJson();
            //VERIFICO SOLAPAMIENTO DE LAS NUEVAS FECHAS CON OTROS VIAJES
            foreach (var item in viajes)
            {
                // Casos cubiertos:
                // 1. Inicio del nuevo viaje cae dentro del rango de un viaje existente.
                // 2. Fin del nuevo viaje cae dentro del rango de un viaje existente.
                // 3. El nuevo viaje abarca completamente el rango de un viaje existente.
                if ((viaje.FechaEntregaDesde >= item.FechaEntregaDesde && viaje.FechaEntregaDesde <= item.FechaEntregaHasta) ||
                     (viaje.FechaEntregaHasta >= item.FechaEntregaDesde && viaje.FechaEntregaHasta <= item.FechaEntregaHasta) ||
                     (viaje.FechaEntregaDesde <= item.FechaEntregaDesde && viaje.FechaEntregaHasta >= item.FechaEntregaHasta))
                {
                    resultado.Errores.Add("Ya hay un viaje asignado en estas fechas.");
                    return resultado;
                }
            }
            List<CompraEntity> compras = CompraFiles.LeerCompraDesdeJson();
            List<CamionetaEntity> camionetas = CamionetaFiles.LeerCamionetasDesdeJson().OrderBy(x => x.DistanciaMax).ThenBy(x => x.TamañoCarga).ToList(); //TOMO LAS CAMIONETAS Y LAS ORDENO PRIMERO POR DISTANCIA Y LUEGO POR CAPACIDAD DE CARGA 
            List<int> comprasYaAsignadas = new List<int>();//ESTA LISTA ES PARA IR VIENDO LAS COMPRAS YA ASIGANDAS ENTONCES EN LA SEGUNDA CAMIONETA YA NOS SE TIENEN EN CUENTA LAS COMPRAS QUE YA SE ASIGNARON A LA PRIMER CAMIONETA
            foreach (var camioneta in camionetas)
            {
                double cargaActual = 0;
                List<int> codigosComprasAsignadas = new List<int>();
                var comprasDisponibles = compras.Where(x => x.EstadoCompra == Enums.EstadoCompra.Open && !comprasYaAsignadas.Contains(x.IdCompra)).ToList();//FILTRO LAS COMPRAS POR OPEN Y POR LAS QUE NO ESTEN LA LISTA DE COMPRAS YA ASIGNADAS

                foreach (var compra in comprasDisponibles)
                {
                    double distancia = compra.ObtenerDistancia();
                    double capacidad = compra.TamañoCajaTotal * compra.CantidadComprado;

                    if (camioneta.DistanciaMax >= distancia && (camioneta.TamañoCarga - cargaActual) >= capacidad)
                    {
                        compra.EstadoCompra = Enums.EstadoCompra.ReadyToDispach;
                        cargaActual += capacidad;
                        codigosComprasAsignadas.Add(compra.IdCompra);
                        comprasYaAsignadas.Add(compra.IdCompra);
                        CompraFiles.EscribirCompra(compra);
                    }
                }
                if (codigosComprasAsignadas.Any())//Si HAY ALGUNA COMPRA ASIGNADA RECIEN AHI CREO EL VIAJE SINO SERIA AL PEDO CREAR EL VIAJE
                {
                    var viajeTemp = new ViajeEntity()
                    {
                        IdCamioneta = camioneta.IdCamioneta,
                        FechaEntregaDesde = viaje.FechaEntregaDesde,
                        FechaEntregaHasta = viaje.FechaEntregaHasta,
                        PorcentajeCarga = (int)((cargaActual / camioneta.TamañoCarga) * 100),
                        ListadoCodigosCompras = codigosComprasAsignadas
                    };
                    ViajeFiles.EscribirViaje(viajeTemp);
                }
            }
            foreach (var compra in compras.Where(x => x.EstadoCompra == Enums.EstadoCompra.Open))
            {
                compra.FechaEntrega = compra.FechaEntrega.AddDays(14);
            }
            resultado.Success = true;
            resultado.Message = "Viajes asignados correctamente.";
            return resultado;
        }
    }
}
