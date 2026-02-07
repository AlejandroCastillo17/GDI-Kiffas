using GDI_kiffas.Interfaz;

namespace GDI_kiffas
{
    internal static class Program
    {
        public static MesasActivas VentanasMesas;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Interfaz.Bienvenida());
        }
    }
}