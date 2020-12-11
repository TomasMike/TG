using System;
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
        public static LocationCardControl GetLCControlInPlay(int number)
        {
            return _MainForm.Instance.LocationCardsPanel.LocationCards.FirstOrDefault(_ => _.LocationNumber == number);
        }

        public static LocationCardControl GetLCControl(int number)
        {
            return LocationsLib.Locations.First(_ => _.LocationNumber == number);
        }
        #endregion

        #region neighbouring locations
        public static IEnumerable<int> GetNeighbourLocationNumbers(LocationCardControl lcc)
        {
            var retVal = new List<int>() { lcc.NorthDirectionKey, lcc.EastDirectionKey, lcc.SouthDirectionKey, lcc.WestDirectionKey };
            retVal.RemoveAll(_ => _ == 0);
            return retVal;
        }

        public static IEnumerable<int> GetNeighbourLocationNumbers(int locationNumber)
        {
            var lcc = GetLCControl(locationNumber);
            var retVal = new List<int>() { lcc.NorthDirectionKey, lcc.EastDirectionKey, lcc.SouthDirectionKey, lcc.WestDirectionKey };
            retVal.RemoveAll(_ => _ == 0);
            return retVal;
        }

        public static IEnumerable<LocationCardControl> GetNeighbourLCCs(int locationNumber)
        {
            var lcc = GetLCControl(locationNumber);
            var retVal = new List<LocationCardControl>()
            {
               GetLCControl(lcc.NorthDirectionKey),
               GetLCControl(lcc.EastDirectionKey),
               GetLCControl(lcc.SouthDirectionKey),
               GetLCControl(lcc.WestDirectionKey)
            };
            retVal.RemoveAll(_ => _ == null);
            return retVal;
        }

        public static IEnumerable<LocationCardControl> GetNeighbourLCCs(LocationCardControl lcc, bool returnOnlyInPlayLocations = false)
        {
            var retVal = new List<LocationCardControl>()
            {
               returnOnlyInPlayLocations ? GetLCControlInPlay(lcc.NorthDirectionKey) : GetLCControl(lcc.NorthDirectionKey),
               returnOnlyInPlayLocations ? GetLCControlInPlay(lcc.EastDirectionKey)  : GetLCControl(lcc.EastDirectionKey),
               returnOnlyInPlayLocations ? GetLCControlInPlay(lcc.SouthDirectionKey) : GetLCControl(lcc.SouthDirectionKey),
               returnOnlyInPlayLocations ? GetLCControlInPlay(lcc.WestDirectionKey)  : GetLCControl(lcc.WestDirectionKey)
            };
            retVal.RemoveAll(_ => _ == null);
            return retVal;
        }

        #endregion


        public static bool IsLocationNearActiveMenhir(int locationNumber)
        {
            return GetSurroundingLCCInPlay(locationNumber).Any(_ => _.MenhirValue >= 0) || GetLCControl(locationNumber).MenhirValue >= 0;
        }


        public static IEnumerable<int> GetSurroundingLocationsNumbers(int locationNumber)
        {
            var locs = new Dictionary<string, LocationCardControl>
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

            var middleLoc = GetLCControl(locationNumber);

            //get locations in cardinal
            locs["Top"] =          middleLoc.NorthDirectionKey != 0 ? GetLCControl(middleLoc.NorthDirectionKey) : null;
            locs["CenterLeft"] =   middleLoc.WestDirectionKey != 0 ?  GetLCControl(middleLoc.WestDirectionKey) :  null;
            locs["CenterRight"] =  middleLoc.EastDirectionKey != 0 ?  GetLCControl(middleLoc.EastDirectionKey) :  null;
            locs["Bottom"] =       middleLoc.SouthDirectionKey != 0 ? GetLCControl(middleLoc.SouthDirectionKey) : null;

            // get corner locations from cardinals
            if(locs["Top"] != null)
            {
                locs["TopLeft"] = locs["TopLeft"] ?? (locs["Top"].WestDirectionKey != 0 ? GetLCControl(locs["Top"].WestDirectionKey) : null);
                locs["TopRight"] = locs["TopRight"] ?? (locs["Top"].EastDirectionKey != 0 ? GetLCControl(locs["Top"].EastDirectionKey) : null);
            }

            if (locs["CenterLeft"] != null)
            {
                locs["TopLeft"] = locs["TopLeft"] ?? (locs["CenterLeft"].NorthDirectionKey != 0 ? GetLCControl(locs["CenterLeft"].NorthDirectionKey) : null);
                locs["BottomLeft"] = locs["BottomLeft"] ?? (locs["CenterLeft"].SouthDirectionKey != 0 ? GetLCControl(locs["CenterLeft"].SouthDirectionKey) : null);
            }

            if (locs["CenterRight"] != null)
            {
                locs["TopRight"] = locs["TopRight"] ?? (locs["CenterRight"].NorthDirectionKey != 0 ? GetLCControl(locs["CenterRight"].NorthDirectionKey) : null);
                locs["BottomRight"] = locs["BottomRight"] ?? (locs["CenterRight"].SouthDirectionKey != 0 ? GetLCControl(locs["CenterRight"].SouthDirectionKey) : null);
            }

            if (locs["Bottom"] != null)
            {
                locs["BottomLeft"] = locs["BottomLeft"] ?? (locs["Bottom"].EastDirectionKey != 0 ? GetLCControl(locs["Bottom"].EastDirectionKey) : null);
                locs["BottomRight"] = locs["BottomRight"] ?? (locs["Bottom"].WestDirectionKey != 0 ? GetLCControl(locs["Bottom"].WestDirectionKey) : null);
            }

            return locs.Values.Where(_ => _ != null).Select(_ => _.LocationNumber);
        }



        public static IEnumerable<LocationCardControl> GetSurroundingLCCInPlay(LocationCardControl lcc)
        {
            return GetSurroundingLocationsNumbers(lcc.LocationNumber).Select(_ => GetLCControlInPlay(_)).Where(_ => _ != null);
        }

        public static IEnumerable<LocationCardControl> GetSurroundingLCCInPlay(int locationNumber)
        {
            return GetSurroundingLocationsNumbers(locationNumber).Select(_ => GetLCControlInPlay(_)).Where(_ => _ != null);
        }

        //public static IEnumerable<LocationCardControl> GetSurroundingLocationsInPlay(int locationNumber)
        //{
        //    return GetSurroundingLocationsNumbers(locationNumber).Select(_ => GetLCControlFromLocationNumberOrNull(_)).Where(_ => _ != null);
        //}
    }
}