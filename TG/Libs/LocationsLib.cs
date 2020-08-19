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
                        LocationName = "Cuanacht Farmhold",
                        LocationNumber = 101,
                        NorthDirectionKey = 102,
                        WestDirectionKey = 103,
                        SouthDirectionKey = 105,
                        EastDirectionKey = 104,
                        CanHaveMenhir = true,
                        LocationSetlementType = LocationSetlementTypeEnum.FriendlySettlement,
                        Dreams = true,
                        LocationAction = new object() //1energy -> 1rep(1 per day)
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Hunters' Grove",
                        LocationNumber = 102,
                        //NorthDirectionKey = 113,
                        WestDirectionKey = 106,
                        SouthDirectionKey = 101,
                        EastDirectionKey = 107,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new object()//2e -> 2food + green encounter
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Warrior Fair",
                        LocationNumber = 103,
                        //WestDirectionKey = 118,
                        SouthDirectionKey = 108,
                        EastDirectionKey = 101,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        LocationAction = new object()//4e -> -1hp +1exp(1 per day)
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Charred Conclave",
                        LocationNumber = 104,
                        NorthDirectionKey = 107,
                        WestDirectionKey = 101,
                        SouthDirectionKey = 109,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new object()//none //on enter gray enc
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Forlorn Swords",
                        LocationNumber = 105,
                        NorthDirectionKey = 101,
                        WestDirectionKey = 108,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new object()//1e -> -1 wealth, draw 1 craftable item
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Fore-dweller Mounds",
                        LocationNumber = 106,
                        //NorthDirectionKey = 112,
                        //WestDirectionKey = 116,
                        EastDirectionKey = 102,
                        CanHaveMenhir = true,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new object()//2e -> +1terror,1wealth...zloztite
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Whitening",
                        LocationNumber = 107,
                        //NorthDirectionKey = 114,
                        WestDirectionKey = 102,
                        SouthDirectionKey = 104,
                        //EastDirectionKey = 117,
                        CanHaveMenhir = true,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object()
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Grubwood",
                        LocationNumber = 108,
                        NorthDirectionKey = 103,
                        //WestDirectionKey = 120,
                        EastDirectionKey = 105,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        LocationAction = new object()
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Island Asylum",
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