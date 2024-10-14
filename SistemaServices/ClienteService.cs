using SistemaData;
using SistemaDTO;
using SistemaEntities;

namespace SistemaServices
{
    public class ClienteService
    {
        public ResultadoEntity AgregarCliente(ClienteDTO cliente)
        {
            ResultadoEntity resultado = new ResultadoEntity() { Success = false };
            cliente.Validar(resultado);
            if (resultado.Errores.Count() > 0)
            {
                return resultado;
            }
            List<ClienteEntity> clientes = ClienteFiles.LeerClientesDesdeJson();

            var clienteNuevo = new ClienteEntity
            {
                DniCliente = cliente.DniCliente,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email,
                FechaNacimiento = cliente.FechaNacimiento, // Usar solo la parte de la fecha DATE
                Telefono = cliente.Telefono,
                FechaCreacion = DateTime.Now,
            };
            clientes.Add(clienteNuevo);
            ClienteFiles.EscribirClienteaJson(clienteNuevo);
            resultado.Success = true;
            resultado.Message = "El Cliente se Cargo Con Exito";
            return resultado;
        }

        public ResultadoEntity EliminarCliente(int id)
        {
            ResultadoEntity resultado = new ResultadoEntity() { Success = false };
            List<ClienteEntity> clientes = ClienteFiles.LeerClientesDesdeJson();
            ClienteEntity cliente = clientes.Find(x => x.IdCliente == id);
            if (cliente == null)
            {
                resultado.Errores.Add("El Cliente No se encontro, vuelva a ingresar el Id");
                return resultado;
            }
            cliente.FechaEliminacion = DateTime.Now;
            ClienteFiles.EscribirClienteaJson(cliente);
            resultado.Success = true;
            resultado.Message = "El Cliente se Elimino con Exito";
            return resultado;
        }

        public ResultadoEntity ActualizarCliente(int id, ClienteDTO clienteDTO)
        {
            ResultadoEntity resultado = new ResultadoEntity() { Success = false };
            List<ClienteEntity> clientes = ClienteFiles.LeerClientesDesdeJson();

            ClienteEntity cliente = clientes.Find(x => x.IdCliente == id);
            if (cliente == null)
            {
                resultado.Errores.Add("El Cliente No se encontro, vuelva a ingresar el Id");
                return resultado;
            }
            cliente.DniCliente = clienteDTO.DniCliente;
            cliente.Nombre = clienteDTO.Nombre;
            cliente.Apellido = clienteDTO.Apellido;
            cliente.Email = clienteDTO.Email;
            cliente.Latitud = clienteDTO.Latitud;
            cliente.Longitud = clienteDTO.Longitud;
            cliente.FechaActualizacion = DateTime.Now;
            ClienteFiles.EscribirClienteaJson(cliente);
            resultado.Success = true;
            resultado.Message = "El Cliente se Actualizo con Exito";
            return resultado;
        }

        public List<ClienteDTO> ObtenerListaClientes()
        {
            List<ClienteDTO> clienteDTOs = new List<ClienteDTO>();
            List<ClienteEntity> clientes = ClienteFiles.LeerClientesDesdeJson();
            foreach (var item in clientes)
            {
                ClienteDTO clienteDTO = new ClienteDTO
                {
                    Apellido = item.Apellido,
                    Email = item.Email,
                    Latitud = item.Latitud,
                    Longitud = item.Longitud,
                    Nombre = item.Nombre,
                    Telefono = item.Telefono,
                    FechaNacimiento = item.FechaNacimiento,
                    DniCliente = item.DniCliente
                };
                clienteDTOs.Add(clienteDTO);
            }
            return clienteDTOs;
        }
    }
}
