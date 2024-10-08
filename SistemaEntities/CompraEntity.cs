using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntities
{
    public class CompraEntity
    {
        public int IdCompra { get; set; }
        public int CodProducto { get; set; }
        public int DniCliente { get; set; }
        public int CantidadComprado { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Enums.EstadoCompra EstadoCompra { get; set; }
        public double MontoCompra { get; set; }
        public double PuntoDestino { get; set; }

    }
}
