using SistemaData;
using SistemaDTO;
using SistemaEntities;

namespace SistemaServices
{
    public class ClienteService
    {
        public void AgregarCliente(ClienteDTO cliente)
        {
            List<ClienteEntity> clientes = ClienteFiles.LeerClientesDesdeJson();
            if (clientes.Any(c => c.DniCliente == cliente.DniCliente))
            {
                return;
            }
            var clienteNuevo = new ClienteEntity
            {
                DniCliente = cliente.DniCliente,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email,
                FechaNacimiento = cliente.FechaNacimiento, // Usar solo la parte de la fecha DATE
                Telefono = cliente.Telefono,
                FechaCreacion = DateTime.Now,
                localizacionCliente=new Localizacion 
                {
                    LatitudCliente=cliente.Latitud,
                    LongitudCliente= cliente.Longitud,
                }
            };
            clientes.Add(clienteNuevo);
            ClienteFiles.EscribirClienteaJson(clienteNuevo);
        }
        public ClienteEntity EliminarCliente(int id)
        {
            List<ClienteEntity> clientes = ClienteFiles.LeerClientesDesdeJson();
            ClienteEntity cliente = clientes.Find(x => x.IdCliente == id);
            if (cliente == null)
            {
                return null;
            }
            cliente.FechaEliminacion = DateTime.Now;
            ClienteFiles.EscribirClienteaJson(cliente);
            return cliente;
        }
        public ClienteEntity ActualizarCliente(int id, ClienteDTO clienteDTO)
        {
            List<ClienteEntity> clientes = ClienteFiles.LeerClientesDesdeJson();
            ClienteEntity cliente = clientes.Find(x => x.IdCliente == id);
            if (cliente == null)
            {
                return null;
            }
            cliente.DniCliente = clienteDTO.DniCliente;
            cliente.Nombre = clienteDTO.Nombre;
            cliente.Apellido = clienteDTO.Apellido;
            cliente.Email = clienteDTO.Email;
            cliente.localizacionCliente = new Localizacion()
            {
                LatitudCliente = clienteDTO.Latitud,
                LongitudCliente = clienteDTO.Longitud,
            };
            cliente.FechaEliminacion = null;
            ClienteFiles.EscribirClienteaJson(cliente);
            return cliente;
        }
        public List<ClienteDTO> ObtenerListaClientes()
        {
            List<ClienteDTO> clienteDTOs = new List<ClienteDTO>();
            List<ClienteEntity> clientes = ClienteFiles.LeerClientesDesdeJson().Where(x=>x.FechaEliminacion==null).ToList();
            foreach (var item in clientes)
            {
                ClienteDTO clienteDTO = new ClienteDTO
                {
                    Apellido = item.Apellido,
                    Email = item.Email,
                    Latitud=item.localizacionCliente.LatitudCliente,
                    Longitud=item.localizacionCliente.LongitudCliente,
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
