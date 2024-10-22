using System;
using SistemaServices;
using NUnit.Framework;
using SistemaDTO;
using SistemaEntities;


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
        //[Test]
        //public void TestCrearCompra_Correcto()
        //{
        //    ResultadoEntity res = compraservice.CrearCompra(new CompraDTO()
        //    {
        //        CodProducto = 1,
        //        DniCliente = 43955641,
        //        CantidadComprado = 10,
        //        FechaEntrega = new DateTime(2023, 12, 25)
        //    });
        //    Assert.IsTrue(res.Success);
        //    Assert.That(res.Errores.Count, Is.EqualTo(0));
        //    ProductoService stock = new ProductoService();
        //    Assert.That(stock.ObtenerListaProductos()[0].StockDisponible, Is.EqualTo(15));
        //}
        //[Test]
        //public void TestCrearCompra_Incorrecto_FaltanDatos()
        //{
        //    ResultadoEntity res = compraservice.CrearCompra(new CompraDTO()
        //    {
        //        CodProducto = 1,
        //    });
        //    Assert.IsFalse(res.Success);
        //    Assert.That(res.Errores[0], Is.EqualTo("El dni del cliente no es valido."));
        //    Assert.That(res.Errores[1], Is.EqualTo("La cantidad ingresada no es valida."));
        //    Assert.That(res.Errores[2], Is.EqualTo("La fecha de entrega no es valida.")); 
        //    Assert.That(compraservice.ObtenerCompras().Count, Is.EqualTo(0));
        //}

        //[Test]
        //public void TestCrearCompra_Incorrecto_ErrorCodigo_ErrorCliente_ErrorStock()
        //{
        //    ResultadoEntity res = compraservice.CrearCompra(new CompraDTO()
        //    {
        //        CodProducto = 9,
        //        CantidadComprado = 30,
        //        DniCliente = 45029420,
        //        FechaEntrega = DateTime.Now.AddDays(7),
        //    });
        //    Assert.IsFalse(res.Success);
        //    Assert.That(res.Errores[0], Is.EqualTo("Producto no encontrado"));
        //    Assert.That(res.Errores[1], Is.EqualTo("No se puede realizar la compra no hay stock suficiente"));
        //    Assert.That(res.Errores[2], Is.EqualTo("Cliente no encontrado"));
        //    Assert.That(compraservice.ObtenerCompras().Count, Is.EqualTo(0));
        //}
    }
}