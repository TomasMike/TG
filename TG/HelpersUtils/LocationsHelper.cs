using System.Collections.Generic;
using System.Linq;
using TG.CustomControls;
using TG.Forms;
using TG.Libs;
using TG.PlayerCharacterItems;

namespace TG.HelpersUtils
{
    public static class LocationsHelper
    {
        #region location int -> location LCC
        public static LocationCardControl GetLCControlInPlayFromLocationNumber(int number)
        {
            return _MainForm.Instance.LocationCardsPanel.LocationCards.FirstOrDefault(_ => _.LocationNumber == number);
        }

        public static LocationCardControl GetLCControlFromLocationNumber(int number)
        {
            return LocationsLib.Locations.First(_ => _.LocationNumber == number);
        }
        #endregion

        #region neighbouring locations
        //public static IEnumerable<int> GetNeighbourLocationNumbers(LocationCardControl lcc)
        //{
        //    var retVal = new List<int>() { lcc.NorthDirectionKey, lcc.EastDirectionKey, lcc.SouthDirectionKey, lcc.WestDirectionKey };
        //    retVal.RemoveAll(_ => _ == 0);
        //    return retVal;
        //}

        #endregion






        //public static IEnumerable<int> GetNeighbourLocationNumbers(int locationNumber)
        //{
        //    return GetNeighbourLocationNumbers(GetLCControlFromLocationNumber(locationNumber));
        //}



        //public static LocationCardControl GetLCControlInPFromLocationNumber(int number)
        //{
        //    return _MainForm.Instance.LocationCardsPanel.LocationCards.FirstOrDefault(_ => _.LocationNumber == number);
        //}

        //public static bool IsLocationNearActiveMenhir(int locationNumber)
        //{
        //    foreach (var item in GetSurroundingLocationsInPlay())
        //    {
        //        if (GetSurroundingLocationsNumbers(item.LocationNumber).Contains(locationNumber))
        //            return true;
        //    }

        //    return false;
        //}

        //public static IEnumerable<LocationCardControl> GetSurroundingLocationsInPlay()
        //{
        //    return _MainForm.Instance.LocationCardsPanel.LocationCards.Where(location => location.MenhirValue >= 0);
        //}

        public static IEnumerable<int> GetSurroundingLocationsNumbers(int locationNumber)
        {
            var retVal = new HashSet<int>();
            var d = new Dictionary<string, LocationCardControl>
            {
                {"TopLeft",null },
                {"Top",null },
                {"TopRight",null },
                {"CenterLeft",null },
                {"CenterRight",null },
                {"BottomLeft",null },
                {"Bottom",null },
                {"BottomRight",null },
            };

            var middleLoc = GetLCControlFromLocationNumber(locationNumber);

            //get locations in cardinal
            d["Top"] =          middleLoc.NorthDirectionKey != 0 ? GetLCControlFromLocationNumber(middleLoc.NorthDirectionKey) : null;
            d["CenterLeft"] =   middleLoc.WestDirectionKey != 0 ?  GetLCControlFromLocationNumber(middleLoc.WestDirectionKey) :  null;
            d["CenterRight"] =  middleLoc.EastDirectionKey != 0 ?  GetLCControlFromLocationNumber(middleLoc.EastDirectionKey) :  null;
            d["Bottom"] =       middleLoc.SouthDirectionKey != 0 ? GetLCControlFromLocationNumber(middleLoc.SouthDirectionKey) : null;

            // get corner locations from cardinals
            if(d["Top"] != null)
            {
                d["TopLeft"] = d["TopLeft"] ?? (d["Top"].WestDirectionKey != 0 ? GetLCControlFromLocationNumber(d["Top"].WestDirectionKey) : null);
                d["TopRight"] = d["TopRight"] ?? (d["Top"].EastDirectionKey != 0 ? GetLCControlFromLocationNumber(d["Top"].EastDirectionKey) : null);
            }

            if (d["CenterLeft"] != null)
            {
                d["TopLeft"] = d["TopLeft"] ?? (d["CenterLeft"].NorthDirectionKey != 0 ? GetLCControlFromLocationNumber(d["CenterLeft"].NorthDirectionKey) : null);
                d["BottomLeft"] = d["BottomLeft"] ?? (d["CenterLeft"].SouthDirectionKey != 0 ? GetLCControlFromLocationNumber(d["CenterLeft"].SouthDirectionKey) : null);
            }

            if (d["CenterRight"] != null)
            {
                d["TopRight"] = d["TopRight"] ?? (d["CenterRight"].NorthDirectionKey != 0 ? GetLCControlFromLocationNumber(d["CenterRight"].NorthDirectionKey) : null);
                d["BottomRight"] = d["BottomRight"] ?? (d["CenterRight"].SouthDirectionKey != 0 ? GetLCControlFromLocationNumber(d["CenterRight"].SouthDirectionKey) : null);
            }

            if (d["Bottom"] != null)
            {
                d["BottomLeft"] = d["BottomLeft"] ?? (d["Bottom"].EastDirectionKey != 0 ? GetLCControlFromLocationNumber(d["Bottom"].EastDirectionKey) : null);
                d["BottomRight"] = d["BottomRight"] ?? (d["Bottom"].WestDirectionKey != 0 ? GetLCControlFromLocationNumber(d["Bottom"].WestDirectionKey) : null);
            }


            return retVal;
        }

        //public static IEnumerable<LocationCardControl> GetSurroundingLocationsInPlay(int locationNumber)
        //{
        //    return GetSurroundingLocationsNumbers(locationNumber).Select(_ => GetLCControlFromLocationNumberOrNull(_)).Where(_ => _ != null);
        //}
    }
}