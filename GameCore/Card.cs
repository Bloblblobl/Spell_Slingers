using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class Card
    {
        public string Name;
        public int Attack;
        public int Defence;
        public int Cost;

        public override string  ToString()
        {
 	        return string.Format("{0}: {1}/{2}",  Name.PadRight(10), Attack, Defence);
        }
    }
}
