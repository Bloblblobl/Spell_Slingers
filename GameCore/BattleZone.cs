using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class BattleZone
    {
        public List<Card> Cards = new List<Card>();

        public BattleZone(List<Card> cards)
        {
            Cards = cards;
        }
    }
}
