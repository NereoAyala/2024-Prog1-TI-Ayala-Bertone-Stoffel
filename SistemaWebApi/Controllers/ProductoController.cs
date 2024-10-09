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

        [HttpPost]
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
        [HttpPut]
        public IActionResult ActualizarStock(int id,int stockNuevo) 
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
    }
}
