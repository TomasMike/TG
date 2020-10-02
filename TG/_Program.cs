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
            using(SqlConnection c = new SqlConnection("server=localhost;TRUSTED_CONNECTION=yes;database=ShirtShop;"))
            {
                var x = "312";
                c.Open();

            }
            string[] q = new string[] {"Dominik","Casper","Archi" };

            var koote = q[0];



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