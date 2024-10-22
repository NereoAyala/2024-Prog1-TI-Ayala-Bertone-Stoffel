using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SistemaDTO;
using SistemaEntities;
using SistemaServices;

namespace SistemaWebApi.Controllers
{
    [ApiController]
    [Route("Cliente")]
    public class ClienteController : Controller
    {
        ClienteService clienteService = new ClienteService();

        [HttpPost("AgregarCliente")]
        public IActionResult AgregarCliente([FromBody] ClienteDTO clienteDTO)
        {
            ResultadoEntity resultado = clienteService.AgregarCliente(clienteDTO);
            if (resultado.Success == false)
            {
                var respuesta = new { mensaje = resultado.Errores };
                return Json(respuesta);
            }
            else
            {
                var respuesta = new { mensaje = resultado.Message };
                return Json(respuesta);
            }
        }
        [HttpDelete("EliminarCliente{id}")]
        public IActionResult EliminarCliente(int id) 
        {
            ResultadoEntity resultado = clienteService.EliminarCliente(id);
            if (resultado.Success==false)
            {
                var respuesta = new { mensaje = resultado.Errores };
                return Json(respuesta);
            }
            else
            {
                var respuesta = new { mensaje = resultado.Message };
                return Json(respuesta);
            }
        }
        [HttpPut("ActualizarCliente{id}")]
        public IActionResult ActualizarCliente(int id,[FromBody]ClienteDTO cliente) 
        {
            ResultadoEntity resultado = clienteService.ActualizarCliente(id,cliente);
            if (resultado.Success==false)
            {
                var respuesta = new { mensaje = resultado.Errores };
                return Json(respuesta);
            }
            else
            {
                var respuesta = new { mensaje = resultado.Message };
                return Json(respuesta);
            }
        }
        [HttpGet("ObtenerClientes")]
        public IActionResult ObtenerClientes() 
        {
            List<ClienteDTO>clientes=clienteService.ObtenerListaClientes();
            return Ok(clientes);
        }
    }
}
