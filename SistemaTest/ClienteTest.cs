using Microsoft.AspNetCore.Mvc;
using SistemaData;
using SistemaDTO;
using SistemaEntities;
using SistemaServices;
using SistemaWebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTest
{
    public class ClienteTest
    {
        ClienteService clienteService = new ClienteService();

        [SetUp]
        public void Setup()
        {
            clienteService = new ClienteService();
        }

        private ClienteDTO CrearClienteValido()
        {
            return new ClienteDTO
            {
                DniCliente = 44231379,
                Nombre = "Nereo",
                Apellido = "Ayala",
                Email = "nereoayala@gmail.com",
                Telefono = "3492456789",
                FechaNacimiento = DateTime.Now,
                Latitud = -343849.0,
                Longitud = 234567.0,
            };
        }
        [Test]
        public void AgregarCliente_Ok_DeberiaAgregarClienteALaLista()
        {
            var controller = new ClienteController();
            ClienteDTO clienteDTO = CrearClienteValido();

            var resultado = controller.AgregarCliente(clienteDTO) as OkObjectResult;

            Assert.IsNotNull(resultado);
            Assert.AreEqual(200, resultado.StatusCode);
            Assert.AreEqual("Cliente agregado con éxito.", resultado.Value);

            var clientes = ClienteFiles.LeerClientesDesdeJson();
            bool clienteAgregado = clientes.Any(x => x.DniCliente == clienteDTO.DniCliente);

            Assert.IsTrue(clienteAgregado, "El cliente debería estar en la lista después de agregarlo.");
        }
        [Test]
        public void AgregarCliente_FaltaDni_DeberiaDarFalse()
        {
            var controller = new ClienteController();
            ClienteDTO clienteDTO = CrearClienteValido();
            clienteDTO.DniCliente = 0;

            var resultado = controller.AgregarCliente(clienteDTO) as BadRequestObjectResult;

            Assert.IsNotNull(resultado);
            Assert.AreEqual(400, resultado.StatusCode);

            var mensajeError = resultado.Value as SerializableError;
            Assert.IsTrue(mensajeError.ContainsKey("DniCliente"));
        }
    }
}
