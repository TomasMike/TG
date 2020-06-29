using System;
using System.Collections.Generic;
using System.Linq;
using TG.Enums;

namespace TG
{
    public sealed class Game
    {
        private static Game instance = null;
        Game() { }

        public static Game Instance => instance ?? (instance = new Game());

        public static SaveSheet CurrentSaveSheet;

        public void StartNew()
        {
            //remove expired menhirs

        }
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
            //p.DrawingDeck = CardLib.GetCards();
            LastActivatedCard = null;
            for (int i = 1; i <= 3; i++)
            {
                DrawCard();
                //Game.Instance.
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
