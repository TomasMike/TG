using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TG.CustomControls;
using TG.Forms;
using TG.HelpersUtils;
using TG.SavingLoading;

namespace TG.Managers
{
    public static class ActionManager
    {
        private static List<MainActionButton> mainActionButtons = new List<MainActionButton>();

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

            mainActionButtons.First(_ => _.ActionType == ActionType.Travel).Click += TravelActionClick;

            //
            ActionFinished += ActionManager_ActionFinished;
            //
        }

        private static void ActionManager_ActionFinished()
        {
            SaveManager.Save();
        }

        private static void TravelActionClick(object sender, EventArgs e)
        {
            if (IsTravelModeEnabled)
                DisableMoveMode();
            else
                EnableMoveMode();

        }

        public static void EnableMoveMode()
        {
            IsTravelModeEnabled = !IsTravelModeEnabled;

            mainActionButtons.ForEach(_ => { if (_.ActionType != ActionType.Travel) _.Disable(); });
            var b = mainActionButtons.First(_ => _.ActionType == ActionType.Travel);
            b.Enable();
            b.Text = "Cancel Travel";

            foreach (var item in LocationsHelper.GetNeighbourLocationNumbers(Game.Instance.ActivePlayer.CurrentLocationCard))
            {
                var l = LocationsHelper.GetLCControlFromLocationNumber(item);
                l.LocationActionBtn.Show();
                l.LocationActionBtn.Text = "Move Here";
                l.LocationActionBtn.Click += MoveClick;
            }
            _MainForm.Instance.Refresh();
        }

        static void MoveClick(object sender, EventArgs e)
        {
            var p = Game.Instance.ActivePlayer;
            p.Character.CurrentEnergy--;
            p.CurrentLocation = ((LocationSelectionButton)sender).LocationNumber;
            _MainForm.Instance.Mp.AddMissingLocationsAfterTravel(p.CurrentLocation);
            DisableMoveMode();
            ActionFinished.Invoke();
        }

        public static void DisableMoveMode()
        {
            IsTravelModeEnabled = !IsTravelModeEnabled;

            mainActionButtons.ForEach(_ => _.Enable());
            var b = mainActionButtons.First(_ => _.ActionType == ActionType.Travel);

            b.Text = "Travel";

            foreach (var item in _MainForm.Instance.Mp.LocationCards)
            {
                var l = LocationsHelper.GetLCControlFromLocationNumber(item.LocationNumber);
                if(l.LocationActionBtn.Visible)
                {
                    l.LocationActionBtn.Hide();
                    l.LocationActionBtn.Click -= MoveClick;
                }
            }

            _MainForm.Instance.Refresh();
        }
    }
}