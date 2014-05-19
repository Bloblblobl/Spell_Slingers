using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCore;

namespace GameTest
{
    class HumanPlayer : BasePlayer, IPlayer
    {       
        public HumanPlayer(string name, Hand hand) : base(name, hand)
        {

        }

        public Card[] Attack(State state)
        {
            DisplayGameState(state);

            // Allow selecting attack cards
            var attackers = SelectAttackers();

            // Return attack cards
            return attackers;
        }

        public Defence Defend(State state, Card[] attackingCards)
        {
            // Show attackers
            Console.WriteLine("### YOU'RE UNDER ATTACK!!! ###");
            Console.WriteLine();
            DisplayCards(attackingCards, "Attackers:");

            // Show hand
            DisplayCards(_hand.Cards.ToArray(), "Hand:");

            // Loop over attackers and request defenders for each attacker
            var defence = new Defence();
            foreach (Card c in attackingCards)
            {
                Console.WriteLine("Input the Numbers of Defending Cards for [{0}] separated by spaces", c);
                var defenders = SelectCards(_hand.Cards.ToArray());
                defence.Response[c] = defenders;
            }

            // Return defenders
            return defence;
        }

        void DisplayCards(Card[] cards, string title)
        {
            Console.WriteLine(title);
            for (var i = 0; i < cards.Length; i++)
            {
                var c = cards[i];
                var cardDisplay = string.Format("[{0}] {1}", (i + 1), c);
                Console.WriteLine(cardDisplay);
            }
            Console.WriteLine();
        }

        Card[] SelectAttackers()
        {
            Console.WriteLine("### ATTACK!!! ###");
            Console.WriteLine("Input the Numbers of Attacking Cards separated by spaces");
            var attackers = SelectCards(_hand.Cards.ToArray());

            return attackers;
        }

        private Card[] SelectCards(Card[] cards)
        {
            var input = Console.ReadLine();
            var selectNumbers = input.Split(' ');
            var selected = new Card[selectNumbers.Length];

            if (selectNumbers[0] == "")
            {
                return null;
            }

            for (var i = 0; i < selectNumbers.Length; i++)
            {
                var index = int.Parse(selectNumbers[i]) - 1;
                selected[i] = cards[index];
            }
            return selected;
        }

        void DisplayGameState(State state)
        {
            var header = string.Format("{0} | {1}", state.ActivePlayer.Name, state.OtherPlayer.Name);
            var life = string.Format("{0} | {1}", state.ActivePlayer.Life, state.OtherPlayer.Life);
            var padding = state.ActivePlayer.Name.Length - state.ActivePlayer.Life.ToString().Length;
            var separator = new String('-', header.Length);

            Console.WriteLine(header);
            Console.WriteLine(separator);

            Console.Write(new String(' ', padding));
            Console.WriteLine(life);
            Console.WriteLine(separator);

            Console.WriteLine();
            DisplayCards(_hand.Cards.ToArray(), "Hand:");
        }
    }
}
