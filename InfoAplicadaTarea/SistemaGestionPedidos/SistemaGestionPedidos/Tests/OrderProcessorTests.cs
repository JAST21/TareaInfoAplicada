using NSubstitute;
using SistemaGestionPedidos.Models;
using SistemaGestionPedidos.Services;
using Xunit;

namespace SistemaGestionPedidos.Tests
{
    public class OrderProcessorTests
    {
        [Fact]
        public void ProcesarPedido_ConInventarioSuficiente_EnvíaCorreo()
        {
            // Arrange
            var inventoryService = Substitute.For<IInventoryService>();
            var emailService = Substitute.For<IEmailService>();
            var orderProcessor = new OrderProcessor(inventoryService, emailService);
            var pedido = new Pedido
            {
                Id = 1,
                ClienteNombre = "Juan",
                Articulos = new List<Pedido.Articulo>
                {
                    new Pedido.Articulo { Id = 1, Nombre = "Producto A", Precio = 10.00m, Cantidad = 1 }
                }
            };

            inventoryService.VerificarInventario(1, 1).Returns(true);

            // Act
            orderProcessor.ProcesarPedido(pedido);

            // Assert
            emailService.Received(1).EnviarConfirmacion(pedido);
            Assert.Equal("Procesado", pedido.Estado);
        }

        [Fact]
        public void ProcesarPedido_SinInventario_LanzaExcepcion()
        {
            // Arrange
            var inventoryService = Substitute.For<IInventoryService>();
            var emailService = Substitute.For<IEmailService>();
            var orderProcessor = new OrderProcessor(inventoryService, emailService);
            var pedido = new Pedido
            {
                Id = 2,
                ClienteNombre = "Ana",
                Articulos = new List<Pedido.Articulo>
                {
                    new Pedido.Articulo { Id = 1, Nombre = "Producto A", Precio = 10.00m, Cantidad = 1 }
                }
            };

            inventoryService.VerificarInventario(1, 1).Returns(false);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => orderProcessor.ProcesarPedido(pedido));
        }

        [Fact]
        public void ProcesarPedido_ConLimiteMaximo_EnvíaCorreo()
        {
            // Arrange
            var inventoryService = Substitute.For<IInventoryService>();
            var emailService = Substitute.For<IEmailService>();
            var orderProcessor = new OrderProcessor(inventoryService, emailService);
            var pedido = new Pedido
            {
                Id = 3,
                ClienteNombre = "Luis",
                Articulos = new List<Pedido.Articulo>
                {
                    new Pedido.Articulo { Id = 1, Nombre = "Producto A", Precio = 10.00m, Cantidad = 100 }
                }
            };

            inventoryService.VerificarInventario(1, 100).Returns(true);

            // Act
            orderProcessor.ProcesarPedido(pedido);

            // Assert
            emailService.Received(1).EnviarConfirmacion(pedido);
        }
    }
}
