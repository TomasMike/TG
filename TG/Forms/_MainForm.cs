using System;
using System.Drawing;
using System.Windows.Forms;
using TG.CoreStuff;
using TG.CustomControls;
using TG.Managers;
using TG.SavingLoading;

namespace TG.Forms
{
    public partial class _MainForm : Form
    {
        #region Singleton logic

        public static _MainForm Instance => _instance ?? (_instance = new _MainForm());

        private _MainForm()
        {
            InitializeComponent();
        }

        private static _MainForm _instance = null;
        #endregion Singleton logic

        private BindingSource _bs;
        public MapPanel Mp = new MapPanel();
        public FlowLayoutPanel _characterPanelFlPanel = new FlowLayoutPanel();
        public FlowLayoutPanel _actionButtonFlPanel = new FlowLayoutPanel();
        public Panel _bottomFlPanel = new Panel();

        public Button _endTurnBtn = new Button();

        private void MainForm_Load(object sender, EventArgs e)
        {
            Mp.Dock = DockStyle.Left;
            Mp.AutoSize = true;
            mainContentPanel.Controls.Add(Mp);

            _characterPanelFlPanel.Dock = DockStyle.Right;
            _characterPanelFlPanel.AutoSize = true;
            _characterPanelFlPanel.BackColor = Color.Aqua;
            mainContentPanel.Controls.Add(_characterPanelFlPanel);


            _bottomFlPanel.Dock = DockStyle.Bottom;
            _bottomFlPanel.AutoSize = true;
            _bottomFlPanel.BackColor = Color.DarkViolet;
            mainContentPanel.Controls.Add(_bottomFlPanel);

            _endTurnBtn.Text = "End Turn";
            _endTurnBtn.Dock = DockStyle.Right;
            _bottomFlPanel.Controls.Add(_endTurnBtn);

            _actionButtonFlPanel.Dock = DockStyle.Fill;
            _actionButtonFlPanel.BackColor = Color.DarkViolet;
            _actionButtonFlPanel.AutoSize = true;
            _bottomFlPanel.Controls.Add(_actionButtonFlPanel);



            var startMenu = new StartMenuForm();
            var result = startMenu.ShowDialog();

            if (result == DialogResult.OK)
                InitGameFromSaveSheet();
            else
                this.Close();
        }

        public void InitGameFromSaveSheet()
        {
            SaveManager.LoadGameDataFromSaveFile();

            foreach (var p in Game.Instance.Players)
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

        private void restoreEnergyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugCheats.RestoreEnergyToActivePlayer();
        }

        private void foodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugCheats.Add10FoodToActivePlayer();
        }
    }
}