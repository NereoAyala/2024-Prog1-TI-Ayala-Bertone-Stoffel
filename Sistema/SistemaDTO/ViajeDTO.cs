using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesDTO
{
    internal class ViajeDTO
    {
        public int IdCamioneta { get; set; }
        public DateTime FechaEntregaDesde { get; set; }
        public DateTime FechaEntregaHasta{get; set;}
    }
}