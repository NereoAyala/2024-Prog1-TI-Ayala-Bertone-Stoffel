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
            foreach (var item in camionetas)
            {
                
            }
        }
    }
}
