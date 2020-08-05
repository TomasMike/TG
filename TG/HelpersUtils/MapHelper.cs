using System.Collections.Generic;
using System.Linq;
using TG.CustomControls;
using TG.Forms;

namespace TG
{
    public static class MapHelper
    {
        public static List<LocationCardControl> GetSurroundingLocations(LocationCardControl lcc)
        {
            var retval = new List<LocationCardControl>();
            var n = _MainForm.Instance.Mp.LocationCards.FirstOrDefault(_ => _.LocationNumber == lcc.LocationNumber);
            var e = _MainForm.Instance.Mp.LocationCards.FirstOrDefault(_ => _.LocationNumber == lcc.LocationNumber);
            var s = _MainForm.Instance.Mp.LocationCards.FirstOrDefault(_ => _.LocationNumber == lcc.LocationNumber);
            var w = _MainForm.Instance.Mp.LocationCards.FirstOrDefault(_ => _.LocationNumber == lcc.LocationNumber);

            if (n != null)
                retval.AddRange(_MainForm.Instance.Mp.LocationCards.Where(_ =>
                    _.LocationNumber == n.WestDirectionKey || _.LocationNumber == n.EastDirectionKey));

            if (e != null)
                retval.AddRange(_MainForm.Instance.Mp.LocationCards.Where(_ =>
                    _.LocationNumber == e.NorthDirectionKey || _.LocationNumber == e.SouthDirectionKey));

            if (s != null)
                retval.AddRange(_MainForm.Instance.Mp.LocationCards.Where(_ =>
                    _.LocationNumber == s.WestDirectionKey || _.LocationNumber == s.EastDirectionKey));

            if (w != null)
                retval.AddRange(_MainForm.Instance.Mp.LocationCards.Where(_ =>
                    _.LocationNumber == w.NorthDirectionKey || _.LocationNumber == w.SouthDirectionKey));

            return retval;
        }
    }
}