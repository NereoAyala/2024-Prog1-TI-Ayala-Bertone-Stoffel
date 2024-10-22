using Microsoft.AspNetCore.Mvc;
using SistemaDTO;
using SistemaEntities;
using SistemaServices;

namespace SistemaWebApi.Controllers
{
    [ApiController]
    [Route("Producto")]
    public class ProductoController : Controller
    {
        ProductoService producto=new ProductoService();

        [HttpPost("AgregarProducto")]
        public IActionResult AgregarProducto([FromBody]ProductoDTO productoDTO) 
        {
            ResultadoEntity resultado = producto.AgregarProducto(productoDTO);
            if (resultado.Success==false)
            {
                return BadRequest(resultado.Errores);
            }
            else
            {
                return Ok(resultado.Message);
            }
        }
        [HttpPut("ActualizarStock/{id}")]
        public IActionResult ActualizarStock(int id,[FromBody]int stockNuevo) 
        {
            ResultadoEntity resultado = producto.ActualizarStockProducto(id,stockNuevo);
            if (resultado.Success==false)
            {
                return BadRequest(resultado.Errores);
            }
            else
            {
                return Ok(resultado.Message);
            }
        }

        //hacer un metodo para obtener todos los productos
        //[HttpGet("ObtenerProductos")]
        //public IActionResult ObtenerProductos()
        //{
        //    List<ProductoDTO> productos = producto.ObtenerListaProductos();
        //    return Ok(productos);
        //}

        //obtener producto segun el filtro
        [HttpGet("FiltrarProductos")]
        public IActionResult FiltrarProductos([FromQuery] int limite)
        {
            //hacer que se muestren los productos con stock menor o igual al limite
            List<ProductoDTO> productos = producto.FiltrarProductosPorStock(limite);
            return Ok(productos);

        }




    }
}
