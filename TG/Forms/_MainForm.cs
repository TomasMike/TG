using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TG.Forms;

namespace TG
{
    public partial class _MainForm : Form
    {
        public _MainForm()
        {
            InitializeComponent();
            
        }

        private MapPanel mapPanel= new MapPanel();

        private void MainForm_Load(object sender, EventArgs e)
        {
            var startMenu = new StartMenuForm();
            startMenu.ShowDialog();
            if (LocationsLib.Locations != null) mapPanel.Controls.AddRange(LocationsLib.Locations.ToArray());
            mapPanel.Location = Location;
            mapPanel.Size = ClientSize;
            mapPanel.RefreshMapLayout();

          
        }


    }
}
