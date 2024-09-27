using EntitiesSistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesDTO
{
    public class ClienteDTO
    {
        public int DniCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public void Validar(ResultadoEntity resultado) 
        {
            if (DniCliente==0)
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
            if (Telefono<=0)
            {
                resultado.Errores.Add("El Telefono del Cliente No es Valido");
            }
            //VALIDAR FECHA NACIMIENTO
        }
    }
}
