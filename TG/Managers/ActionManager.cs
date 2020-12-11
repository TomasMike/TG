using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TG.CoreStuff;
using TG.CustomControls;
using TG.Enums;
using TG.Forms;
using TG.HelpersUtils;
using TG.PlayerCharacterItems;
using TG.SavingLoading;

namespace TG.Managers
{
    public static class ActionManager
    {
        private static readonly List<MainActionButton> mainActionButtons = new List<MainActionButton>();

        private static bool IsTravelModeEnabled = false;

        public static event BasicEventHandler ActionFinished;

        public delegate void BasicEventHandler();

        public static void InitActionButtonPanel()
        {
            var width = Enum.GetNames(typeof(ActionType)).Max(_ => TextRenderer.MeasureText(_, _MainForm.Instance.Font).Width) + 10;

            foreach (ActionType item in Enum.GetValues(typeof(ActionType)))
            {
                var b = new MainActionButton
                {
                    Text = item.ToString(),
                    BackColor = Color.White,
                    Width = width,
                    ActionType = item
                };

                mainActionButtons.Add(b);
                _MainForm.Instance._actionButtonFlPanel.Controls.Add(b);
            }

            mainActionButtons.First(_ => _.ActionType == ActionType.Explore).Click += ExplorationActionClick;
            mainActionButtons.First(_ => _.ActionType == ActionType.Travel).Click += TravelActionClick;
            mainActionButtons.First(_ => _.ActionType == ActionType.LocationAction).Click += LocationActionClick;
            mainActionButtons.First(_ => _.ActionType == ActionType.CharacterAction).Click += null;
            mainActionButtons.First(_ => _.ActionType == ActionType.InspectMenhir).Click += InspectMenhirActionClick;
            mainActionButtons.First(_ => _.ActionType == ActionType.Pass).Click += PassClick;
            mainActionButtons.First(_ => _.ActionType == ActionType.Other).Click += null;

            //
            ActionFinished += ActionManager_ActionFinished;
            ActionFinished += Game.Instance.DuringDay;
            //
        }

        private static void ActionManager_ActionFinished()
        {
            SaveManager.Save();
        }

        #region Travel Action
        private static void TravelActionClick(object sender, EventArgs e)
        {
            if (IsTravelModeEnabled)
            {
                DisableMoveMode();
            }
            else
            {
                if (Game.Instance.ActivePlayer.Character.CurrentEnergy > 0)
                    EnableMoveMode();
                else
                    MessageBox.Show("Mas malo energie!");
            }
        }

        public static void EnableMoveMode()
        {
            IsTravelModeEnabled = !IsTravelModeEnabled;

            mainActionButtons.ForEach(_ => { if (_.ActionType != ActionType.Travel) _.Disable(); });
            var b = mainActionButtons.First(_ => _.ActionType == ActionType.Travel);
            b.Enable();
            b.Text = "Cancel Travel";

            foreach (var l in LocationsHelper.GetNeighbourLCCs(Game.Instance.ActivePlayer.CurrentLocationCard, true))
            {
                if(l != null)
                {
                    l.LocationActionBtn.Show();
                    l.LocationActionBtn.Text = "Move Here";
                    l.LocationActionBtn.Click += MoveClick;
                }
            }
            _MainForm.Instance.Refresh();
        }

        private static void MoveClick(object sender, EventArgs e)
        {
            var p = Game.Instance.ActivePlayer;
            p.Character.EditCharProperty(CharacterAttribute.CurrentEnergy,EditCharPropertyChangeType.Subtract,1);
            p.CurrentLocation = ((LocationSelectionButton)sender).LocationNumber;
            _MainForm.Instance.LocationCardsPanel.AddMissingMapTiles();
            DisableMoveMode();
            ActionFinished.Invoke();
        }

        public static void DisableMoveMode()
        {
            IsTravelModeEnabled = !IsTravelModeEnabled;

            mainActionButtons.ForEach(_ => _.Enable());
            var b = mainActionButtons.First(_ => _.ActionType == ActionType.Travel);

            b.Text = "Travel";

            foreach (var item in _MainForm.Instance.LocationCardsPanel.LocationCards)
            {
                var l = LocationsHelper.GetLCControl(item.LocationNumber);
                if (l.LocationActionBtn.Visible)
                {
                    l.LocationActionBtn.Hide();
                    l.LocationActionBtn.Click -= MoveClick;
                }
            }

            _MainForm.Instance.Refresh();
        }
        #endregion

        #region Inspect Menhir
        private static void InspectMenhirActionClick(object sender, EventArgs e)
        {
            var l = LocationsHelper.GetLCControl(((LocationSelectionButton)sender).LocationNumber);
            MenhirHelper.GetMenhirActivationDescription(l);
        }
        #endregion

        #region Location Action
        static void LocationActionClick(object sender, EventArgs e)
        {
            CombatManager.Start();
            ActionFinished.Invoke();
        }
        #endregion

        #region Exploration
        static void ExplorationActionClick(object sender, EventArgs e)
        {
            ExplorationManager.StartExploration(Game.Instance.ActivePlayer.CurrentLocation);
            ActionFinished.Invoke();
        }

        #endregion

        #region Pass
        static void PassClick(object sender, EventArgs e)
        {
            Game.Instance.PlayerPassed();
           ActionFinished.Invoke();
        }
        #endregion
    }
}