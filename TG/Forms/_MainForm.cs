using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TG.CustomControls;
using TG.Forms;

namespace TG
{
    public partial class _MainForm : Form
    {
        public _MainForm()
        {
            InitializeComponent();

        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            var startMenu = new StartMenuForm();
            startMenu.ShowDialog();
            InitGameFromSaveSheet();

        }

        public void InitGameFromSaveSheet()
        {
            //TODO init ine herne komponenty
            foreach (var l in SaveManager.CurrentSaveSheet.Locations)
            {
                mapPanel1.AddLocationCardToMap(l.LocationNumber,l.MenhirValue);
            }

            foreach (var p in SaveManager.CurrentSaveSheet.Players)
            {

                CharacterBoard chb = new CharacterBoard();
                p.
            }

            mapPanel1.RefreshMapLayout();
            SaveManager.Save();
        }


    }
}
