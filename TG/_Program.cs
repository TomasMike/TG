using System;
using System.Windows.Forms;
using TG.Forms;

namespace TG
{
    internal static class _Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(_MainForm.Instance);
            //Application.Run(new MainForm());
        }
    }
}