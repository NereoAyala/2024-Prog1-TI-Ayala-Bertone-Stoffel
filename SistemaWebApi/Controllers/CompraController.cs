using Microsoft.AspNetCore.Mvc;
using SistemaDTO;
using SistemaEntities;
using SistemaServices;

namespace SistemaWebApi.Controllers
{
    public class CompraController : Controller
    {
        private CompraService compraService = new CompraService();
        private ResultadoEntity resultado = new ResultadoEntity();
        public CompraController()
        {
            compraService = new CompraService();
            resultado = new ResultadoEntity();
        }
        [HttpPost("AgregarCompra")]
        public IActionResult AgregarCompra([FromBody] CompraDTO compraDto)
        {
            resultado = compraService.CrearCompra(compraDto);
            if (resultado.Success==true)
            {
                var respuesta = new { mensaje = resultado.Message };
                return Json(respuesta);
            }
            else
            {
                var respuesta = new { mensaje = resultado.Errores };
                return Json(respuesta);
            }
        }
        [HttpGet("ObtenerCompras")]
        public IActionResult ObtenerCompras() {
            List<CompraDTO> compras = compraService.ObtenerCompras();
            return Ok(compras);
        }
    }
}

