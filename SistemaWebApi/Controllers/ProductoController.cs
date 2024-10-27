using Microsoft.AspNetCore.Mvc;
using SistemaDTO;
using SistemaEntities;
using SistemaServices;

namespace SistemaWebApi.Controllers
{
    [ApiController]
    [Route("Producto")]
    public class ProductoController : ControllerBase
    {
        ProductoService producto=new ProductoService();

        [HttpPost("AgregarProducto")]
        public IActionResult AgregarProducto([FromBody]ProductoDTO productoDTO) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            producto.AgregarProducto(productoDTO);
            return Ok("Producto agregado con éxito.");
        }
        [HttpPut("ActualizarStock/{id}")]
        public IActionResult ActualizarStock(int id,[FromBody]int stockNuevo) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Producto = producto.ActualizarStockProducto(id, stockNuevo);
            if (Producto == null)
            {
                return NotFound("Producto no encontrado.");
            }

            return Ok("Producto actualizado con éxito.");
        }
        [HttpGet("FiltrarProductos")]
        public IActionResult FiltrarProductos([FromQuery] int limite)
        {
            //hacer que se muestren los productos con stock menor o igual al limite
            List<ProductoDTO> productos = producto.FiltrarProductosPorStock(limite);
            return Ok(productos);

        }
    }
}
