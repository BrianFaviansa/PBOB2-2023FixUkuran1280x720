using PBOB2_2023.View;
using System;
using System.Windows.Forms;

namespace PBOB2_2023
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new v_login());
        }
    }
}
