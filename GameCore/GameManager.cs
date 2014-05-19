using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class GameManager
    {
        public static void Play(State state)
        {
            // Alternate turns until game over
            while (!state.GameOver)
            {
                // Active player draws a card
                state.ActiveHand.Cards.Add(RandomCardGenerator.generateCard(1, 4));

                // Allow active player to attack
                var attackCards = state.ActivePlayer.Attack(state);

                // Allow other player to defend
                var defence = state.OtherPlayer.Defend(state, attackCards.ToArray<Card>());
                
                // If an attacking card was not blocked, it deals it's damage to the opponent
                foreach (Card c in attackCards)
                {
                    if (!defence.Response.Keys.Contains<Card>(c))
                    {
                        state.OtherPlayer.Life -= c.Attack;
                    }
                }
                
                // Compute battle damage to cards (Taking into account only the first defender)
                foreach (KeyValuePair<Card, Card[]> entry in defence.Response)
                {
                    var attackCard = entry.Key;
                    var defenceCard = entry.Value[0];

                    // If attacking card's Attack >= defending card's Defence, then defending card is destroyed
                    if (attackCard.Attack >= defenceCard.Defence)
                    {
                        state.OtherHand.Cards.Remove(defenceCard);
                    }

                    // If attacking card's Defence <= defending card's Attack, the attacking card is destroyed
                    if (defenceCard.Attack >= attackCard.Defence)
                    {
                        state.ActiveHand.Cards.Remove(attackCard);
                    }
                }
                
                state.EndTurn();
            }
        }
    }
}
