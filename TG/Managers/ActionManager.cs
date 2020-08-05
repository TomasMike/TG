using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TG.CustomControls;
using TG.Forms;
using TG.HelpersUtils;

namespace TG.Managers
{
    public static class ActionManager
    {
        private static List<MainActionButton> mainActionButtons = new List<MainActionButton>();

        private static bool IsTravelModeEnabled = false;

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
            mainActionButtons.ForEach(_ => _.Enabled = false);
            var b = mainActionButtons.First(_ => _.ActionType == ActionType.Travel);
            b.Enabled = true;
            b.Text = "Cancel Travel";

            foreach (var item in LocationsHelper.GetNeighbourLocationNumbers(Game.Instance.ActivePlayer.CurrentLocationCard))
            {

            } 
        }

        public static void DisableMoveMode()
        {
            var b = mainActionButtons.First(_ => _.ActionType == ActionType.Travel);

            b.Text = "Travel";
        }
    }
}