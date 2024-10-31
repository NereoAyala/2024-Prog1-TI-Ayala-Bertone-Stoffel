using Microsoft.AspNetCore.Mvc;
using SistemaDTO;
using SistemaEntities;
using SistemaServices;

namespace SistemaWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")] //esto lo tuve que cambiar si o si
    public class ProductoController : ControllerBase
    {
        ProductoService producto=new ProductoService();

        [HttpPost]
        public IActionResult AgregarProducto([FromBody]ProductoDTO productoDTO) 
        {

            //if (string.IsNullOrEmpty(productoDTO.Nombre))
            //{
            //    ModelState.AddModelError("NombreProducto", "El Nombre del Producto es Obligatorio.");
            //    return BadRequest(ModelState);
            //}
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
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(new { message = "Error en los datos ingresados", ModelState });
            //}

            var Producto = producto.ActualizarStockProducto(id, stockNuevo);
            if (Producto == null)
            {
                // return NotFound("Producto no encontrado.");
                return NotFound(new { message = "Producto no encontrado", producto = Producto });
            }
            return Ok(new { message = "Producto actualizado con exito", productoActualizado = Producto });
            //return Ok("Producto actualizado con éxito.");
        }
        [HttpGet()]
        public IActionResult FiltrarProductos([FromQuery] int limite)
        {
            //hacer que se muestren los productos con stock menor o igual al limite
            List<ProductoDTO> productos = producto.FiltrarProductosPorStock(limite);
            return Ok(productos);

        }
    }
}
