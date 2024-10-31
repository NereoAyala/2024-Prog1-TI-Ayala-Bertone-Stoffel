using Microsoft.AspNetCore.Mvc;
using SistemaDTO;
using SistemaEntities;
using SistemaServices;

namespace SistemaWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class ProductoController : ControllerBase
    {
        ProductoService producto=new ProductoService();

        [HttpPost]
        public IActionResult AgregarProducto([FromBody]ProductoDTO productoDTO) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            producto.AgregarProducto(productoDTO);
            return Ok(new { message = "Producto agregado con éxito", producto = productoDTO });
        }
        [HttpPut("{id}")]
        public IActionResult ActualizarStock(int id,[FromBody]int stockNuevo) 
        {
            var Producto = producto.ActualizarStockProducto(id, stockNuevo);
            if (Producto == null)
            {
                // return NotFound(new { message = "Producto no encontrado", producto = Producto });
                return NotFound(new {success = false, Producto });
            }
            //return Ok(new { message = "Producto actualizado con exito", productoActualizado = Producto });
            return Ok(new {success = true, Producto });
        }
        [HttpGet()]
        public IActionResult FiltrarProductos([FromQuery] int limite)
        {
            List<ProductoDTO> productos = producto.FiltrarProductosPorStock(limite);
            return Ok(productos);
        }
    }
}
