using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCore;

namespace GameTest
{
    class ComputerPlayer : BasePlayer, IPlayer
    {
        Random rand = new Random();

        public ComputerPlayer(string name, Hand hand) : base(name, hand)
        {

        }

        public Card[] Attack(State state)
        {
            if (_hand.Cards.Count < 3)
            {
                return new Card[0];
            }
            return _hand.Cards.GetRange(0, 3).ToArray<Card>();
        }

        public Defence Defend(State state, Card[] attackingCards)
        {
            var d = new Defence();
            if (_hand.Cards.Count < 3)
            {
                return d;
            }
            if (attackingCards.Count<Card>() > 1)
            {
                d.Response[attackingCards[0]] = new Card[] { _hand.Cards[0] };
                d.Response[attackingCards[1]] = new Card[] { _hand.Cards[1] };
            }

            return d;
        }
    }
}
