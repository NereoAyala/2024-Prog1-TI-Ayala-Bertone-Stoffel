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
            ResultadoEntity resultado = service.AgregarViaje(viajeDTO);
            if (!resultado.Success)
            {
                // Añadir errores al ModelState si hay errores en ResultadoEntity
                foreach (var error in resultado.Errores)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
                return BadRequest(ModelState);
            }
            else
            {
                var respuesta = new { mensaje = resultado.Message };
                return Ok(respuesta);
            }
        }
    }
}
