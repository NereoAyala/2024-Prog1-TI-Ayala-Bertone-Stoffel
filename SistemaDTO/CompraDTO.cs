using SistemaEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDTO
{
    public class CompraDTO
    {
        public int CodProducto { get; set; }
        public int DniCliente { get; set; }
        public int CantidadComprado { get; set; }
        public DateTime FechaEntrega { get; set; }
        public void Validacion(ResultadoEntity resultado) {
            if (CodProducto <= 0) {

                resultado.Errores.Add("Codigo de producto no valido.");
            }
            if (DniCliente <= 0)
            {
                resultado.Errores.Add("El dni del cliente no es valido.");
            }
            if (CantidadComprado <= 0)
            {
                resultado.Errores.Add("La cantidad ingresada no es valida.");
            }
            if (FechaEntrega <= DateTime.Now)
            {
                resultado.Errores.Add("La fecha de entrega no es valida.");
            }
        }
    }
}
