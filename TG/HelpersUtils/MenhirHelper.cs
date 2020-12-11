using System.Linq;
using System.Text;
using TG.CoreStuff;
using TG.CustomControls;
using TG.Menhirs;
using TG.HelpersUtils;
using TG.SavingLoading;

namespace TG.HelpersUtils
{
    public static class MenhirHelper
    {
        public static string GetMenhirActivationDescription(LocationCardControl lcc)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"[{(AreAllPlayersInLocation(lcc) ? "DONE":"NOT")}] Requires all Characters.");
            sb.AppendLine();

            var requirement = lcc.MenhirActivationRequirement;

            foreach (var itemName in requirement.RequiredItems)
            {
                sb.AppendLine($"[{(HavePlayersItem(itemName) ? "DONE" : "NOT")}] {itemName}");
            }

            foreach (var secretName in requirement.RequiredSecretsByName)
            {
                sb.AppendLine($"[{(HavePlayersSecret(secretName) ? "DONE" : "NOT")}] {secretName}");
            }

            foreach (var secretNumber in requirement.RequiredSecretsByNumber)
            {
                sb.AppendLine($"[{(HavePlayersSecret(secretNumber) ? "DONE" : "NOT")}] Secret {secretNumber}");
            }

            foreach (var costs in requirement.PerCharacterCosts)
            {
                var reqAmount = costs.Value * Game.Instance.Players.Count;
                sb.AppendLine($"[{(HavePlayersEnoughResource(costs.Key,reqAmount) ? "DONE" : "NOT")}] {costs.Key} per player => {reqAmount} {costs.Key}");
            }

            if(requirement.RequiredActiveMenhirInLocation)
                sb.AppendLine($"[{(lcc.MenhirValue >= 0 ? "DONE" : "NOT")}]  Have an active menhir in this location");

            foreach (var reqStatus in requirement.RequiredStatuses)
            {
                sb.AppendLine($"[{(SaveManager.CurrentSaveSheet.CheckStatus(reqStatus.Key) == reqStatus.Value ? "DONE" : "NOT")}] {(reqStatus.Value ? "Have" : "Not have")} {reqStatus.Key} status");
            }

            return sb.ToString();
        }

        public static bool AreAllActivationRequirementsMet(LocationCardControl lcc)
        {
            var requirement = lcc.MenhirActivationRequirement;

            return
                AreAllPlayersInLocation(lcc)
                && requirement.RequiredItems.All(i => HavePlayersItem(i))
                && requirement.RequiredSecretsByName.All(i => HavePlayersSecret(i))
                && requirement.RequiredSecretsByNumber.All(i => HavePlayersSecret(i))
                && requirement.PerCharacterCosts.All(i => HavePlayersEnoughResource(i.Key, i.Value * Game.Instance.Players.Count))
                && (requirement.RequiredActiveMenhirInLocation || lcc.MenhirValue >= 0)
                && requirement.RequiredStatuses.All(i => i.Value == SaveManager.CurrentSaveSheet.CheckStatus(i.Key));
        }
        private static bool AreAllPlayersInLocation(LocationCardControl lcc)
        {
            return Game.Instance.Players.All(p => p.CurrentLocation == lcc.LocationNumber);
        }

        private static bool HavePlayersSecret(string secretName)
        {
            return Game.Instance.Players.Any(p => p.Character.HasCharacterSecretByName(secretName));
        }

        private static bool HavePlayersSecret(int secretNumber)
        {
            return Game.Instance.Players.Any(p => p.Character.HasCharacterSecretByNumber(secretNumber));
        }

        private static bool HavePlayersItem(string itemName)
        {
            return Game.Instance.Players.Any(p => p.Character.Items.Any(i => i.Name == itemName));
        }

        private static bool HavePlayersEnoughResource(MenhirActivationRequirementsResourceEnum resource, int reqAmount)
        {
            int currentAmount = 0;
            switch (resource)
            {
                case MenhirActivationRequirementsResourceEnum.Energy:
                    currentAmount = Game.Instance.Players.Sum(p => p.Character.CurrentEnergy);
                    break;
                case MenhirActivationRequirementsResourceEnum.Health:
                    currentAmount = Game.Instance.Players.Sum(p => p.Character.CurrentHealth);
                    break;
                case MenhirActivationRequirementsResourceEnum.Wealth:
                    currentAmount = Game.Instance.Players.Sum(p => p.Character.Wealth);
                    break;
                case MenhirActivationRequirementsResourceEnum.Magic:
                    currentAmount = Game.Instance.Players.Sum(p => p.Character.Magic);
                    break;
                case MenhirActivationRequirementsResourceEnum.Food:
                    currentAmount = Game.Instance.Players.Sum(p => p.Character.Food);
                    break;
            }

            return currentAmount >= reqAmount;
        }
    }
}