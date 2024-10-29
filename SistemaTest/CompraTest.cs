using System;
using SistemaServices;
using NUnit.Framework;
using SistemaDTO;
using SistemaEntities;
using Microsoft.AspNetCore.Mvc;
using SistemaData;
using SistemaWebApi.Controllers;


namespace SistemaTest
{
    public class CompraTest
    {
        CompraService compraservice = new CompraService();
        [SetUp]
        public void Setup()
        {
            CargarProductos();
            CargarClientes();
        }
        private void CargarClientes()
        {
            ClienteService clienteService = new ClienteService();
            clienteService.AgregarCliente(new ClienteDTO()
            {
                DniCliente = 46218295,
                Nombre = "Francisco",
                Apellido = "Stoffel",
                Email = "Franstoffel@gmail.com",
                Telefono = "4566732",
                Latitud = 123421,
                Longitud = 431335,
                FechaNacimiento = new DateTime(2004, 05, 28)
            });

            clienteService.AgregarCliente(new ClienteDTO()
            {
                DniCliente = 43955732,
                Nombre = "Nereo",
                Apellido = "Ayala",
                Email = "NereAyala@gmail.com",
                Telefono = "206289",
                Latitud = 187651,
                Longitud = 424635,
                FechaNacimiento = new DateTime(2002, 05, 03)
            });
        }
        private void CargarProductos()
        {
            ProductoService productoService = new ProductoService();
            productoService.AgregarProducto(new ProductoDTO
            {
                Nombre = "ProductoTest",
                Marca = "MarcaTest",
                AltoCaja = 1,
                AnchoCaja = 1,
                ProfundidadCaja = 1,
                PrecioUnitario = 1,
                StockMinimo = 1,
                StockDisponible = 25
            });
            productoService.AgregarProducto(new ProductoDTO
            {
                Nombre = "ProductoTest2",
                Marca = "MarcaTest2",
                AltoCaja = 2,
                AnchoCaja = 2,
                ProfundidadCaja = 2,
                PrecioUnitario = 2,
                StockMinimo = 2,
                StockDisponible = 20
            });
            productoService.AgregarProducto(new ProductoDTO
            {
                Nombre = "ProductoTest3",
                Marca = "MarcaTest3",
                AltoCaja = 3,
                AnchoCaja = 3,
                ProfundidadCaja = 3,
                PrecioUnitario = 3,
                StockMinimo = 3,
                StockDisponible = 30
            });
        }
        [Test]
        public void TestCrearCompra_Ok_DeberiaAgregarCompra()
        {
            var controller = new CompraController();
            var compraDTO = new CompraDTO
            {
                CodProducto = 1,
                DniCliente = 46218295,
                CantidadComprado = 2,
                FechaEntrega = DateTime.Now
            };

            CargarProductos();

            var resultado = controller.AgregarCompra(compraDTO) as OkObjectResult;

            Assert.IsNotNull(resultado);
            Assert.AreEqual(200, resultado.StatusCode);

            var compras = CompraFiles.LeerCompraDesdeJson();
            var compraAgregada = compras.FirstOrDefault(x => x.DniCliente == compraDTO.DniCliente && x.CodProducto == compraDTO.CodProducto);

            Assert.IsNotNull(compraAgregada);
            Assert.AreEqual(compraDTO.CantidadComprado, compraAgregada.CantidadComprado);
        }
        [Test]
        public void CrearCompra_FaltaDNI_DeberiaDarError()
        {
            var controller = new CompraController();
            var compraDTO = new CompraDTO
            {
                CodProducto = 1,
                DniCliente = 0,
                CantidadComprado = 2,
                FechaEntrega = DateTime.Now
            };

            CargarProductos();
            var resultado = controller.AgregarCompra(compraDTO) as BadRequestObjectResult;

            Assert.IsNotNull(resultado);
            Assert.AreEqual(400, resultado.StatusCode);

            var errores = resultado.Value as SerializableError;
            Assert.IsNotNull(errores);//PODRIA SACARLO
        }

        [Test]
        public void CrearCompra_FaltaCodProducto_DeberiaDarError()
        {
            var controller = new CompraController();
            var compraDTO = new CompraDTO
            {
                CodProducto = 0,
                DniCliente = 46218295,
                CantidadComprado = 2,
                FechaEntrega = DateTime.Now
            };

            CargarProductos();
            var resultado = controller.AgregarCompra(compraDTO) as BadRequestObjectResult;

            Assert.IsNotNull(resultado);
            Assert.AreEqual(400, resultado.StatusCode);

            var errores = resultado.Value as SerializableError;
            Assert.IsNotNull(errores);//PODRIA SACARLO
        }
    }
}