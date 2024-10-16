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
                return Ok(resultado.Message);
            }
            else
            {
                return BadRequest(resultado.Errores);
            }
        }
        [HttpGet("ObtenerCompras")]
        public IActionResult ObtenerCompras() {
            List<CompraDTO> compras = compraService.ObtenerCompras();
            return Ok(compras);
        }
    }
}

