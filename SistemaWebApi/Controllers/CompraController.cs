using Microsoft.AspNetCore.Mvc;
using SistemaDTO;
using SistemaEntities;
using SistemaServices;

namespace SistemaWebApi.Controllers
{
    public class CompraController : ControllerBase
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
            var resultado = compraService.CrearCompra(compraDto);

            if (resultado.Success)
            {
                // Respuesta en caso de éxito
                var respuesta = new { mensaje = resultado.Message };
                return Ok(respuesta);
            }
            else
            {
                // Añadir errores al ModelState
                foreach (var error in resultado.Errores)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                // Devolver respuesta de error estructurada
                return BadRequest(ModelState);
            }
        }
        [HttpGet("ObtenerCompras")]
        public IActionResult ObtenerCompras() {
            List<CompraDTO> compras = compraService.ObtenerCompras();
            return Ok(compras);
        }
    }
}

