using System.Collections.Generic;
using TG.Enums;

namespace TG.Forms
{
    public static class LocationsLib
    {
        private static List<LocationCardControl> _locations;
        public static List<LocationCardControl> Locations
        {
            get =>
                _locations ?? (_locations = new List<LocationCardControl>
                {
                    new LocationCardControl()
                    {
                        LocationName = "Cuanacht",
                        LocationNumber = 101,
                        NorthDirectionKey = 102,
                        SouthDirectionKey = 103,
                        WestDirectionKey = 104,
                        EastDirectionKey = 105,
                        CanHaveMenhir = true,
                        LocationSetlementType = LocationSetlementTypeEnum.FriendlySettlement,
                        Dreams = true,
                        LocationAction = new object()
                    },
                    new LocationCardControl()
                    {
                        LocationName = "Hunters Grove",
                        LocationNumber = 102,
                        SouthDirectionKey = 101,
                        CanHaveMenhir = true,
                        LocationSetlementType = LocationSetlementTypeEnum.FriendlySettlement,
                        Dreams = true,
                        LocationAction = new object()
                    },
                    new LocationCardControl()
                    {
                        LocationName = "Forlorn Swords",
                        LocationNumber = 103,
                        NorthDirectionKey = 101,
                        CanHaveMenhir = true,
                        LocationSetlementType = LocationSetlementTypeEnum.FriendlySettlement,
                        Dreams = true,
                        LocationAction = new object()
                    },
                    new LocationCardControl()
                    {
                        LocationName = "Warriors Refuge",
                        LocationNumber = 104,
                        EastDirectionKey = 101,
                        CanHaveMenhir = true,
                        LocationSetlementType = LocationSetlementTypeEnum.FriendlySettlement,
                        Dreams = true,
                        LocationAction = new object()
                    },
                    new LocationCardControl()
                    {
                        LocationName = "Burned Thing",
                        LocationNumber = 105,
                        WestDirectionKey = 101,
                        CanHaveMenhir = true,
                        LocationSetlementType = LocationSetlementTypeEnum.FriendlySettlement,
                        Dreams = true,
                        LocationAction = new object()
                    },
                });
            private set => _locations = value;
        }
    }
}