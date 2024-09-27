using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesSistema
{
    public class ClienteEntity
    {
        public int IdCliente { get; set; }
        public int DniCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public int Latitud { get; set; }
        public int Longitud { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime? FechaEliminacion { get; set; }
    }
}
