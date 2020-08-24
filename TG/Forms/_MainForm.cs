using System;
using System.Drawing;
using System.Windows.Forms;
using TG.CustomControls;
using TG.Managers;
using TG.SavingLoading;

namespace TG.Forms
{
    public partial class _MainForm : Form
    {
        #region Singleton logic

        public static _MainForm Instance => _instance ?? (_instance = new _MainForm());

        public _MainForm()
        {
            InitializeComponent();
        }

        #endregion Singleton logic

        private static _MainForm _instance = null;
        private BindingSource _bs;
        public MapPanel Mp = new MapPanel();
        public FlowLayoutPanel _characterPanelFlPanel = new FlowLayoutPanel();
        public FlowLayoutPanel _actionButtonFlPanel = new FlowLayoutPanel();

        private void MainForm_Load(object sender, EventArgs e)
        {
            Mp.Dock = DockStyle.Left;
            Mp.AutoSize = true;
            mainContentPanel.Controls.Add(Mp);

            _characterPanelFlPanel.Dock = DockStyle.Right;
            _characterPanelFlPanel.AutoSize = true;
            _characterPanelFlPanel.BackColor = Color.Aqua;
            mainContentPanel.Controls.Add(_characterPanelFlPanel);


            _actionButtonFlPanel.Dock = DockStyle.Bottom;
            _actionButtonFlPanel.AutoSize = true;
            _actionButtonFlPanel.BackColor = Color.DarkViolet;
            mainContentPanel.Controls.Add(_actionButtonFlPanel);



            var startMenu = new StartMenuForm();
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
            }

            _characterPanelFlPanel.ResumeLayout(false);
            _characterPanelFlPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
            ActionManager.InitActionButtonPanel();
            Mp.RefreshMapLayout();
            SaveManager.Save();

            //start game chain
            Game.Instance.ProcessMorningStuff();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveManager.Save();
        }

        private void endDayToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}