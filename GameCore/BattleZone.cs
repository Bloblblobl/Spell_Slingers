using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class BattleZone
    {
        public List<Card> Cards = new List<Card>();

        private static int defaultCapacity = 3;
        public int Capacity = defaultCapacity;

        public int AvailableSlots
        {
            get { return Capacity - Cards.Count; }
        }

        public BattleZone(List<Card> cards)
        {
            Cards = cards;
            
        }
    }
}
