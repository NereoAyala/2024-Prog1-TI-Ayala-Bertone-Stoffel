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
        public ResultadoEntity CrearCompra(CompraDTO compraDto)
        {
            ResultadoEntity resultado = new ResultadoEntity { Success = false };
            compraDto.Validacion(resultado);
            if (resultado.Errores.Count > 0) {
                resultado.Errores.Add("La compra no es valida.");
            }
            List<ProductoEntity> productos = ProductoFiles.LeerProductosDesdeJson();
            var producto = productos.Find(x => x.IdProducto == compraDto.CodProducto);
            if (producto == null) {
                resultado.Errores.Add("Producto no encontrado");
            }
            else
            {
                if ((producto.StockDisponible - compraDto.CantidadComprado) < 0)
                {
                    resultado.Errores.Add("No se puede realizar la compra no hay stock");                    
                }
            }
            List<ClienteEntity> clientes = ClienteFiles.LeerClientesDesdeJson();
            var cliente = clientes.Find(x => x.DniCliente == compraDto.DniCliente);
            if (cliente == null)
            {
                resultado.Errores.Add("Cliente no encontrado");              
            }
            if (resultado.Errores.Count == 0) {
                var monto = producto.PrecioUnitario * compraDto.CantidadComprado;
                monto = monto + (monto * 0.21);
                if (producto.StockDisponible > 4)
                {
                    monto = monto - (monto * 0.25);
                }
                producto.StockDisponible -= compraDto.CantidadComprado;
                ProductoFiles.EscribirProducto(producto);
                List<CompraEntity> compras = CompraFiles.LeerCompraDesdeJson();
                CompraEntity compra = new CompraEntity
                {
                    CodProducto = producto.IdProducto,
                    DniCliente = compraDto.DniCliente,
                    CantidadComprado = compraDto.CantidadComprado,
                    FechaEntrega = compraDto.FechaEntrega,
                    EstadoCompra = Enums.EstadoCompra.Open,
                    MontoCompra = monto,
                    FechaCreacion = DateTime.Now,
                    TamañoCajaTotal = producto.CalcularVolumenUnidad() * compraDto.CantidadComprado,
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
            }
            return resultado;
        }
        public List<CompraDTO> ObtenerCompras()
        {
            List<CompraEntity> compras = CompraFiles.LeerCompraDesdeJson();
            List<CompraDTO> compraDTOs = new List<CompraDTO>();
            foreach (CompraEntity compra in compras)
            {
                CompraDTO compraDto = new CompraDTO()
                {
                    CantidadComprado = compra.CantidadComprado,
                    DniCliente = compra.DniCliente,
                    CodProducto = compra.CodProducto,
                    FechaEntrega = compra.FechaEntrega,
                };
                compraDTOs.Add(compraDto);
            }
            return compraDTOs;
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
