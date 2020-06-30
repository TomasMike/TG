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
        private static _MainForm _instance = null;

        public static _MainForm Instance => _instance ?? (_instance = new _MainForm());


        public _MainForm()
        {
            InitializeComponent();
        }

        public MapPanel Mp = new MapPanel();
        readonly FlowLayoutPanel _characterPanelFlPanel = new FlowLayoutPanel();
        readonly FlowLayoutPanel _actionButtonFlPanel = new FlowLayoutPanel();

        private void MainForm_Load(object sender, EventArgs e)
        {
            var startMenu = new StartMenuForm();

            Mp.Dock = DockStyle.Left;
            Mp.AutoSize = true;
            mainContentPanel.Controls.Add(Mp);

            _characterPanelFlPanel.Dock = DockStyle.Right;
            _characterPanelFlPanel.AutoSize = true;
            //chFlowLayoutPanel.Size = new Size(100,100);
            _characterPanelFlPanel.BackColor = Color.Aqua;
            mainContentPanel.Controls.Add(_characterPanelFlPanel);


            _actionButtonFlPanel.Dock = DockStyle.Bottom;
            _actionButtonFlPanel.AutoSize = true;
            mainContentPanel.Controls.Add(_actionButtonFlPanel);


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
                Mp.AddLocationCardToMap(l.LocationNumber, l.MenhirValue);
            }

            _characterPanelFlPanel.SuspendLayout();
            foreach (var p in SaveManager.CurrentSaveSheet.Players)
            {

                CharacterBoard chb = new CharacterBoard(p);


                _characterPanelFlPanel.Controls.Add(chb);
                //bs = new BindingSource();
                //bs.
                //((CharacterBoard)(chFlowLayoutPanel.Controls[0])).HealthValue.DataBindings.Add("Text", SaveManager.CurrentSaveSheet.Players[0].Character, "CurrentHealth");
            }
            _characterPanelFlPanel.ResumeLayout(false);
            _characterPanelFlPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            Mp.RefreshMapLayout();
            SaveManager.Save();
        }

        private void ChFlowLayoutPanel_BindingContextChanged(object sender, EventArgs e)
        {
            var x = 3;
        }

        private void niecoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveManager.CurrentSaveSheet.Players[0].Character.CurrentHealth--;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private BindingSource _bs;
    }
}
