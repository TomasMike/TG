using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TG.Enums;
using TG.Forms;

namespace TG
{
    static class _Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (true)
            {
                foreach (var f in Directory.GetFiles(@"C:\Projects\Nuntio.NET\windows services\Nuntio.NET.WindowsService\bin\Debug\Plugins"))
                {
                    if (f.IndexOf("NotificationSender") == -1)
                        File.Delete(f);
                }
            }

            var q = CharacterArchetype.Blue;
            var x = ((int)q).ToString();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new _MainForm());
            //Application.Run(new MainForm());
        }
    }
}
