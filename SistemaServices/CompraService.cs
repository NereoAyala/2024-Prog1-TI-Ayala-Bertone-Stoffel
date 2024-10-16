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
            List<ClienteEntity> clientes = ClienteFiles.LeerClientesDesdeJson();
            ClienteEntity cliente = clientes.Find(x => x.IdCliente == idCliente);
            if (cliente == null) {
                resultado.Errores.Add("El id del cliente no fue encontrado.");
            }
            if (producto == null)
            {
                resultado.Errores.Add("No se encontro el producto.");
                return resultado;
            }
            if (producto.StockDisponible <= 0)
            {
                resultado.Errores.Add("No hay stock disponible.");
                return resultado;
            }
            var monto = producto.StockDisponible*producto.PrecioUnitario;
            monto = monto + (monto * 0.21);
            if (producto.StockDisponible > 4)
            {
                monto = monto - (monto * 0.25);
            }    
            List<CompraEntity> compras = CompraFiles.LeerCompraDesdeJson();
            CompraEntity compra = new CompraEntity
            {
                CodProducto = producto.IdProducto,
                DniCliente = idCliente,
                CantidadComprado = cantComprada,
                FechaEntrega = fechaEntrega,
                EstadoCompra = Enums.EstadoCompra.Open,
                MontoCompra = monto,
                FechaCreacion=DateTime.Now,
                PuntoDestino = new Localizacion()
                {
                    LatitudCliente = cliente.Latitud,
                    LongitudCliente = cliente.Longitud
                }
            };
            compras.Add(compra);
            CompraFiles.EscribirCompra(compra);
            resultado.Success = true;
            resultado.Message = "Compra cargada con exito";
            return resultado;          
        }
        public int VolumenTotal(int codProducto, int cantidad) 
        {
            List<ProductoEntity> productos = ProductoFiles.LeerProductosDesdeJson();
            ProductoEntity producto = productos.FirstOrDefault(x=>x.IdProducto==codProducto);
            if (producto==null)
            {
                return 0;
            }
            int volumenparcial = producto.CalcularVolumenUnidad();
            int volumenTotal = volumenparcial * cantidad;
            return volumenTotal;
        }
    }
}
