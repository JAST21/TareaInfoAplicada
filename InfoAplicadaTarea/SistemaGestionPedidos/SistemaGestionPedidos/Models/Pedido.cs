using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionPedidos.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string ClienteNombre { get; set; }
        public List<Articulo> Articulos { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public class Articulo
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public int Cantidad { get; set; }
        }
    }
}
