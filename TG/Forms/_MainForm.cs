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
using TG.Enums;
using TG.Forms;

namespace TG
{
    public partial class _MainForm : Form
    {
        #region Singleton logic
        public static _MainForm Instance => _instance ?? (_instance = new _MainForm());

        public _MainForm()
        {
            InitializeComponent();
        }
        #endregion


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
            InitActionButtonPanel();
            Mp.RefreshMapLayout();
            SaveManager.Save();


            //start game chain
            ProcessMorningStuff();
        }

        private void InitActionButtonPanel()
        {
            var width = Enum.GetNames(typeof(ActionType)).Max(_ => TextRenderer.MeasureText(_, this.Font).Width)+10;

            foreach (ActionType item in Enum.GetValues(typeof(ActionType)))
            {
                var b = new MainActionButton
                {
                    Text = item.ToString(),
                    BackColor = Color.White,
                    Width = width,
                    ActionType = item
                };
                

                _actionButtonFlPanel.Controls.Add(b);

            }

        }
        #region Game Logic

        private List<PlayerNumber> playersWhoActedThisRound = new List<PlayerNumber>();

        /// <summary>
        /// StartOfTheDay
        /// </summary>
        public void ProcessMorningStuff()
        {
            //Remove expired menhirs
            //remove locations out of the menhir range
            //reduce menhir dial and remove time tokens
            //reveal and read new event card
            //move guardians
            //change equip

            DuringDay();
        }

        public void DuringDay()
        {
            if (SaveManager.CurrentSaveSheet.Players.Count > 1)
            {
                var playersWhoDidntActThisRound = SaveManager.CurrentSaveSheet.Players.Select(_ => _.PlayerNumber).ToList();
                playersWhoDidntActThisRound.RemoveAll(_ => playersWhoActedThisRound.Contains(_));

                var reply = Asker.Ask("Who will be next active player?", playersWhoDidntActThisRound.Select(_ => new Option<PlayerNumber>(_)), false).GetOptionObject();
                Game.Instance.ActivePlayerNumber = reply;
            }
            else
            {
                //singleplayer
                Game.Instance.ActivePlayerNumber = PlayerNumber.Player1;
            }

            StartNextPlayerTurn();
        }

        public void StartNextPlayerTurn()
        {
            //enable/disable available action buttons

        }

        #endregion

        private void niecoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DuringDay();
        }

        private void MoveActionClick(object sender, EventArgs e) 
        {

        }


    }

    public static class MainActionManager
    {
        public static void EnableDisableActionButtonsForActivePlayer()
        {
            var controls = _MainForm.Instance._actionButtonFlPanel.Controls;


            foreach (Control c in controls)
            {
                c.Hide();
            }

            //moze mi nieco branit sa hybat?
            if(Game.Instance.ActivePlayer)

           
        }


    }
}
