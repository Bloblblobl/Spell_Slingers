using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCore;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace GameMain
{
    class BattleZoneObject : IGameObject
    {
        private BattleZone _battleZone = null;
        private int _cardHeight;
        private int _cardWidth;
        private bool _topZone;
        private CardDatabase _cardsDB;
        private List<CardObject> _cards;
        private MouseState _mouseState;
        private KeyboardState _keyboardState;
        private int _factor;

        public BattleZoneObject(BattleZone battleZone, bool topZone, int cardHeight, int cardWidth, CardDatabase cardsDB, int factor = 1)
        {
            _battleZone = battleZone;
            _cardHeight = cardHeight;
            _cardWidth = cardWidth;
            _topZone = topZone;
            _cardsDB = cardsDB;
            _factor = factor;
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics, SpriteFont font)
        {
            // Calculate zone location on screen
            var screenHeight = graphics.PresentationParameters.BackBufferHeight;
            var screenWidth = graphics.PresentationParameters.BackBufferWidth;
            var padding = 5;
            var factoredPadding = padding * _factor;

            var height = (_cardHeight + 2 * factoredPadding);
            var width = ((_cardWidth + factoredPadding) * _battleZone.Capacity + factoredPadding);
             
            var offset = ((height + padding * 10) * _factor) / 2;
            var top = screenHeight / 2 - (_topZone ? offset : - offset - factoredPadding + height);
            var left = (screenWidth - width) / 2; 

            var cardsTop = top + factoredPadding;
            var cardsLeft = left + factoredPadding;
            

            // Create CardObject for each card in hand
            var cards = new List<CardObject>();

            var m = new Point(_mouseState.X, _mouseState.Y);
            var cardCount = 0;

            // Draw the Zone
            
            DrawZone(spriteBatch, graphics, Color.Purple, left, top, width, height);

            // Draw the Cards
            foreach (var c in _battleZone.Cards.Select((x,i) => new { Card = x, Index = i }) )
            {
                var location = new Vector2(cardsLeft + (_cardWidth + padding) * _factor, cardsTop);
                var texture = _cardsDB.LookupTexture(c.Card);

                var cardBounds = new Rectangle ((int)location.X, (int)location.Y, _cardWidth, _cardHeight);
                var selected = cardBounds.Contains(m);

                var card = new CardObject(texture, location, _cardHeight, _cardWidth, 1, c.Card.FaceDown, selected);
                cards.Add(card);
                cardCount++;
            }

            // Creates empty Cards to fill in the BattleZone
            for (var i = 0; i < _battleZone.AvailableSlots; i++)
            {
                var location = new Vector2(cardsLeft + cardCount * (_cardWidth + factoredPadding), cardsTop);
                var cardBounds = new Rectangle((int)location.X, (int)location.Y, _cardWidth, _cardHeight);
                var selected = cardBounds.Contains(m);

                cards.Add(new CardObject(null, location, _cardHeight, _cardWidth, 1, false, selected, true));
                cardCount++;
            }


            // Loop through CardObjects and let them draw themselves in the right position
            foreach (var c in cards)
            {
                c.Draw(spriteBatch, graphics, font);
            }

        }


        public void Update(MouseState mouseState, KeyboardState keyboardState)
        {
            _mouseState = mouseState;
            _keyboardState = keyboardState;
        }

        private void DrawZone(SpriteBatch spriteBatch, GraphicsDevice graphics, Color color, int x, int y, int width, int height)
        {
            Texture2D rect = new Texture2D(graphics, width, height);
            var location = new Vector2(x, y);

            Color[] data = new Color[width * height];
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = color;
            }
            rect.SetData(data);

            spriteBatch.Draw(rect, location, Color.White);
        }
    }
}
