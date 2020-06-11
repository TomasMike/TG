using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using TG.Enums;

namespace TG
{
    [DebuggerDisplay("{LocationNumber}", Name = "{LocationName}")]
    public class LocationCardControl : Button
    {
        public LocationCardControl()
        {
        

        }

        public LocationCardControl(string locationNumber, string locationName, string northDirectionKey, string eastDirectionKey, string southDirectionKey, string westDirectionKey)
        {
            Size = new Size(100,100);
            NorthDirectionKey = northDirectionKey;
            EastDirectionKey = eastDirectionKey;
            SouthDirectionKey = southDirectionKey;
            WestDirectionKey = westDirectionKey;

            LocationNumber = locationNumber;
            LocationName = locationName;
            Name = LocationName;
            Size = new System.Drawing.Size(117, 128);
            TabIndex = 0;
            Text = LocationName;
        }

        public string NorthDirectionKey;
        public string EastDirectionKey;
        public string SouthDirectionKey;
        public string WestDirectionKey;

        public string LocationName;
        public string LocationNumber;
        public string LegacyLocationNumber;

        public bool CanHaveMenhir;
        public LocationSetlementTypeEnum LocationSetlementType;
        public bool Dreams;
        public object LocationAction;//TODO


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!string.IsNullOrEmpty(NorthDirectionKey))
                e.Graphics.DrawString(NorthDirectionKey, Font, new SolidBrush(ForeColor), Width / 2 - (e.Graphics.MeasureString(NorthDirectionKey, Font).Width / 2), 1);
            if (!string.IsNullOrEmpty(SouthDirectionKey))
                e.Graphics.DrawString(SouthDirectionKey, Font, new SolidBrush(ForeColor), Width / 2 - (e.Graphics.MeasureString(SouthDirectionKey, Font).Width / 2), Height - Font.Height);
            if (!string.IsNullOrEmpty(WestDirectionKey))
                e.Graphics.DrawString(WestDirectionKey, Font, new SolidBrush(ForeColor), 1, (Height / 2) - (FontHeight / 2));
            if (!string.IsNullOrEmpty(EastDirectionKey))
                e.Graphics.DrawString(EastDirectionKey, Font, new SolidBrush(ForeColor), Width - e.Graphics.MeasureString(EastDirectionKey, Font).Width, (Height / 2) - (FontHeight / 2));
        }
    }
}