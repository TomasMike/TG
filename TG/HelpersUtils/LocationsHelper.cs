using System.Collections.Generic;
using System.Linq;
using TG.CustomControls;
using TG.Forms;

namespace TG.HelpersUtils
{
    public static class LocationsHelper
    {
        public static List<int> GetNeighbourLocationNumbers(LocationCardControl lcc)
        {
            var retVal = new List<int>() { lcc.NorthDirectionKey, lcc.EastDirectionKey, lcc.SouthDirectionKey, lcc.WestDirectionKey };
            retVal.RemoveAll(_ => _ == 0);
            return retVal;
        }

        public static LocationCardControl GetLCControlFromLocationNumber(int number)
        {
            return _MainForm.Instance.Mp.LocationCards.First(_ => _.LocationNumber == number);
        }
    }
}