namespace PracticaForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            if (!Environment.Is64BitOperatingSystem)
            {
                MessageBox.Show("Error no se soporta arquitectura que no sea 64 bits");
            }
            else
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new Inicio());
            }
        }
    }
}