using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using TG.Enums;

namespace TG
{
    public class LocationCardControl : Button
    {
        public LocationCardControl()
        {
            Size = new Size(60, 120);
            UseVisualStyleBackColor = true;
            Text = LocationName;

        }

        public LocationCardControl(int locationNumber, string locationName, int northDirectionKey, int eastDirectionKey, int southDirectionKey, int westDirectionKey)
            : this()
        {
            NorthDirectionKey = northDirectionKey;
            EastDirectionKey = eastDirectionKey;
            SouthDirectionKey = southDirectionKey;
            WestDirectionKey = westDirectionKey;

            LocationNumber = locationNumber;
            LocationName = locationName;
            Name = LocationName;
            TabIndex = 0;
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


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (NorthDirectionKey != 0)
                e.Graphics.DrawString(NorthDirectionKey.ToString(), Font, new SolidBrush(ForeColor), Width / 2 - (e.Graphics.MeasureString(NorthDirectionKey.ToString(), Font).Width / 2), 1);
            if (SouthDirectionKey != 0)
                e.Graphics.DrawString(SouthDirectionKey.ToString(), Font, new SolidBrush(ForeColor), Width / 2 - (e.Graphics.MeasureString(SouthDirectionKey.ToString(), Font).Width / 2), Height - Font.Height);
            if (WestDirectionKey != 0)
                e.Graphics.DrawString(WestDirectionKey.ToString(), Font, new SolidBrush(ForeColor), 1, (Height / 2) - (FontHeight / 2));
            if (EastDirectionKey != 0)
                e.Graphics.DrawString(EastDirectionKey.ToString(), Font, new SolidBrush(ForeColor), Width - e.Graphics.MeasureString(EastDirectionKey.ToString(), Font).Width, (Height / 2) - (FontHeight / 2));


        }

        public List<int> GetNeighbourLocationNumbers()
        {
            var retVal = new List<int>() { NorthDirectionKey, EastDirectionKey, SouthDirectionKey, WestDirectionKey };
            retVal.RemoveAll(_ => _ != 0);
            return retVal;
        }
    }
}