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
    public class ProductoService
    {
        public ResultadoEntity AgregarProducto(ProductoDTO producto)
        {
            ResultadoEntity resultado = new ResultadoEntity() {Success=false};
            producto.ValidarProducto(resultado);
            if (resultado.Errores.Count()>0)
            {
                return resultado;
            }
            List<ProductoEntity> productos = ProductoFiles.LeerProductosDesdeJson();

            var ProductoEntity=new ProductoEntity
            {
                Nombre=producto.Nombre,
                Marca=producto.Marca,
                AltoCaja=producto.AltoCaja,
                AnchoCaja = producto.AnchoCaja,
                ProfundidadCaja = producto.ProfundidadCaja,
                PrecioUnitario = producto.PrecioUnitario,
                StockDisponible = producto.StockDisponible,
                StockMinimo = producto.StockMinimo
            };
            productos.Add(ProductoEntity);
            ProductoFiles.EscribirProducto(ProductoEntity);
            resultado.Success = true;
            resultado.Message = "El Producto se cargo con Exito";
            return resultado;
        }
        public ResultadoEntity ActualizarStockProducto(int id,int stockNuevo) 
        {
            ResultadoEntity resultado = new ResultadoEntity() { Success = false };
            List<ProductoEntity> productos = ProductoFiles.LeerProductosDesdeJson();
            ProductoEntity producto = productos.FirstOrDefault(x=>x.IdProducto==id);
            if (producto==null)
            {
                resultado.Errores.Add("El Producto no se encontro,Ingrese otro ID");
                return resultado;
            }
            producto.StockDisponible+=stockNuevo;//el stockNuevo se suma al que ya teniamos!!
            ProductoFiles.EscribirProducto(producto);
            resultado.Success=true;
            resultado.Message = "El Stock se Actualizo con Exito";
            return resultado;
        }
    }
}
