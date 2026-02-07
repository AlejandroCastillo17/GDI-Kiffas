using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDI_kiffas.Logica
{
    public class Turno
    {
        public int Id { get; set; }
        public string Encargado { get; set; }
        public decimal Base { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaCierre { get; set; }
        public decimal TotalVentas { get; set; }

        // Para el turno en curso
        public static Turno TurnoActual { get; set; }
    }
}
