using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class State
    {
        public bool GameOver;

        public IPlayer ActivePlayer;
        public IPlayer OtherPlayer;

        public Hand ActiveHand;
        public Hand OtherHand;

        public State(IPlayer player1, IPlayer player2, Hand hand1, Hand hand2)
        {
            GameOver = false;
            ActivePlayer = player1;
            OtherPlayer = player2;
            ActiveHand = hand1;
            OtherHand = hand2;
        }

        public void EndTurn()
        {
            // Switch active player
            var temp = ActivePlayer;
            ActivePlayer = OtherPlayer;
            OtherPlayer = temp;

            // Switch active hand
            var temp2 = ActiveHand;
            ActiveHand = OtherHand;
            OtherHand = temp2;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
