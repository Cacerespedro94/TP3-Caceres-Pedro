using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{

    public class Carrito
    {
        public Carrito()
        {
            item = new List<Articulo>();
            cantidad = 0;
            precioTotal = 0;
        }
        public List<Articulo> item { get; set; }
        public int cantidad { get; set; }
        public decimal precioTotal { get; set; }
    }
}
