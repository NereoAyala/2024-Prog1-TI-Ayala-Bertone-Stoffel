using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SistemaDTO;
using SistemaEntities;
using SistemaServices;

namespace SistemaWebApi.Controllers
{
    [ApiController]
    [Route("Cliente")]
    public class ClienteController : ControllerBase
    {
        ClienteService clienteService = new ClienteService();

        [HttpPost("AgregarCliente")]
        public IActionResult AgregarCliente([FromBody] ClienteDTO clienteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            clienteService.AgregarCliente(clienteDTO);
            return Ok("Cliente agregado con éxito.");
        }
        [HttpDelete("EliminarCliente/{id}")]
        public IActionResult EliminarCliente(int id)
        {
            var cliente = clienteService.EliminarCliente(id);
            if (cliente == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            return Ok("Cliente eliminado con éxito.");
        }
        [HttpPut("ActualizarCliente/{id}")]
        public IActionResult ActualizarCliente(int id, [FromBody] ClienteDTO cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Cliente = clienteService.ActualizarCliente(id, cliente);
            if (Cliente == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            return Ok("Cliente actualizado con éxito.");
        }
        [HttpGet("ObtenerClientes")]
        public IActionResult ObtenerClientes()
        {
            List<ClienteDTO> clientes = clienteService.ObtenerListaClientes();
            return Ok(clientes);
        }
    }
}
