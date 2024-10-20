using SistemaGestionPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionPedidos.Services
{
    public class EmailService : IEmailService
    {
        public void EnviarConfirmacion(Pedido pedido)
        {
            // Simulación de envío de correo
            Console.WriteLine($"Correo de confirmación enviado a {pedido.ClienteNombre}");
        }
    }
}
