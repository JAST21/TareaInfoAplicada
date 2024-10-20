using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionPedidos.Services
{
    public class InventoryService : IInventoryService
    {
        public bool VerificarInventario(int productoId, int cantidad)
        {
            // Simulación: aquí asumimos que siempre hay suficiente stock si es <= 10
            return cantidad <= 10;
        }

        public void ActualizarInventario(int productoId, int cantidad)
        {
            // Lógica para actualizar inventario
            Console.WriteLine($"Inventario actualizado para el producto {productoId}, cantidad: {cantidad}");
        }
    }
}
