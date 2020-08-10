using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TG.Enums;
using TG.SavingLoading;

namespace TG.CustomControls
{
    public class LocationCardControl : Panel
    {
        public Label NLabel = new Label();
        public Label ELabel = new Label();
        public Label SLabel = new Label();
        public Label WLabel = new Label();

        public TableLayoutPanel LocationDescriptionControlsArea = new TableLayoutPanel();
        public TableLayoutPanel LocationPlayersGuardiansArea = new TableLayoutPanel();
        public Label LocationNameNumber = new Label();
        public LocationSelectionButton LocationActionBtn = new LocationSelectionButton();

        public IEnumerable<Player> PlayersInLocation => SaveManager.CurrentSaveSheet.Players.Where(_ => _.CurrentLocation == LocationNumber);
        public List<Button> ButtonsToDisplay = new List<Button>();

        private Size directionLabelSize = TextRenderer.MeasureText("000", DefaultFont);

        public LocationCardControl()
        {
            BackColor = Color.DarkSeaGreen;
            TabIndex = 1;
            Size = new Size(180, 180);
            MenhirValue = -1;

            Controls.Add(LocationDescriptionControlsArea);
        }
        public LocationCardControl(int locationNumber, string locationName, int northDirectionKey, int eastDirectionKey, int southDirectionKey, int westDirectionKey)
    : this()
        {
            NorthDirectionKey = northDirectionKey;
            EastDirectionKey = eastDirectionKey;
            SouthDirectionKey = southDirectionKey;
            WestDirectionKey = westDirectionKey;
        }


        public LocationCardControl Init()
        {
            LocationNameNumber.Text = $"{LocationNumber} - {LocationName}";
            LocationNameNumber.TextAlign = ContentAlignment.TopCenter;
            LocationNameNumber.Dock = DockStyle.Fill;
            //LocationNameNumber.BackColor = Color.Yellow;
            LocationNameNumber.AutoSize = true;

            LocationDescriptionControlsArea.Location = new Point(directionLabelSize.Width, directionLabelSize.Height);
            LocationDescriptionControlsArea.Size = new Size(Width - directionLabelSize.Width * 2, Height - directionLabelSize.Height * 2);
            LocationDescriptionControlsArea.ColumnCount = 1;

            LocationPlayersGuardiansArea.ColumnCount = 1;
            LocationPlayersGuardiansArea.Size = new Size(Width - directionLabelSize.Width * 2, Height - directionLabelSize.Height * 2);
            LocationPlayersGuardiansArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));

            LocationDescriptionControlsArea.Controls.Add(LocationNameNumber, 0, 0);
            LocationDescriptionControlsArea.Controls.Add(LocationActionBtn, 0, 1);

            LocationDescriptionControlsArea.Controls.Add(LocationPlayersGuardiansArea, 0, 2);

            LocationActionBtn.Hide();
            LocationActionBtn.LocationNumber = LocationNumber;

            RefreshLocationDescriptionArea();

            Paint += (sender, e) => { RefreshLocationDescriptionArea(); };

            if (NorthDirectionKey != 0)
            {
                NLabel.Text = NorthDirectionKey.ToString();
                NLabel.Location = new Point(Width / 2 - directionLabelSize.Width / 2, 0);
                Controls.Add(NLabel);
            }

            if (EastDirectionKey != 0)
            {
                ELabel.Text = EastDirectionKey.ToString();
                ELabel.Location = new Point(Width - directionLabelSize.Width, Height / 2 - directionLabelSize.Height / 2);
                Controls.Add(ELabel);
            }

            if (SouthDirectionKey != 0)
            {
                SLabel.Text = SouthDirectionKey.ToString();
                SLabel.Location = new Point(Width / 2 - directionLabelSize.Width / 2, Height - directionLabelSize.Height);
                Controls.Add(SLabel);
            }

            if (WestDirectionKey != 0)
            {
                WLabel.Text = WestDirectionKey.ToString();
                WLabel.Location = new Point(0, Height / 2 - directionLabelSize.Height / 2);
                Controls.Add(WLabel);
            }

            return this;
        }

        private void RefreshLocationDescriptionArea()
        {
            LocationPlayersGuardiansArea.Controls.Clear();

            foreach (var b in ButtonsToDisplay)
            {
                LocationPlayersGuardiansArea.Controls.Add(b);
            }

            foreach (var item in PlayersInLocation)
            {
                var l = new Label();
                l.Text = $"{item.PlayerNumber} {item.Name}-{item.Character.CharacterName}";
                l.TextAlign = ContentAlignment.TopCenter;
                l.Dock = DockStyle.Top;
                if (Game.Instance.ActivePlayerNumber == item.PlayerNumber)
                    l.BackColor = Color.Orange;
                LocationPlayersGuardiansArea.Controls.Add(l);
            }
        }





        public int NorthDirectionKey;
        public int EastDirectionKey;
        public int SouthDirectionKey;
        public int WestDirectionKey;

        public string LocationName;
        public int LocationNumber;
        public string LegacyLocationNumber;

        public bool CanHaveMenhir;

        /// <summary>
        /// If the location doesnt have a menhir its -1
        /// </summary>
        public int MenhirValue;

        public LocationSetlementTypeEnum LocationSetlementType;
        public bool Dreams;
        public object LocationAction;//TODO
    }
}