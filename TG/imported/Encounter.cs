using System.Collections.Generic;

namespace TG
{
    public class EncounterCard
    {
        public string Name;
        public CombatCardSide StartingSide;
        public Dictionary<int, List<EnconterAttack>> Attacks;
        public int TotalHealth;
        public int CurrentDamage;
        public EnconterAttack OpportunityAttack;
    }
}