using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TG.CoreStuff;
using TG.Exploration;
using TG.Libs;
using TG.PlayerDecisionIO;

namespace TG.Managers
{
    public static class ExplorationManager
    {
        public static void StartExploration(int location)
        {
            var activeExploration = ExplorationScenariosLib.ExplorationScenarios[location];

            StartExploration(activeExploration);
        }

        public static void StartExploration(ExplorationScenario scenario)
        {
            var q = scenario.IntroParagraph.Text;
            int chosenPar;
            if (scenario.IntroParagraph.ForcedOptions.Any(a => a.Check(null)))
            {
                //player is forced to some option
                var fo = Asker.Ask(q, new[] { scenario.IntroParagraph.ForcedOptions.First(a => a.Check(null)) }.ToList());
                if (fo is ChangeLocationStateForcedOption)
                {
                    //TODO
                }
                else if(fo is ForceScenarioParagraphForcedOption)
                {
                    chosenPar = ((ForceScenarioParagraphForcedOption)fo).RedirectToParagraphNum;
                }
            }
            else
            {
                Asker.Ask(q, scenario.IntroParagraph.ParagraphOptions.Where(po => po.OptionCondition(GetEventArgs)));
            }




            //Asker.Ask(scenario.ExplorationIntroText, scenario.Options, false); //TODO
        }

        private static ExplorationEventArgs GetEventArgs = new ExplorationEventArgs
        {
            ActiveParty = Game.Instance.ActiveParty,
            LocationOfExploration = Game.Instance.ActivePlayer.CurrentLocationCard
        };
    }
}