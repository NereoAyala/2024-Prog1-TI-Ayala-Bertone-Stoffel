using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SistemaData;
using SistemaDTO;
using SistemaEntities;
using SistemaServices;

namespace SistemaWebApi.Controllers
{

    [ApiController]
    [Route("[controller]")] //esto lo tuve que cambiar si o si
    public class ClienteController : ControllerBase
    {
        ClienteService clienteService = new ClienteService();

        [HttpPost]
        public IActionResult AgregarCliente([FromBody] ClienteDTO clienteDTO)
        {
            //Asi lo haria yo, lo probe y funciona
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //var clientes = ClienteFiles.LeerClientesDesdeJson();
            //if (clientes.Any(c => c.DniCliente == clienteDTO.DniCliente))
            //{
            //    return BadRequest(new { message = "El cliente ya existe.", cliente = clienteDTO });
            //}
            //clienteService.AgregarCliente(clienteDTO);
            //return Ok(new { message = "Cliente agregado con éxito", cliente = clienteDTO });

            if (clienteDTO.DniCliente <= 0)
            {
                ModelState.AddModelError("DniCliente", "El DNI debe ser un número positivo.");
                return BadRequest(ModelState);
            }//esto ya lo validas en el DTO
            var clientes = ClienteFiles.LeerClientesDesdeJson();
            if (clientes.Any(c => c.DniCliente == clienteDTO.DniCliente))
            {
                ModelState.AddModelError("DniCliente", "El cliente ya existe.");
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            clienteService.AgregarCliente(clienteDTO);
            return Ok("Cliente agregado con éxito.");
        }
        [HttpDelete("{id}")]
        public IActionResult EliminarCliente(int id)
        {
            //el "problema" con esto es que devolves solo un mensaje y no esta del todo bien, tendria que devolver el cliente eliminado y el mensaje
           
            // var cliente = clienteService.EliminarCliente(id);
           // if (cliente == null)
           // {
           //     return NotFound("Cliente no encontrado.");
           // }

           //return Ok("Cliente eliminado con éxito.");
            // return Ok(cliente);

            var cliente = clienteService.EliminarCliente(id);
            if (cliente == null)
            {
                return NotFound(new { message = "Cliente no encontrado", clienteEliminado = cliente });
            }
            return Ok(new { message = "Cliente eliminado con éxito", clienteEliminado = cliente });
        }
        [HttpPut("{id}")]
        public IActionResult ActualizarCliente(int id, [FromBody] ClienteDTO cliente)
        {
            //en este el problema es el mismo que en el anterior, tendrias que devolver el cliente actualizado y el mensaje
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //var Cliente = clienteService.ActualizarCliente(id, cliente);
            //if (Cliente == null)
            //{
            //    return NotFound("Cliente no encontrado.");
            //}

            //return Ok("Cliente actualizado con éxito.");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Cliente = clienteService.ActualizarCliente(id, cliente);
            if (Cliente == null)
            {
                return NotFound(new { message = "Cliente no encontrado", clienteActualizado = Cliente });
            }
            return Ok(new { message = "Cliente actualizado con éxito", clienteActualizado = Cliente });
        }
        [HttpGet]
        public IActionResult ObtenerClientes()
        {
            List<ClienteDTO> clientes = clienteService.ObtenerListaClientes();
            return Ok(clientes);
        }
    }
}
