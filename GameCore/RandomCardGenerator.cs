using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class RandomCardGenerator
    {
        static int index = 1;
        static Random rand = new Random();

        public static Card generateCard(int min, int max)
        {
            var c = new Card();
            c.Name = "Creature_" + index.ToString();
            c.Attack = rand.Next(min, max);
            c.Defence = rand.Next(min, max);

            index++;

            return c;
        }
    }
}
