using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDI_kiffas.Interfaz;

namespace GDI_kiffas.Logica
{
    public static class EventoMesas
    {
        // Evento que notifica cuando se crea una nueva mesa activa
        public static event EventHandler<Mesas> MesaCreada;

        // Método para disparar el evento desde cualquier parte
        public static void OnMesaCreada(Mesas mesa)
        {
            MesaCreada?.Invoke(null, mesa);
        }
    }
}
