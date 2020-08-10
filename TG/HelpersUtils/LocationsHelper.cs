using System.Collections.Generic;
using System.Linq;
using TG.CustomControls;
using TG.Forms;

namespace TG.HelpersUtils
{
    public static class LocationsHelper
    {
        public static IEnumerable<int> GetNeighbourLocationNumbers(LocationCardControl lcc)
        {
            var retVal = new List<int>() { lcc.NorthDirectionKey, lcc.EastDirectionKey, lcc.SouthDirectionKey, lcc.WestDirectionKey };
            retVal.RemoveAll(_ => _ == 0);
            return retVal;
        }

        public static IEnumerable<int> GetNeighbourLocationNumbers(int locationNumber)
        {
            return GetNeighbourLocationNumbers(GetLCControlFromLocationNumber(locationNumber));
        }


        public static LocationCardControl GetLCControlFromLocationNumber(int number)
        {
            return _MainForm.Instance.Mp.LocationCards.First(_ => _.LocationNumber == number);
        }

        public static bool IsLocationNearActiveMenhir(int locationNumber)
        {
            foreach (var item in GetLocationsWithActiveMenhir())
            {
                if (GetSurroundingLocationsNumbers(item.LocationNumber).Contains(locationNumber))
                    return true;
            }

            return false;
        }

        public static IEnumerable<LocationCardControl> GetLocationsWithActiveMenhir()
        {
           return _MainForm.Instance.Mp.LocationCards.Where(location => location.MenhirValue >= 0);
        }

        public static IEnumerable<int> GetSurroundingLocationsNumbers(int locationNumber)
        {
            var retVal = new HashSet<int>();

            var middleLoc = GetLCControlFromLocationNumber(locationNumber);

            foreach (var item in new int[] { middleLoc.NorthDirectionKey,middleLoc.SouthDirectionKey})
            {
                if(item != 0)
                {
                    retVal.Add(item);
                    var NS_Loc = GetLCControlFromLocationNumber(item);

                    foreach (var item2 in new int[] { NS_Loc.WestDirectionKey, NS_Loc.EastDirectionKey})
                    {
                        if(item2 != 0)
                        {
                            retVal.Add(item2);
                        }
                    }
                }
            }

            foreach (var item in new int[] { middleLoc.WestDirectionKey, middleLoc.EastDirectionKey })
            {
                if (item != 0)
                {
                    retVal.Add(item);
                    var WE_Loc = GetLCControlFromLocationNumber(item);

                    foreach (var item2 in new int[] { WE_Loc.NorthDirectionKey, WE_Loc.SouthDirectionKey })
                    {
                        if (item2 != 0)
                        {
                            retVal.Add(item2);
                        }
                    }
                }
            }

            return retVal;
        }

        public static IEnumerable<LocationCardControl> GetSurroundingLocations(int locationNumber)
        {
            return GetSurroundingLocationsNumbers(locationNumber).Select(_ => GetLCControlFromLocationNumber(_));
        }
    }
}