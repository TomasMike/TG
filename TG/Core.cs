using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
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
            var save = new SaveSheet();
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

    public class MyControl : Control
    {
        // ContentAlignment is an enumeration defined in the System.Drawing
        // namespace that specifies the alignment of content on a drawing
        // surface.
        private ContentAlignment alignmentValue = ContentAlignment.MiddleLeft;

        private string leftText = "123";
        private string topText = "234";
        private string botText = "345";
        private string rightText = "456";
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawString(topText, Font, new SolidBrush(ForeColor), Width / 2 - (e.Graphics.MeasureString(topText, Font).Width / 2), 1);
            e.Graphics.DrawString(botText, Font, new SolidBrush(ForeColor), Width / 2 - (e.Graphics.MeasureString(botText, Font).Width / 2), Height - Font.Height);
            e.Graphics.DrawString(leftText, Font, new SolidBrush(ForeColor), 1, Height / 2 - (FontHeight / 2));
            e.Graphics.DrawString(rightText, Font, new SolidBrush(ForeColor), Width - e.Graphics.MeasureString(rightText, Font).Width, Height / 2 - (FontHeight / 2));
        }
    }



}
