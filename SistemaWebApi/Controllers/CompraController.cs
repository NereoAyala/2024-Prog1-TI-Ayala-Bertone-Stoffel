using Microsoft.AspNetCore.Mvc;
using SistemaDTO;
using SistemaEntities;
using SistemaServices;

namespace SistemaWebApi.Controllers
{
    [ApiController]
    [Route("api/Compras")]
    public class CompraController : ControllerBase
    {
        private CompraService compraService = new CompraService();
        private ResultadoEntity resultado = new ResultadoEntity();
        public CompraController()
        {
            compraService = new CompraService();
            resultado = new ResultadoEntity();
        }
        [HttpPost]
        public IActionResult AgregarCompra([FromBody] CompraDTO compraDto)
        {
            var resultado = compraService.CrearCompra(compraDto);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Si el ModelState es válido, entonces llamamos al servicio para realizar más validaciones
           
            if (!resultado.Success)
            {
                // Añadir los errores del servicio al ModelState
                foreach (var error in resultado.Errores)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
                // Retornar todos los errores (del ModelState original y los errores de resultado)
                return BadRequest(ModelState);
            }
            var respuesta = new { mensaje = resultado.Message };
            return Ok(respuesta);

        }
        [HttpGet]
        public IActionResult ObtenerCompras() {
            List<CompraDTO> compras = compraService.ObtenerCompras();
            return Ok(compras);
        }
    }
}

