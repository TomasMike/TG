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

        MapPanel mp = new MapPanel();
        FlowLayoutPanel chFlowLayoutPanel = new FlowLayoutPanel();

        private void MainForm_Load(object sender, EventArgs e)
        {
            var startMenu = new StartMenuForm();

            mp.Dock = DockStyle.Left;
            mp.AutoSize = true;
            panel1.Controls.Add(mp);

            chFlowLayoutPanel.Dock = DockStyle.Right;
            chFlowLayoutPanel.AutoSize = true;
            //chFlowLayoutPanel.Size = new Size(100,100);
            chFlowLayoutPanel.BackColor = Color.Aqua;
            panel1.Controls.Add(chFlowLayoutPanel);

            var result = startMenu.ShowDialog();

            if (result == DialogResult.OK)
                InitGameFromSaveSheet();
            else
                this.Close();

        }

        public void InitGameFromSaveSheet()
        {
            //TODO init ine herne komponenty
            foreach (var l in SaveManager.CurrentSaveSheet.Locations)
            {
                mp.AddLocationCardToMap(l.LocationNumber, l.MenhirValue);
            }

            chFlowLayoutPanel.SuspendLayout();
            foreach (var p in SaveManager.CurrentSaveSheet.Players)
            {

                CharacterBoard chb = new CharacterBoard(p);


                chFlowLayoutPanel.Controls.Add(chb);
                //bs = new BindingSource();
                //bs.
                //((CharacterBoard)(chFlowLayoutPanel.Controls[0])).HealthValue.DataBindings.Add("Text", SaveManager.CurrentSaveSheet.Players[0].Character, "CurrentHealth");
            }
            chFlowLayoutPanel.ResumeLayout(false);
            chFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            mp.RefreshMapLayout();
            SaveManager.Save();
        }

        private void ChFlowLayoutPanel_BindingContextChanged(object sender, EventArgs e)
        {
            var x = 3;
        }

        private void niecoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chFlowLayoutPanel.Controls.Add(new Button());
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private BindingSource bs;
    }
}
