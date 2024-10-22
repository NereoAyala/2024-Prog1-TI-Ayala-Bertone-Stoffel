using SistemaDTO;
using SistemaEntities;
using SistemaServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTest
{
    public class ClienteTest
    {
        ClienteService clienteService=new ClienteService();
        private ClienteDTO clienteDTO;

        [SetUp]
        public void Setup()
        {
            clienteService = new ClienteService();
            clienteDTO = CrearClienteValido();
        }

        private ClienteDTO CrearClienteValido() 
        {
            return new ClienteDTO 
            {
                DniCliente=44231379,
                Nombre= "Nereo",
                Apellido="Ayala",
                Email="nereoayala@gmail.com",
                Telefono="3492456789",
                FechaNacimiento = DateTime.Now,
                Latitud=-343849.0,
                Longitud= 234567.0,
            };
        }
        [Test]
        public void AgregarCliente_Ok_DeberiaAgregarClienteALaLista() 
        {
            ClienteDTO clienteDTO = CrearClienteValido();

            ResultadoEntity resultado = clienteService.AgregarCliente(clienteDTO);

            Assert.IsTrue(resultado.Success);
            Assert.AreEqual("El Cliente se Cargo Con Exito", resultado.Message);
            Assert.AreEqual(3,clienteService.ObtenerListaClientes().Count());
        }
    }
}
