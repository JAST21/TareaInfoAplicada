
using System;
using System.Collections.Generic;
using SistemaGestionPedidos.Models;
using SistemaGestionPedidos.Services;

class Program
{
    static void Main(string[] args)
    {
        var inventoryService = new InventoryService();
        var emailService = new EmailService();
        var orderProcessor = new OrderProcessor(inventoryService, emailService);

        var pedido = new Pedido
        {
            Id = 1,
            ClienteNombre = "Juan",
            Articulos = new List<Pedido.Articulo>
            {
                new Pedido.Articulo { Id = 1, Nombre = "Producto A", Precio = 10.00m, Cantidad = 1 }
            },
            Estado = "Pendiente",
            FechaCreacion = DateTime.Now
        };

        try
        {
            orderProcessor.ProcesarPedido(pedido);
            Console.WriteLine($"Pedido procesado: {pedido.ClienteNombre} - Estado: {pedido.Estado}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al procesar el pedido: {ex.Message}");
        }
    }
}
