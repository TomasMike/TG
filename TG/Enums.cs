using System;
using System.Collections.Generic;
using System.Text;

namespace TG.Enums
{
	public enum AttackType
	{
		Wound,
		WoundUnavoidable,
		LooseRedCube,
		DiscardLastCard,
		RunAway,
		GainTerror,
		LooseRep,
		LooseEnergy
	}

	public enum KeyValue
	{
		NoKey,
		EmptyKey,
		OneAtr,
		TwoAtr,
		OneMultiply,
		TwoMultiply,
		OneDamage,
		TwoDamage,
		Magic,
		BonusKey,
		DrawCard,
		DiscardLast,
		Void
	}

	public enum CardEffectType
	{
		EnemyHealsLess,
		PreventDamage,
		GainCharges,
		DrawCard,
	}

	public enum CardSet
	{
		G15,
		G25,
	}

    public enum CharacterName
    {
        Beor,
        Ailei,
        Maggot,
        Arev,
        Niamh
    }

    public enum CharacterArchetype
    {
        Blue,
        Gray,
        Green,
        Brown
    }
}
