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

        [SetUp]
        public void Setup()
        {
            clienteService = new ClienteService();
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
            
        }
        [Test]
        public void AgregarCliente_FaltaDni_DeberiaDarFalse()
        {
            var clienteDTO = new ClienteDTO
            {
                DniCliente = 0,
                Nombre = "Nereo",
                Apellido = "Ayala",
                Email = "nereoayala@gmail.com",
                Telefono = "3492456789",
                FechaNacimiento = DateTime.Now,
                Latitud = -343849.0,
                Longitud = 234567.0,
            };
            ResultadoEntity resultado = clienteService.AgregarCliente(clienteDTO);
            Assert.IsFalse(resultado.Success);
            Assert.AreEqual("El Dni del Cliente no es Valido", resultado.Errores[0]);
        }
    }
}
