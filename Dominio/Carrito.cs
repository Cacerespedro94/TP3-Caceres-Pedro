using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public class Carrito
    {
        public Articulo item { get; set; }
        public int cantidad { get; set; }
        public decimal precioTotal { get; set; }
    }
}
