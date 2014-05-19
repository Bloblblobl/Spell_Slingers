using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public interface IPlayer
    {
        Card[] Attack(State state);
        Defence Defend(State state, Card[] attackingCards);

        int Life { get; set; }
        string Name { get; }
    }
}
