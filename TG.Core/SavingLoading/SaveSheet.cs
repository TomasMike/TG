using System;
using System.Collections.Generic;
using TG.Core.SavingLoading.SaveModels;

namespace TG.Core.SavingLoading
{
    public class SaveSheet
    {
        public string fileName;
        public List<PlayerSaveModel> Players;
        public List<LocationSaveObject> Locations;
        public SerializableDictionary<SaveSheetStatusEnum, SaveSheetStatus> Statuses;

        public SaveSheet()
        {
            Players = new List<PlayerSaveModel>();
            Locations = new List<LocationSaveObject>();
            InitNewSaveSheetStatuses();
        }

        public void SaveGameDataToSaveSheet()
        {
            //Locations = _MainForm.Instance.LocationCardsPanel.LocationCards
            //    .Select(
            //        _ => new LocationSaveObject()
            //        {
            //            MenhirValue = _.MenhirValue,
            //            LocationNumber = _.LocationNumber
            //        })
            //    .ToList();

            //Players = Game.Instance.Players.Select(_ => _.GetAsSaveSheetObject()).ToList();
        }

        public bool CheckStatus(SaveSheetStatusEnum name, int statusPart = 1)
        {
            try
            {
                return Statuses[name].IsStatusObtained(statusPart);
            }
            catch (KeyNotFoundException e)
            {
                //MessageBox.Show("that status doesnt exist");
                throw e;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void GainStatus(SaveSheetStatusEnum name, int statusPart = 1)
        {
            //TODO tu zobrazit aky status bol ziskany
            //                         MessageBox.Show("Gain 1 of the \"Fate of the Expedition\".");
            Statuses[name].ObtainedParts[statusPart] = 1;
        }

        private void InitNewSaveSheetStatuses()
        {
            Statuses = new SerializableDictionary<SaveSheetStatusEnum, SaveSheetStatus>
            {
                {SaveSheetStatusEnum.AlliesOfAvalon,new SaveSheetStatus(5)},
                {SaveSheetStatusEnum.BlackCauldron,new SaveSheetStatus(3)},
                {SaveSheetStatusEnum.BurningMystery,new SaveSheetStatus(8)},
                {SaveSheetStatusEnum.CallFromBeyond,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.CharredKnowledge,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.CherishedBelongings,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.ColdPyre,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.Cosuil,new SaveSheetStatus(5)},
                {SaveSheetStatusEnum.DealBreaker,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.DeepSecret,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.Diplomat,new SaveSheetStatus(3)},
                {SaveSheetStatusEnum.DiplomaticMission,new SaveSheetStatus(6)},
                {SaveSheetStatusEnum.DisturbingInformation,new SaveSheetStatus(3)},
                {SaveSheetStatusEnum.DreamsAndProphecies,new SaveSheetStatus(8)},
                {SaveSheetStatusEnum.EndOfTheRoad,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.EnemiesOfAvalon,new SaveSheetStatus(3)},
                {SaveSheetStatusEnum.Escalation,new SaveSheetStatus(3)},
                {SaveSheetStatusEnum.FaelsLegacy,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.FallOfChivalry,new SaveSheetStatus(8)},
                {SaveSheetStatusEnum.FarpointClues,new SaveSheetStatus(5)},
                {SaveSheetStatusEnum.FateOfTheExpedition,new SaveSheetStatus(9)},
                {SaveSheetStatusEnum.FinalConfrontations,new SaveSheetStatus(7)},
                {SaveSheetStatusEnum.FinalLesson,new SaveSheetStatus(5)},
                {SaveSheetStatusEnum.FortunateMeetings,new SaveSheetStatus(5)},
                {SaveSheetStatusEnum.GeneralDirections,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.GerraintsSuccessor,new SaveSheetStatus(3)},
                {SaveSheetStatusEnum.GlenRitual,new SaveSheetStatus(2)},
                {SaveSheetStatusEnum.GuestOfHonor,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.HalfwayIntrigue,new SaveSheetStatus(3)},
                {SaveSheetStatusEnum.HelpingHand,new SaveSheetStatus(6)},
                {SaveSheetStatusEnum.HelpingTheKnights,new SaveSheetStatus(4)},//nasheetesu4prazdnepolicka
                {SaveSheetStatusEnum.HiddenTreasures,new SaveSheetStatus(8)},
                {SaveSheetStatusEnum.HuntersMark,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.LadysTask,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.LastHaven,new SaveSheetStatus(5)},
                {SaveSheetStatusEnum.LeftBehind,new SaveSheetStatus(9)},
                {SaveSheetStatusEnum.LostAndFallen,new SaveSheetStatus(7)},
                {SaveSheetStatusEnum.MaggotsRedemption,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.Matricide,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.MonasteryDiscovered,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.MoonringMission,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.MorgainesTask,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.MourningSong,new SaveSheetStatus(2)},
                {SaveSheetStatusEnum.MysterySolved,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.Pathfinder,new SaveSheetStatus(8)},
                {SaveSheetStatusEnum.PeaceInBorough,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.PeoplesChampion,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.Pillager,new SaveSheetStatus(5)},
                {SaveSheetStatusEnum.Reclamation,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.Remedy,new SaveSheetStatus(4)},
                {SaveSheetStatusEnum.Remnants,new SaveSheetStatus(5)},
                {SaveSheetStatusEnum.RestoringTheOrder,new SaveSheetStatus(8)},
                {SaveSheetStatusEnum.RiddleOfTheOldsteel,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.SavedByTheGoddess,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.Scrounger,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.SecretsOfTheForest,new SaveSheetStatus(4)},
                {SaveSheetStatusEnum.ShelterInTheStorm,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.ShrineSecure,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.SomethingIsWatching,new SaveSheetStatus(1)},//vsheetesu4prazdnepolicka
                {SaveSheetStatusEnum.StonemasonsSecret,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.StrangeEncounters,new SaveSheetStatus(8)},
                {SaveSheetStatusEnum.SupplyingTheRevolt,new SaveSheetStatus(4)},//vsheetesu4prazdnepolicka
                {SaveSheetStatusEnum.TanglerootKnowledge,new SaveSheetStatus(2)},
                {SaveSheetStatusEnum.Tracker,new SaveSheetStatus(1)},
                {SaveSheetStatusEnum.TravelingMenhir,new SaveSheetStatus(2)},
                {SaveSheetStatusEnum.TuathanExploration,new SaveSheetStatus(5)},
                {SaveSheetStatusEnum.Underfern,new SaveSheetStatus(5)},
                {SaveSheetStatusEnum.WarForAvalon,new SaveSheetStatus(4)},
                {SaveSheetStatusEnum.WindsOfWyrdness,new SaveSheetStatus(1)},
            };
        }
    }


}