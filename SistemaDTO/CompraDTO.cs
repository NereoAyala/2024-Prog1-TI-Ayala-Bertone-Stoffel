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
        public DateTime FechaCompra { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Enums.EstadoCompra EstadoCompra { get; set; }
        public int MontoCompra { get; set; }
        public int PuntoDestino { get; set; }
    }
}
