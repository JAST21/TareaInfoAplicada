using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionPedidos.Services
{
    public interface IInventoryService
    {
        bool VerificarInventario(int productoId, int cantidad);
        void ActualizarInventario(int productoId, int cantidad);
    }
}
