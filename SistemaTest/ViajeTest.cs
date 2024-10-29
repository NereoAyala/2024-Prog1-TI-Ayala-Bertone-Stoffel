using Microsoft.AspNetCore.Components.Forms;
using SistemaData;
using SistemaDTO;
using SistemaServices;
using SistemaShareds;
using SistemaWebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTest
{
    public class ViajeTest
    {
        ViajeService viajeService = new ViajeService();

        [SetUp]
        public void Setup()
        {
            viajeService = new ViajeService();
            var camionetas = CamionetaFiles.LeerCamionetasDesdeJson();
            var compras = CompraFiles.LeerCompraDesdeJson();
        }

        [Test]
        public void AgregarViaje_OK_DeberiaAgregarViaje()
        {
            var controller = new ViajeController();
            var controllercompra=new CompraController();
            CompraDTO compra1 = new CompraDTO()
            {
                CodProducto = 1,
                DniCliente = 240,
                CantidadComprado = 5,
                FechaEntrega = DateTime.Now.AddDays(5),
            };
            CompraDTO compra2 = new CompraDTO()
            {
                CodProducto = 3,
                DniCliente = 240,
                CantidadComprado = 1,
                FechaEntrega = DateTime.Now.AddDays(3),
            };
            CompraDTO compra3 = new CompraDTO()
            {
                CodProducto = 4,
                DniCliente = 240,
                CantidadComprado = 3,
                FechaEntrega = DateTime.Now.AddDays(2),
            };
            controllercompra.AgregarCompra(compra1);
            controllercompra.AgregarCompra(compra2);
            controllercompra.AgregarCompra(compra3);

            var viajeDTO = new ViajeDTO
            {
                FechaEntregaDesde = DateTime.Now.AddDays(1),
                FechaEntregaHasta = DateTime.Now.AddDays(5)
            };
            var camionetas = CamionetaFiles.LeerCamionetasDesdeJson();
            var resultado = viajeService.AgregarViaje(viajeDTO);

            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Success);
            Assert.AreEqual("Viajes asignados correctamente.", resultado.Message);

            // Verificar que todas las compras con estado Open hayan cambiado a ReadyToDispatch
            var compras = CompraFiles.LeerCompraDesdeJson();
            Assert.IsTrue(compras.All(x => x.EstadoCompra == Enums.EstadoCompra.ReadyToDispach));
        }
    }
}

