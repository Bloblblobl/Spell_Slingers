using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class BasePlayer
    {
        protected string _name;
        protected int _life = 20;
        protected Hand _hand;

        public BasePlayer(string name, Hand hand)
        {
            _name = name;
            _hand = hand;
        }

        public int Life
        {
            get { return _life; }
            set { _life = value; }
        }

        public string Name
        {
            get { return _name; }
        }
    }
}
