using System.Collections.Generic;
using TG.CustomControls;
using TG.Enums;
using TG.Locations;

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
                        LocationSetlementType = LocationSetlementTypeEnum.FriendlySettlement,
                        Dreams = true,
                        CanDoLocationAction = a => Game.Instance.ActivePlayer.Character.CurrentEnergy >= 1,
                        LocationAction = new LocationAction
                        {
                            Description = "Chores for the townsfolk: Gain 1 Rep (once per day)",
                            Action = a => 
                            {
                                Game.Instance.ActivePlayer.Character.CurrentEnergy--;
                                Game.Instance.ActivePlayer.Character.Reputation++;
                            }
                        },
                        LocationCanHaveMenhir = true,
                        MenhirActivationRequirementsDescription = 
                        CanActivateMenhir = 
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
                        LocationCanHaveMenhir = true,
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
                        LocationCanHaveMenhir = true,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object()//1e -> -1 food, +1 wealth
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Grubwood",
                        LocationNumber = 108,
                        NorthDirectionKey = 103,
                        //WestDirectionKey = 120,
                        EastDirectionKey = 105,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Island Asylum",
                        LocationNumber = 109,
                        NorthDirectionKey = 104,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new object()//1e -> -1w, +3hp
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Haunted Grubwood",
                        LocationNumber = 110,
                        LegacyLocationNumber = 108,
                        NorthDirectionKey = 103,
                        //WestDirectionKey = 120,
                        EastDirectionKey = 105,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new object(),//1e -> +1 terror +1 food
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Underwall",
                        LocationCanHaveMenhir = true,
                        LocationNumber = 111,
                        NorthDirectionKey = 131,
                        EastDirectionKey = 112,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        LocationAction = new object(),//2e -> +2 food, green encounter
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Bloodied Glen",
                        LocationNumber = 112,
                        NorthDirectionKey = 132,
                        WestDirectionKey = 111,
                        SouthDirectionKey = 106,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        LocationAction = new object(),//1e -> -1 rep or +1 terror, +1 wealth
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Mirror Lake",
                        LocationNumber = 113,
                        SouthDirectionKey = 102,
                        EastDirectionKey= 114,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        LocationAction = new object(),//0e -> +1 energy +1hp -1 terror 1perday

                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Tangleroot",
                        LocationNumber = 114,
                        EastDirectionKey= 115,
                        WestDirectionKey = 113,
                        SouthDirectionKey = 107,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new object(),//2e -> +2 food, green enc
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Titans' Steps",
                        LocationNumber = 115,
                        WestDirectionKey = 114,
                        SouthDirectionKey = 117,
                        EastDirectionKey= 138,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        LocationCanHaveMenhir = true,
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "Farshire",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "First Farmhold",
                        LocationNumber = 117,
                        NorthDirectionKey = 115,
                        WestDirectionKey = 107,
                        SouthDirectionKey = 119,
                        EastDirectionKey= 140,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                         }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                         }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                    new LocationCardControl()
                    {
                        LocationName = "",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new object(),//0e -> -1wealth,+1 magic
                    }.Init(),
                });
            private set => _locations = value;
        }
    }
}