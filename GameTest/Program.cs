using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCore;

namespace GameTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var humanHand = new Hand();
            var compHand1 = new Hand();
            //var compHand2 = new Hand();

            var human = new HumanPlayer("Gary", humanHand);
            var comp1 = new ComputerPlayer("Bob", compHand1);
            //var comp2 = new ComputerPlayer("Jane", compHand2);
           
            //var state = new State(comp1, comp2, compHand1, compHand2);
            var state = new State(human, comp1, humanHand, compHand1);

            GameManager.Play(state);


        }
    }
}
