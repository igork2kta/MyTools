using System.Reflection;

[assembly: AssemblyVersion("1.2.0")]
namespace MyTools
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
            ApplicationConfiguration.Initialize();
            //Version version = Assembly.GetEntryAssembly().GetName().Version;
            Application.Run(new MainForm());

        }

    }


}