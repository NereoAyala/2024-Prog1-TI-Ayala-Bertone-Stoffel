using Microsoft.AspNetCore.Mvc;
using SistemaDTO;
using SistemaEntities;
using SistemaServices;

namespace SistemaWebApi.Controllers
{
    [ApiController]
    [Route("Viaje")]
    public class ViajeController : ControllerBase
    {
        private ViajeService service = new ViajeService();
        [HttpPost("AgregarViaje")]
        public IActionResult AgregarViaje([FromBody] ViajeDTO viajeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Si el ModelState es válido, entonces llamamos al servicio para realizar más validaciones
            ResultadoEntity resultado = service.AgregarViaje(viajeDTO);
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
    }
}
