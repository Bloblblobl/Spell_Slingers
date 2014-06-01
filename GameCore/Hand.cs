using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class Hand
    {
        public List<Card> Cards = new List<Card>();

        public Hand(bool generateRandomCards)
        {
            if (!generateRandomCards)
            {
                return;
            }
            for (var i = 0; i < 7; i++)
            {
                var c = RandomCardGenerator.generateCard(3, 10);
                Cards.Add(c);
            }
        }
    }
}
