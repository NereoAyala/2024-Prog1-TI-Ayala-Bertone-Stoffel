using SistemaEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDTO
{
    public class ViajeDTO
    {
    
        public DateTime FechaEntregaDesde { get; set; }
        public DateTime FechaEntregaHasta { get; set; }
        public void Validar(ResultadoEntity resultado)
        {
            if (FechaEntregaDesde < DateTime.Now)
            {
                resultado.Errores.Add("La fecha no puede ser menor a la actual");
            }
            if (FechaEntregaHasta == FechaEntregaDesde.AddDays(7))
            {
                resultado.Errores.Add("La fecha tiene que ser 7 dias mayor a la fecha desde");
            }
        }
    }
}
