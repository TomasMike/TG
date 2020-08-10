using System.Collections.Generic;
using TG.CustomControls;
using TG.Enums;

namespace TG.Libs
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
                        WestDirectionKey = 103,
                        SouthDirectionKey = 105,
                        EastDirectionKey = 104,
                        CanHaveMenhir = true,
                        LocationSetlementType = LocationSetlementTypeEnum.FriendlySettlement,
                        Dreams = true,
                        LocationAction = new object()
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Hunters Grove",
                        LocationNumber = 102,
                        NorthDirectionKey = 113,
                        WestDirectionKey = 106,
                        SouthDirectionKey = 101,
                        EastDirectionKey = 107,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new object()
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Warriors Refuge",
                        LocationNumber = 103,
                        WestDirectionKey = 118,
                        SouthDirectionKey = 108,
                        EastDirectionKey = 101,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new object()
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Burned Thing",
                        LocationNumber = 104,
                        NorthDirectionKey = 107,
                        WestDirectionKey = 101,
                        SouthDirectionKey = 109,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new object()
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Forlorn Swords",
                        LocationNumber = 105,
                        NorthDirectionKey = 101,
                        WestDirectionKey = 108,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new object()
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Some Haunted Place",
                        LocationNumber = 106,
                        NorthDirectionKey = 112,
                        WestDirectionKey = 116,
                        EastDirectionKey = 102,
                        CanHaveMenhir = true,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new object()
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Whitening",
                        LocationNumber = 107,
                        NorthDirectionKey = 114,
                        WestDirectionKey = 102,
                        SouthDirectionKey = 104,
                        EastDirectionKey = 117,
                        CanHaveMenhir = true,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object()
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Pavuci les?",
                        LocationNumber = 108,
                        NorthDirectionKey = 103,
                        WestDirectionKey = 120,
                        EastDirectionKey = 105,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new object()
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Crazy Alcatraz?",
                        LocationNumber = 109,
                        NorthDirectionKey = 104,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new object()
                    }.Init(),
                });
            private set => _locations = value;
        }
    }
}