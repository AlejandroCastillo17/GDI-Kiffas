using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDI_kiffas.Logica
{
    public  class Mesas
    {
        public string NombreMesa { get; set; }
        public List<Ventas> Ventas { get; set; } = new List<Ventas>();

        public decimal CalcularTotal()
        {
            return Ventas.Sum(v => v.precio);
        }
    }
}
