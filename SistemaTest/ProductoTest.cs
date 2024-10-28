using Microsoft.AspNetCore.Mvc;
using SistemaDTO;
using SistemaServices;
using SistemaWebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTest
{
    public class ProductoTest
    {
        ProductoService productoService=new ProductoService();

        [SetUp]
        public void Setup()
        {
            productoService = new ProductoService();
        }

        private ProductoDTO CrearProductoValido() 
        {
            return new ProductoDTO
            {
                Nombre = "Hamburguesa",
                Marca = "Paty",
                StockDisponible=10,
                StockMinimo=5,
                PrecioUnitario=2000,
                AltoCaja=5,
                AnchoCaja=5,
                ProfundidadCaja = 5
            };
        }

        [Test]
        public void AgregarProducto_OK_DeberiaAgregarseProducto() 
        {
            var controller=new ProductoController();
            var productoDTO=CrearProductoValido();

            var resultado = controller.AgregarProducto(productoDTO) as OkObjectResult;

            Assert.IsNotNull(resultado);
            Assert.AreEqual(200, resultado.StatusCode);
            Assert.AreEqual("Producto agregado con éxito.", resultado.Value);
        }
        [Test]
        public void AgregarProducto_FaltaNombre_DeberiaDarFalse() 
        {
            var controller=new ProductoController();
            var productoDTO = CrearProductoValido();
            productoDTO.Nombre = null;

            var resultado = controller.AgregarProducto(productoDTO) as BadRequestObjectResult;

            Assert.IsNotNull(resultado);
            Assert.AreEqual(400, resultado.StatusCode);

            var mensajeError = resultado.Value as SerializableError;
            Assert.IsTrue(mensajeError.ContainsKey("NombreProducto"));
        }
    }
}
