using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCore;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameMain
{
    class HandObject
    {
        private Hand _hand = null;
        private int _cardHeight;
        private int _cardWidth;
        private bool _topHand;
        private CardDatabase _cardsDB;

        public HandObject(Hand hand, bool topHand, int cardHeight, int cardWidth, CardDatabase cardsDB)
        {
            _hand = hand;
            _cardHeight = cardHeight;
            _cardWidth = cardWidth;
            _topHand = topHand;
            _cardsDB = cardsDB;
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics, SpriteFont font)
        {
            // Calculate hand location on screen
            var screenWidth = graphics.PresentationParameters.BackBufferWidth;
            var y = _topHand ? 0 : graphics.PresentationParameters.BackBufferHeight - _cardHeight;
            var initHorizontalOffset = (screenWidth - _hand.Cards.Count * _cardWidth) / 2;

            // Create CardObject for each card in hand
            var cards = new List<CardObject>();
            foreach (var c in _hand.Cards.Select((x,i) => new { Card = x, Index = i }) )
            {
                var location = new Vector2(initHorizontalOffset + _cardWidth * c.Index, y);
                var texture = _cardsDB.LookupTexture(c.Card);
                var card = new CardObject(texture, location, _cardHeight, _cardWidth, 1);
                cards.Add(card);
            }


            // Loop through CardObjects and let them draw themselves in the right position
            foreach (var c in cards)
            {
                c.Draw(spriteBatch, graphics, font);
            }

        }
    }
}
