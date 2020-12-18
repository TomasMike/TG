using System;
using System.Collections.Generic;
using TG.CoreStuff;
using TG.CustomControls;
using TG.Enums;
using TG.Locations;
using TG.Menhirs;
using TG.PlayerCharacterItems;

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
                    new LocationCardControl
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
                            Description = "(1 Energy) Chores for the townsfolk: Gain 1 Rep (once per day)",
                            Action = a =>
                            {
                                Game.Instance.ActivePlayer.Character.EditCharProperty(
                                    CharacterAttribute.CurrentEnergy,
                                    EditCharPropertyChangeType.Subtract,
                                    1);
                                 Game.Instance.ActivePlayer.Character.EditCharProperty(
                                    CharacterAttribute.Reputation,
                                    EditCharPropertyChangeType.Add,
                                    1);
                            }
                        },
                        MenhirActivationRequirement = new MenhirActivationRequirement
                        {
                            PerCharacterCosts = new Dictionary<MenhirActivationRequirementsResourceEnum, int>
                            {
                                { MenhirActivationRequirementsResourceEnum.Energy, 2 },
                                { MenhirActivationRequirementsResourceEnum.Health, 2 },
                                { MenhirActivationRequirementsResourceEnum.Wealth, 2 },
                                { MenhirActivationRequirementsResourceEnum.Magic, 2 }
                            },
                            RequiredSecretsByName = new List<string>{"Menhir Rites","Stoneshaper's Tools" }
                        },
                        GetMenhirStartingValue = _ => 8 - Game.CurrentSaveSheet.Players.Count,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Hunters' Grove",
                        LocationNumber = 102,
                        NorthDirectionKey = 113,
                        WestDirectionKey = 106,
                        SouthDirectionKey = 101,
                        EastDirectionKey = 107,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new LocationAction
                        {
                            Description = "(2 energy) Gater food: Gain 2 Food, draw 1 green Encounter",
                        }
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Warrior Fair",
                        LocationNumber = 103,
                        WestDirectionKey = 118,
                        SouthDirectionKey = 108,
                        EastDirectionKey = 101,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        LocationAction = new LocationAction
                        {
                            Description = "(4 energy) Combat Trial: Lose 1 Health, gain 1 Exp (once per day)",
                        }
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Charred Conclave",
                        LocationNumber = 104,
                        NorthDirectionKey = 107,
                        WestDirectionKey = 101,
                        SouthDirectionKey = 109,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = null,
                        OnEnterEffect = new OnEnterLocationForcedEffect()// gray encounter
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Forlorn Swords",
                        LocationNumber = 105,
                        NorthDirectionKey = 101,
                        WestDirectionKey = 108,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new LocationAction
                        {
                            Description = "(1 energy) Smith's Shop: Pay 1 Wealth, draw 1 Craftable Item",
                        }
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Fore-dweller Mounds",
                        LocationNumber = 106,
                        NorthDirectionKey = 112,
                        WestDirectionKey = 116,
                        EastDirectionKey = 102,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new LocationAction
                        {
                            Description = "(2 energy) Treasure Hunt: Gain 1 Terror, 1 Wealth and roll a die. If the result is 6, Exp.Journal Verse 4."
                        },
                        MenhirActivationRequirement = new MenhirActivationRequirement
                        {
                            PerCharacterCosts = new Dictionary<MenhirActivationRequirementsResourceEnum, int>
                            {
                                { MenhirActivationRequirementsResourceEnum.Energy, 1 },
                                { MenhirActivationRequirementsResourceEnum.Health, 1 },
                                { MenhirActivationRequirementsResourceEnum.Wealth, 2 },
                                { MenhirActivationRequirementsResourceEnum.Food, 1 }
                            },
                            RequiredSecretsByName = new List<string>{"Menhir Rites","Stoneshaper's Tools" }
                        },
                        GetMenhirStartingValue = _ => 9 - Game.CurrentSaveSheet.Players.Count,

                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Whitening",
                        LocationNumber = 107,
                        NorthDirectionKey = 114,
                        WestDirectionKey = 102,
                        SouthDirectionKey = 104,
                        EastDirectionKey = 117,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        OnEnterEffect = new OnEnterLocationForcedEffect(),//blue encounter
                        LocationAction = new LocationAction
                        {
                            Description = "(1 energy) Trade With the Townsfolk: Pay 1 Food, gain 1 Wealth",
                        },
                        MenhirActivationRequirement = new MenhirActivationRequirement
                        {
                            PerCharacterCosts = new Dictionary<MenhirActivationRequirementsResourceEnum, int>
                            {
                                { MenhirActivationRequirementsResourceEnum.Energy, 3 },
                                { MenhirActivationRequirementsResourceEnum.Health, 1 },
                                { MenhirActivationRequirementsResourceEnum.Wealth, 1 },
                                { MenhirActivationRequirementsResourceEnum.Magic, 1 },
                            },
                            RequiredSecretsByName = new List<string>{ "Menhir Rites" }
                        },
                        GetMenhirStartingValue = _ => 9 - Game.CurrentSaveSheet.Players.Count,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Grubwood",
                        LocationNumber = 108,
                        NorthDirectionKey = 103,
                        WestDirectionKey = 120,
                        EastDirectionKey = 105,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        OnEnterEffect = new OnEnterLocationForcedEffect(),//free explore
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Island Asylum",
                        LocationNumber = 109,
                        NorthDirectionKey = 104,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new LocationAction
                        {
                            Description = "(1 energy) Healing Rites: Pay 1 Wealth, gain 3 Health",
                        },
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Haunted Grubwood",
                        LocationNumber = 110,
                        LegacyLocationNumber = 108,
                        NorthDirectionKey = 103,
                        WestDirectionKey = 120,
                        EastDirectionKey = 105,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new LocationAction
                        {
                            Description = "(1 energy) Cook Worms: Gain 1 Terror and 1 Food",
                        }
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Underwall",
                        LocationNumber = 111,
                        NorthDirectionKey = 131,
                        SouthDirectionKey = 116,
                        EastDirectionKey = 112,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        LocationAction = new LocationAction
                        {
                            Description = "(2 energy) Gather Food: Gain 2 Food, draw 1 green Encounter"
                        },
                        MenhirActivationRequirement = new MenhirActivationRequirement
                        {
                            PerCharacterCosts = new Dictionary<MenhirActivationRequirementsResourceEnum, int>
                            {
                                { MenhirActivationRequirementsResourceEnum.Energy, 2 },
                                { MenhirActivationRequirementsResourceEnum.Food, 1 },
                                { MenhirActivationRequirementsResourceEnum.Magic, 2 },
                            },
                            RequiredSecretsByName = new List<string>{ "Menhir Rites" },
                        },
                        GetMenhirStartingValue = _ => 7 - Game.CurrentSaveSheet.Players.Count,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Bloodied Glen",
                        LocationNumber = 112,
                        NorthDirectionKey = 132,
                        WestDirectionKey = 111,
                        SouthDirectionKey = 106,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        LocationAction = new LocationAction
                        {
                            Description = "(1 energy) Rob the Dead: Pay 1 Rep or gain 1 Terror to gain 1 Wealth",
                        }
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Mirror Lake",
                        LocationNumber = 113,
                        SouthDirectionKey = 102,
                        EastDirectionKey= 114,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        LocationAction = new LocationAction
                        {
                            Description = "(0 energy) Rest by the Lake: Gain 1 energy and 1 Health, lose 1 Terror (once per day)"
                        }
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Tangleroot",
                        LocationNumber = 114,
                        WestDirectionKey = 113,
                        SouthDirectionKey = 107,
                        EastDirectionKey= 115,
                        LocationSetlementType = LocationSetlementTypeEnum.None,
                        Dreams = true,
                        LocationAction = new LocationAction
                        {
                            Description = "(2 energy) Gather Food: Gain 2 Food, draw 1 green Encounter"
                        }
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Titans' Steps",
                        LocationNumber = 115,
                        WestDirectionKey = 114,
                        SouthDirectionKey = 117,
                        EastDirectionKey = 138,
                        OnEnterEffect = new OnEnterLocationForcedEffect(), // free exploration
                        MenhirActivationRequirement = new MenhirActivationRequirement
                        {
                            PerCharacterCosts = new Dictionary<MenhirActivationRequirementsResourceEnum, int>
                            {
                                { MenhirActivationRequirementsResourceEnum.Energy, 2 },
                                { MenhirActivationRequirementsResourceEnum.Magic, 2 },
                            },
                            RequiredSecretsByName = new List<string>{ "Menhir Rites" },
                        },
                        GetMenhirStartingValue = _ =>  8 - Game.CurrentSaveSheet.Players.Count,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Farshire",
                        LocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                        LocationAction = new LocationAction
                        {
                            Description = "(0 energy) Buy Druidic Charms: Pay 1 Wealth, gain 1 Magic"
                        },
                        OnEnterEffect = new OnEnterLocationForcedEffect(),//blue encounter

                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "First Farmhold",
                        LocationNumber = 117,
                        NorthDirectionKey = 115,
                        WestDirectionKey = 107,
                        SouthDirectionKey = 119,
                        EastDirectionKey= 140,
                        Dreams = true,
                        OnEnterEffect = new OnEnterLocationForcedEffect(),//purple encounter once per daywww

                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Stampede",
                        LocationNumber = 118,
                        NorthDirectionKey = 116,
                        WestDirectionKey = 141,
                        SouthDirectionKey = 120,
                        EastDirectionKey = 103,
                        Dreams = true,
                        MenhirActivationRequirement = new MenhirActivationRequirement
                        {
                            PerCharacterCosts = new Dictionary<MenhirActivationRequirementsResourceEnum, int>
                            {
                                { MenhirActivationRequirementsResourceEnum.Energy, 2 },
                                { MenhirActivationRequirementsResourceEnum.Food, 2 },
                                { MenhirActivationRequirementsResourceEnum.Wealth, 1 },
                            },
                            RequiredSecretsByName = new List<string>{ "Menhir Rites"},
                            RequiredSecretsByNumber = new List<int>{7},
                        },
                        GetMenhirStartingValue = _ => Math.Min(7 - Game.CurrentSaveSheet.Players.Count,5),
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Derelict Fleet",
                        LocationNumber = 119,
                        NorthDirectionKey = 117,
                        Dreams = true,
                        LocationAction = new LocationAction
                        {
                            Description = "(4 energy) Scour the Wrecks: Gain 1 Terror, 1 Magic and 1 Exp (once per day)"
                        }
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Horns of South",
                        LocationNumber = 120,
                        NorthDirectionKey = 118,
                        EastDirectionKey = 108,
                        Dreams = true,
                        LocationAction = new LocationAction
                        {
                            Description = "(2 energy) Help the Keepers: Gain 1 Food (once per day)"
                        }
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Broken Cuanacht",
                        LocationNumber = 121,
                        LegacyLocationNumber = 101,
                        NorthDirectionKey = 102,
                        WestDirectionKey = 103,
                        SouthDirectionKey = 105,
                        EastDirectionKey = 104,
                        Dreams = true,
                        MenhirActivationRequirement = new MenhirActivationRequirement
                        {
                            PerCharacterCosts = new Dictionary<MenhirActivationRequirementsResourceEnum, int>
                            {
                                { MenhirActivationRequirementsResourceEnum.Energy, 1 },
                                { MenhirActivationRequirementsResourceEnum.Health, 2 },
                                { MenhirActivationRequirementsResourceEnum.Wealth, 2 },
                                { MenhirActivationRequirementsResourceEnum.Magic, 2 },
                            },
                            RequiredSecretsByName = new List<string>{ "Menhir Rites","Stoneshaper's Tools"},
                        },
                        GetMenhirStartingValue = _ => 8 - Game.CurrentSaveSheet.Players.Count,
                        LocationSetlementType = LocationSetlementTypeEnum.FriendlySettlement,
                    }.Init(),
                     new LocationCardControl
                    {
                        LocationName = "Drained Lake",
                        LocationNumber = 122,
                        LegacyLocationNumber = 113,
                        SouthDirectionKey = 102,
                        EastDirectionKey = 114,
                        Dreams = true
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Sunken Mounds",
                        LocationNumber = 123,
                        LegacyLocationNumber = 106,
                        NorthDirectionKey = 112,
                        WestDirectionKey = 116,
                        EastDirectionKey = 102,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Titans' Steps",
                        LocationNumber = 125,
                        LegacyLocationNumber = 115,
                        WestDirectionKey = 114,
                        SouthDirectionKey = 117,
                        EastDirectionKey = 138,
                        MenhirActivationRequirement = new MenhirActivationRequirement
                        {
                            PerCharacterCosts = new Dictionary<MenhirActivationRequirementsResourceEnum, int>
                            {
                                { MenhirActivationRequirementsResourceEnum.Energy, 3 },
                                { MenhirActivationRequirementsResourceEnum.Magic, 2 },
                            },
                            RequiredSecretsByName = new List<string>{ "Menhir Rites"},
                        },
                        GetMenhirStartingValue = _ => 8 - Game.CurrentSaveSheet.Players.Count,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Collapsed Dolmen",
                        LocationNumber = 126,
                        LegacyLocationNumber = 116,
                        NorthDirectionKey = 111,
                        WestDirectionKey = 139,
                        SouthDirectionKey = 118,
                        EastDirectionKey= 106,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName="Timberwall",
                        LocationNumber = 131,
                        SouthDirectionKey = 111,
                        EastDirectionKey = 132,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Serene Visage",
                        LocationNumber = 132,
                        NorthDirectionKey = 151,
                        WestDirectionKey = 131,
                        SouthDirectionKey = 112,
                        EastDirectionKey = 133,
                        Dreams = true,
                        MenhirActivationRequirement = new MenhirActivationRequirement
                        {
                            PerCharacterCosts = new Dictionary<MenhirActivationRequirementsResourceEnum, int>(),
                            RequiredSecretsByName = new List<string>{ "Menhir Rites"},
                            RequiredStatuses = new Dictionary<SaveSheetStatusEnum, bool>
                            {
                                {SaveSheetStatusEnum.MysterySolved, true}
                            }
                        },
                        GetMenhirStartingValue = _ => -1,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Moonring",
                        LocationNumber = 133,
                        NorthDirectionKey = 152,
                        WestDirectionKey = 132,
                        EastDirectionKey = 134,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Falfuar",
                        LocationNumber = 134,
                        NorthDirectionKey = 153,
                        WestDirectionKey = 133,
                        EastDirectionKey = 135,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        MenhirActivationRequirement = new MenhirActivationRequirement
                        {
                            PerCharacterCosts = new Dictionary<MenhirActivationRequirementsResourceEnum, int>()
                            {
                                {MenhirActivationRequirementsResourceEnum.Energy, 1 },
                                {MenhirActivationRequirementsResourceEnum.Magic, 2 },
                                {MenhirActivationRequirementsResourceEnum.Wealth, 1 },
                            },
                            RequiredSecretsByName = new List<string>{ "Menhir Rites"},
                            RequiredActiveMenhirInLocation = true,
                        },
                        GetMenhirStartingValue = _ => 7 - Game.CurrentSaveSheet.Players.Count,

                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Bundorca",
                        LocationNumber = 135,
                        NorthDirectionKey = 154,
                        WestDirectionKey = 134,
                        EastDirectionKey = 136,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        GetMenhirStartingValue = a => { return 7 - Game.CurrentSaveSheet.Players.Count; },
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Broch Cruach",
                        LocationNumber = 136,
                        NorthDirectionKey =  155,
                        WestDirectionKey = 135,
                        SouthDirectionKey = 138,
                        Dreams = true,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Conquered Timberwall",
                        LocationNumber = 137,
                        LegacyLocationNumber = 131,
                        SouthDirectionKey = 111,
                        EastDirectionKey = 132,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Plagued Borough",
                        LocationNumber = 138,
                        NorthDirectionKey = 136,
                        WestDirectionKey = 115,
                        EastDirectionKey = 190,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Devastation",
                        LocationNumber = 139,
                        WestDirectionKey = 156,
                        EastDirectionKey = 116,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Dark Morass",
                        LocationNumber = 140,
                        WestDirectionKey = 117,
                        EastDirectionKey = 157,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Wyrdedge",
                        LocationNumber = 141,
                        EastDirectionKey = 118,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Quiet Borough",
                        LocationNumber = 142,
                        LegacyLocationNumber = 138,
                        NorthDirectionKey = 136,
                        WestDirectionKey = 115,
                        EastDirectionKey = 190,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Abandoned Falfuar",
                        LocationNumber = 147,
                        LegacyLocationNumber = 134,
                        NorthDirectionKey = 153,
                        WestDirectionKey = 133,
                        EastDirectionKey = 135,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Faldorca",
                        LocationNumber = 148,
                        LegacyLocationNumber = 135,
                        NorthDirectionKey = 155,
                        WestDirectionKey = 134,
                        EastDirectionKey = 136,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Broken Broch",
                        LocationNumber = 149,
                        LegacyLocationNumber = 136,
                        NorthDirectionKey = 155,
                        WestDirectionKey = 135,
                        SouthDirectionKey= 138,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Valley of Guardians",
                        LocationNumber = 150,
                        EastDirectionKey = 151,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Longbarrow",
                        LocationNumber = 151,
                        WestDirectionKey = 150,
                        SouthDirectionKey = 132,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Halfway",
                        LocationNumber = 152,
                        NorthDirectionKey = 160,
                        SouthDirectionKey = 133,
                        EastDirectionKey = 153,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Fernsea",
                        LocationNumber = 153,
                        WestDirectionKey = 152,
                        SouthDirectionKey = 134,
                        Dreams = true,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Tombs of the Order",
                        LocationNumber = 154,
                        NorthDirectionKey = 161,
                        SouthDirectionKey = 135,
                        EastDirectionKey = 155,
                        Dreams = true,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Forest of Whispers",
                        LocationNumber = 155,
                        WestDirectionKey = 154,
                        SouthDirectionKey = 136,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Riverfall",
                        LocationNumber = 156,
                        EastDirectionKey = 139,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Shimmering Flats",
                        LocationNumber = 157,
                        WestDirectionKey = 140,
                        Dreams = true,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Halfway Meeting",
                        LocationNumber = 158,
                        LegacyLocationNumber = 152,
                        NorthDirectionKey = 160,
                        SouthDirectionKey = 133,
                        EastDirectionKey = 153,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Crow's Nest",
                        LocationNumber = 160,
                        SouthDirectionKey = 152,
                        Dreams = true,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Farpoint",
                        LocationNumber = 161,
                        SouthDirectionKey = 154,
                        Dreams = true,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Corbenic",
                        LocationNumber = 162,
                        Dreams = true,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Razed Nest",
                        LocationNumber = 165,
                        LegacyLocationNumber= 160,
                        SouthDirectionKey = 152,
                        Dreams = true,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Farpoint Refuge",
                        LocationNumber = 170,
                        LegacyLocationNumber = 161,
                        SouthDirectionKey = 154,
                        LocationSetlementType = LocationSetlementTypeEnum.FriendlySettlement,
                        Dreams = true,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Orin's Resolve",
                        LocationNumber = 180,
                        Dreams = true,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Heart of Tuathan",
                        LocationNumber = 185,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Kamelot",
                        LocationNumber = 190,
                        WestDirectionKey = 138,
                        LocationSetlementType = LocationSetlementTypeEnum.FriendlySettlement,
                        Dreams = true,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Besieged Kamelot",
                        LegacyLocationNumber = 190,
                        WestDirectionKey = 138,
                        LocationSetlementType = LocationSetlementTypeEnum.HostileSettlement,
                        Dreams = true,
                    }.Init(),
                    new LocationCardControl
                    {
                        LocationName = "Tuathan",
                        LegacyLocationNumber = 199,
                    }.Init(),
                });
            private set => _locations = value;
        }
    }
}