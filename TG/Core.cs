using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace TG
{

	public class Game
	{
		public static SaveSheet CurrentSaveSheet;

		public void StartNew()
		{
			var save = new SaveSheet();

			int numOfPlayers=0;


			while(numOfPlayers > 0 && numOfPlayers <= 4)
			{
				numOfPlayers = Asker.AskInt("how many players? (1-4)");
			}

			var listOfCharacters = new List<QuestionFromComboBoxItem>();

			foreach (var item in Enum.GetNames(typeof(CharacterName)))
			{
				listOfCharacters.Add(new QuestionFromComboBoxItem(item.ToString(), listOfCharacters.Count().ToString()));
			}
			

			for (int i = 1; i <= numOfPlayers; i++)
			{
				var p = new Player() { PlayerNumber = i};
				p.Name = Asker.AskText("Player 1 name?");

				var chosenCharacter = Asker.AskOneFromDropdown("Character?", listOfCharacters);
				p.Character.CharacterName = (CharacterName)Enum.Parse(typeof(CharacterName),chosenCharacter);
			}



			Asker.AskText("What Character will you be playing");
		}
	}

	public class SaveSheet
	{
		public string fileName;
		public List<Player> Players;
	}

	public static class SaveManager
	{
		public static void Save()
		{
			XmlSerializer x = new XmlSerializer(typeof(SaveSheet));
			x.Serialize(Console.Out, Game.CurrentSaveSheet);
		}
	}

	public class Player
	{
		public int PlayerNumber;
		public string Name;
		public Character Character;

		public List<Card> Hand;
		public List<Card> DrawingDeck;
		public List<Card> DiscardPile;
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

	public class Encounter
	{
		public Character ActiveCharacter;
		public EncounterCard ActiveEncounter;
		public Card LastActivatedCard;
		public List<Card> PassiveCardsInPlay;

		public void Combat(Player p, EncounterCard enc)
		{
			var ch = p.Character;
			var playedCards = new List<Card>();
			p.DrawingDeck = CardLib.GetCards();
			LastActivatedCard = null;
			for (int i = 1; i <= 3; i++)
			{
				DrawCard();

			}

			while (true)
			{

				//players turn

				//enemy attacks
				var atk = enc.Attacks[enc.CurrentDamage];

				if (playedCards.Any() && playedCards[playedCards.Count].OnEnemyAttack != null)
					atk = playedCards[playedCards.Count].OnEnemyAttack(this);
			}

		}

		public List<EnconterAttack> GetActiveAttack()
		{
			return ActiveEncounter.Attacks[ActiveEncounter.CurrentDamage];
		}

		public void DrawCard()
		{
			//var c = ActiveCharacter.DrawingDeck.Last();
			//ActiveCharacter.Hand.Add(c);
			//ActiveCharacter.DrawingDeck.Remove(ActiveCharacter.DrawingDeck.Last());
		}

		public void PlayerTurn()
		{
			//List<Tuple<Card, Card, Card>> playOptions = new
		}

		private List<Tuple<Card, Card, Card>> GetCardCombinations(List<Card> cards)
		{
			var retVal = new List<Tuple<Card, Card, Card>>();
			var l = cards.Count();


			return null;
		}


	}

	

}
