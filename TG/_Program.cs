using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
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
            var l = new List<int>();
            var b = l.All(i => i > 5);


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