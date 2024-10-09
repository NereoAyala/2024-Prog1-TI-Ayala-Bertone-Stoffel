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
        ClienteService clienteService=new ClienteService();

        [HttpPost]
        public IActionResult AgregarCliente([FromBody]ClienteDTO clienteDTO) 
        {
            ResultadoEntity resultado = clienteService.AgregarCliente(clienteDTO);
            if (resultado.Success==false)
            {
                return BadRequest(resultado.Errores);
            }
            else
            {
                return Ok(resultado.Message);
            }
        }
        [HttpDelete ]
        public IActionResult EliminarCliente(int id) 
        {
            ResultadoEntity resultado = clienteService.EliminarCliente(id);
            if (resultado.Success==false)
            {
                return BadRequest(resultado.Errores);
            }
            else
            {
                return Ok(resultado.Message);
            }
        }
        [HttpPut]
        public IActionResult ActualizarCliente(int id,[FromBody]ClienteDTO cliente) 
        {
            ResultadoEntity resultado = clienteService.ActualizarCliente(id,cliente);
            if (resultado.Success==false)
            {
                return BadRequest(resultado.Errores);
            }
            else
            {
                return Ok(resultado.Message);
            }
        }
        [HttpGet]
        public IActionResult ObtenerClientes() 
        {
            List<ClienteDTO>clientes=clienteService.ObtenerListaClientes();
            return Ok(clientes);
        }
    }
}
