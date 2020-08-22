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
            Asker.Ask(scenario.ExplorationIntroText, scenario.Options, false);
        }
    }
}