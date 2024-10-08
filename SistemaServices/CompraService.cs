using SistemaData;
using SistemaDTO;
using SistemaEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaServices
{
    public class CompraService
    {
        public ResultadoEntity CrearCompra(int idCliente, int codProducto, int cantComprada, DateTime fechaEntrega)
        {
            ResultadoEntity resultado = new ResultadoEntity { Success = false };
            List<ProductoEntity> productos = ProductoFiles.LeerProductosDesdeJson();
            ProductoEntity producto = productos.Find(x=>x.IdProducto == codProducto);
            if (producto == null)
            {
                resultado.Message = "No se encontro el producto.";
                return resultado;
            }
            if (producto.StockDisponible <= 0)
            {
                resultado.Message = "No hay stock disponible.";
                return resultado;
            }
            var monto = producto.StockDisponible*producto.PrecioUnitario;
            monto = monto + (monto * 0.21);
            if (producto.StockDisponible > 4)
            {
                monto = monto - (monto * 0.25);
            }
            CompraEntity compra = new CompraEntity
            {
                CodProducto = producto.IdProducto,
                DniCliente = idCliente,
                FechaCompra = DateTime.Now,
                CantidadComprado = cantComprada,
                FechaEntrega = fechaEntrega,
                EstadoCompra = Enums.EstadoCompra.Open,
                MontoCompra = monto
            };
            //FALTA CALCULAR LA UBICACION (PUNTO DESTINO).
            resultado.Success = true;
            resultado.Message = "Compra cargada con exito";
            return resultado;
        }
    }
}
