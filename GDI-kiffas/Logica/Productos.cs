using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDI_kiffas.Logica
{
    public class Productos
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Decimal preciouni { get; set; }
        public Decimal costo { get; set; }
        public Decimal cantidad_inicial { get; set; }
        public Decimal cantidad_actual { get; set; }
        public byte[] foto { get; set; }
        public DateTime fecha { get; set; }

        public string codigobarras {  get; set; }

        public int cantidad { get; set; }
    }
}
