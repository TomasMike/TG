using System;
using System.Collections.Generic;
using TG.Enums;

namespace TG
{
	public class Card
	{
		public string Name;
		public CardSet CardSet;
		public int CardNumberInSet;

		public CardSide LeftSide;
		public CardSide RightSide;

		public int Charges;
		public bool isPassive = false;
		public int TimeTokens;

		public Func<Encounter, List<EnconterAttack>> OnEnemyAttack;
		public Action<Encounter> OnActivation;
		public Func<Encounter, List<EnconterAttack>> OnDelayedActivaton;
		public Func<Encounter, List<EnconterAttack>> OnUseCharge;
	}

}
