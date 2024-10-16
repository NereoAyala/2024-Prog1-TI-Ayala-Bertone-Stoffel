using SistemaData;
using SistemaDTO;
using SistemaEntities;
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
            ResultadoEntity resultado = new ResultadoEntity() {Success=false};
            viaje.Validar(resultado);
            if (resultado.Errores.Count()>0)
            {
                resultado.Message = "Error al cargar el viaje";
                return resultado;
            }
            List<ViajeEntity> viajes = ViajeFiles.LeerViajesDesdeJson();
            foreach (var item in viajes)
            {
                if ((viaje.FechaEntregaDesde<=item.FechaEntregaDesde&&viaje.FechaEntregaHasta>=item.FechaEntregaHasta)
                                                                    ||
                    (viaje.FechaEntregaDesde>=item.FechaEntregaDesde&&viaje.FechaEntregaHasta<=item.FechaEntregaHasta))
                {
                    resultado.Errores.Add("Ya hay un viaje asigando en estas fechas");
                    return resultado;
                }
            }
            List<CompraEntity> compras = CompraFiles.LeerCompraDesdeJson();
            List<CamionetaEntity> camionetas = CamionetaFiles.LeerCamionetasDesdeJson();
            var comprasfiltradas = compras.Where(x=>x.EstadoCompra==Enums.EstadoCompra.Open).ToList();//filtro las compras para tener solo las que estan en estado OPEN
            foreach (var camio in camionetas)
            {
                foreach (var compra in comprasfiltradas)
                {
                    var distancia = compra.ObtenerDistancia();
                    double capacidad = compra.TamañoCajaTotal * compra.CantidadComprado;
                    if (camio.DistanciaMax < distancia || camio.TamañoCarga > capacidad) {

                        ViajeEntity viajeTemp = new ViajeEntity()
                        {
                            FechaCreacion = DateTime.Now,
                            FechaEntregaDesde = viaje.FechaEntregaDesde,
                            FechaEntregaHasta = viaje.FechaEntregaHasta,
                        };
                        camio.TamañoCarga -= capacidad;
                    }
                }
            }
        }
    }
}
