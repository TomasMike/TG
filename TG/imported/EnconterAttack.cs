using TG.Enums;

namespace TG
{
    public class EnconterAttack
    {
        public int Amount;
        public AttackType AttackType;

        public EnconterAttack(AttackType attackType, int ammount)
        {
            AttackType = attackType;
            Amount = ammount;
        }
    }
}