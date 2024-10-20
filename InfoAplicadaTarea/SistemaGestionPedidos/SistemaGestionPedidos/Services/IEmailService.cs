using SistemaGestionPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionPedidos.Services
{
    public interface IEmailService
    {
        void EnviarConfirmacion(Pedido pedido);
    }
}
