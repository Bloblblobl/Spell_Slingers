using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCore;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameMain
{
    class CardObject
    {
        public Card _card = new Card();
        public Texture2D _texture;
        public Vector2 _location = new Vector2(0,0);
        public bool _flipped = false;

        int _factor = 1;
        float _textFactor = 0.8f;

        const int _border = 4;
        const int _fill = 4;
        const int _headerHeight = 12;

        int _height = 192;
        int _width = 128;

        Rectangle _imgBounds = new Rectangle(0, 0, 96, 96);

        public CardObject()
        {

        }

        public CardObject(Texture2D texture, Vector2 location, int height, int width, int factor)
        {
            _texture = texture;
            _location = location;
            _height = height;
            _width = width;
            _factor = factor;
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics, SpriteFont font)
        {
            DrawBackground(spriteBatch, graphics);
            if (!_flipped)
            {
                DrawFill(spriteBatch, graphics);
                DrawImage(spriteBatch, graphics);
                DrawHeader(spriteBatch, graphics, font);
                DrawText(spriteBatch, graphics, font);
            }
        }

        private void DrawBackground(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            // Draw the Border

            Texture2D rect = new Texture2D(graphics, _width * _factor, _height * _factor);

            Color[] data = new Color[_width * _height * _factor * _factor];
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = Color.Black;
            }
            rect.SetData(data);

            spriteBatch.Draw(rect, _location, Color.White);
        }

        private void DrawFill(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            // Draw the Fill

            int bord = 4;
            var w = _width - bord;
            var h = _height - bord;

            Texture2D rect = new Texture2D(graphics, w * _factor, h * _factor);

            Color[] data = new Color[w * h * _factor * _factor];
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = Color.Wheat;
            }
            rect.SetData(data);

            var bordLocation = new Vector2((_location.X + bord / 2 * _factor), (_location.Y + bord / 2 * _factor));

            spriteBatch.Draw(rect, bordLocation, Color.White);
        }

        private void DrawImage(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            // Draw the Image

            var dx = (_border + _fill) * 2 * _factor;
            var dy = ((_border + _fill) * 2 + _headerHeight) * _factor;

            var bounds = new Rectangle((int)(_location.X + dx), 
                                       (int)(_location.Y + dy), 
                                       _imgBounds.Width * _factor, 
                                       _imgBounds.Height * _factor);

            spriteBatch.Draw(_texture, bounds, Color.White); 
        }

        private void DrawHeader(SpriteBatch spriteBatch, GraphicsDevice graphics, SpriteFont font)
        {
            // Draw the Name

            var dx = (_border + _fill) * _factor;
            var dy = (_border + _fill) * _factor;

            var bounds = new Vector2((int)(_location.X + dx),
                                       (int)(_location.Y + dy));

            spriteBatch.DrawString(font, "Name", bounds, Color.Black, 0, Vector2.Zero, _textFactor, SpriteEffects.None, 0);
        }

        private void DrawStats(SpriteBatch spriteBatch, GraphicsDevice graphics, SpriteFont font)
        {
            // Draw Power/Toughness
        }

        private void DrawText(SpriteBatch spriteBatch, GraphicsDevice graphics, SpriteFont font)
        {
            // Draw Rules Text

            var dx = (_border + _fill) * _factor;
            var dy = ((_border + _fill) * 3 + _headerHeight + _imgBounds.Height) * _factor;

            var bounds = new Vector2((int)(_location.X + dx),
                                     (int)(_location.Y + dy));

            spriteBatch.DrawString(font, "Text", bounds, Color.Black, 0, Vector2.Zero, _textFactor, SpriteEffects.None, 0);
        }

    }
}
