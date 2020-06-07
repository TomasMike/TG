using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TG.Enums;

namespace TG
{
	public static class CardLib
	{
		public static List<Card> GetCards()
		{
			return new List<Card>
			{
				new Card
				{
					Name = "Careful Attack",
					CardSet = CardSet.G25,
					CardNumberInSet = 1,
					LeftSide = new CardSide
					{
						BearKey = KeyValue.OneDamage,
						PigKey = KeyValue.NoKey,
						SnakeKey = KeyValue.BonusKey,
						MagicKey = KeyValue.NoKey,
						FreeKey = KeyValue.OneDamage
					},
					RightSide = new CardSide
					{
						BearKey = KeyValue.OneAtr,
						PigKey = KeyValue.OneAtr,
						SnakeKey = KeyValue.OneAtr,
						MagicKey = KeyValue.NoKey,
						FreeKey = KeyValue.TwoMultiply
					},
					OnEnemyAttack = (args) =>
					{
						var retVal = args.GetActiveAttack();
						retVal.ForEach(_ =>
						{
							if(_.AttackType == AttackType.LooseRedCube)
								_.Amount = Math.Max(0, _.Amount -1);

							if (_.AttackType == AttackType.Wound)
								_.Amount = Math.Max(0, _.Amount -1);

						});

						return retVal;
					}
				},
				new Card
				{
					Name = "Cripling Strike",
					CardSet = CardSet.G25,
					CardNumberInSet = 2,
					isPassive = true,
					LeftSide = new CardSide
					{
						BearKey = KeyValue.NoKey,
						PigKey = KeyValue.NoKey,
						SnakeKey = KeyValue.OneDamage,
						MagicKey = KeyValue.NoKey,
						FreeKey = KeyValue.OneDamage
					},
					RightSide = new CardSide
					{
						BearKey = KeyValue.OneAtr,
						PigKey = KeyValue.OneAtr,
						SnakeKey = KeyValue.NoKey,
						MagicKey = KeyValue.NoKey,
						FreeKey = KeyValue.OneMultiply
					},
					OnActivation = (args) =>
					{
						args.LastActivatedCard.Charges = 2;
					},
					OnEnemyAttack = (args) =>
					{
						var retVal = args.GetActiveAttack();
						var @this = args.PassiveCardsInPlay.First(_ => _.Name == "Cripling Strike");

						if(@this == null)
							throw new Exception();

						if(@this.Charges > 0)
						{
							//ask player if wants to use charge
							if(retVal.Any(_ => _.AttackType == AttackType.LooseRedCube))
							{
								//use the effect
								@this.Charges--;
								retVal.ForEach(_ =>
								{
									if(_.AttackType == AttackType.LooseRedCube)
										_.Amount = Math.Max(0, _.Amount -1);
								});

								args.DrawCard();
							}
						}
						return retVal;
					}
				},
				new Card
				{
					Name = "Defend",
					CardSet = CardSet.G25,
					CardNumberInSet = 3,
					LeftSide = new CardSide
					{
						BearKey = KeyValue.NoKey,
						PigKey = KeyValue.NoKey,
						SnakeKey = KeyValue.BonusKey,
						MagicKey = KeyValue.BonusKey,
						FreeKey = KeyValue.EmptyKey
					},
					RightSide = new CardSide
					{
						BearKey = KeyValue.OneAtr,
						PigKey = KeyValue.NoKey,
						SnakeKey = KeyValue.OneAtr,
						MagicKey = KeyValue.Magic,
						FreeKey = KeyValue.TwoMultiply
					},
					OnEnemyAttack = args =>
					{
						var retVal = args.GetActiveAttack();

						retVal.ForEach(_ =>
						{
							if(_.AttackType == AttackType.Wound)
								_.Amount = Math.Max(0, _.Amount - 2);
						});
						return retVal;
					},
					OnActivation = args =>
					{
						var @this = args.PassiveCardsInPlay.First(_ => _.Name == "Defend").TimeTokens = 1;
					},
					OnDelayedActivaton = args =>
					{
						args.DrawCard();
						return args.GetActiveAttack();
					}

				}
				
			};
		}
	}
}
