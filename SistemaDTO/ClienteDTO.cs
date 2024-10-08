using SistemaEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDTO
{
    public class ClienteDTO
    {
        public int DniCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Latitud { get; set; }
        public int Longitud { get; set; }

        public void Validar(ResultadoEntity resultado)
        {
            if (DniCliente == 0)
            {
                resultado.Errores.Add("El Dni del Cliente no es Valido");
            }
            if (string.IsNullOrEmpty(Nombre))
            {
                resultado.Errores.Add("El Nombre del Cliente No es Valido");
            }
            if (string.IsNullOrEmpty(Apellido))
            {
                resultado.Errores.Add("El Apellido del Cliente No es Valido");
            }
            if (string.IsNullOrEmpty(Email))
            {
                resultado.Errores.Add("El Email del Cliente No es Valido");
            }
            if (Telefono <= 0)
            {
                resultado.Errores.Add("El Telefono del Cliente No es Valido");
            }
            if (FechaNacimiento > DateTime.Now)
            {
                resultado.Errores.Add("La Fecha de Nacimiento no Puede ser Futura");
            }
        }
    }
}
