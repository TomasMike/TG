using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using TG.Forms;
using TG.HelpersUtils;

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

            DateTime dob;
            ///var a = DateTime.Parse("1950-24-12 00:00:00.000");
            var b = DateTime.Parse("1950-12-24 00:00:00.000");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(_MainForm.Instance);
            //Application.Run(new MainForm());
        }

        private static void q(Int32? i)
        {
            i +=2;
        }

        private static void q(ref Int32 i)
        {
            i += 2;
        }
    }
}