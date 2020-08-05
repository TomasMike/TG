using System.Collections.Generic;
using TG.Enums;

namespace TG
{
    public static class EncounterLib
    {
        public static List<EncounterCard> GetEncounters()
        {
            return new List<EncounterCard>
        {
            new EncounterCard
            {
                Name = "Mist-shaped Vermin",
                Attacks = new Dictionary<int, List<EnconterAttack>>
                {
                    { 0, new List<EnconterAttack> { new EnconterAttack(AttackType.Wound, 1) } },
                    { 1, new List<EnconterAttack> { new EnconterAttack(AttackType.Wound, 1) } },
                    { 2, new List<EnconterAttack> { new EnconterAttack(AttackType.Wound, 1) } },
                    { 3, new List<EnconterAttack> { new EnconterAttack(AttackType.LooseRedCube, 1) } },
                },
                TotalHealth = 4,
                StartingSide = new CombatCardSide
                {
                    BearKey = KeyValue.OneAtr,
                    PigKey = KeyValue.OneAtr,
                    SnakeKey = KeyValue.OneAtr,
                    MagicKey = KeyValue.Magic,
                    FreeKey = KeyValue.OneMultiply,
                },
                OpportunityAttack = new EnconterAttack(AttackType.RunAway, 1)
            }
        };
        }
    }
}