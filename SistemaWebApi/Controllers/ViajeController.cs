using Microsoft.AspNetCore.Mvc;
using SistemaDTO;
using SistemaEntities;
using SistemaServices;

namespace SistemaWebApi.Controllers
{
    [ApiController]
    [Route("Viaje")]
    public class ViajeController : Controller
    {
        
        private ViajeService service=new ViajeService();
        [HttpPost("AgregarViaje")]
        public IActionResult AgregarViaje([FromBody] ViajeDTO viajeDTO)
        {
            ResultadoEntity resultado = service.AgregarViaje(viajeDTO);
            if (resultado.Success == false)
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
