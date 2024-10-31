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
        public void AgregarViaje(ViajeDTO viaje)
        {
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
                        ListadoCodigosCompras = codigosComprasAsignadas,
                        FechaCreacion=DateTime.Now,                       
                    };
                    ViajeFiles.EscribirViaje(viajeTemp);
                }
            }
            foreach (var compra in compras.Where(x => x.EstadoCompra == Enums.EstadoCompra.Open))
            {
                compra.FechaEntrega = compra.FechaEntrega.AddDays(14);
            }  
        }
    }
}
