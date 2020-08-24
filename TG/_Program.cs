using System;
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
            //SerializableDictionary<string, string> q = new SerializableDictionary<string, string>();
            //q.Add("bq", "QWE");

            //XmlSerializer writer = new XmlSerializer(q.GetType());
            //var s = new System.IO.StringWriter();
            //writer.Serialize(s, q);
            //var qq = s.ToString();


            



            //return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(_MainForm.Instance);
            //Application.Run(new MainForm());
        }
    }
}