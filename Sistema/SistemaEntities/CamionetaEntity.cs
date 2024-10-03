using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesSistema
{
    public class CamionetaEntity
    {
        public int IdCamioneta { get; set; }
        public string Patente { get; set; }
        public int TamañoCarga { get; set; }
        public int DistanciaMax { get; set; }
    }
}
