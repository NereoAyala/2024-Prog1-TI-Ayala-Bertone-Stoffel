using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntities
{
    public class CompraEntity : FechaBase
    {
        public int IdCompra { get; set; }
        public int CodProducto { get; set; }
        public int DniCliente { get; set; }
        public int CantidadComprado { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Enums.EstadoCompra EstadoCompra { get; set; }
        public double MontoCompra { get; set; }
        public Localizacion PuntoDestino { get; set; }
    }
}
