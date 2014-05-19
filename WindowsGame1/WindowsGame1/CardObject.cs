using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCore;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    class CardObject
    {
        public Card card = new Card();
        public Texture2D texture;
        public Vector2 location = new Vector2(0,0);
        public bool flipped = false;

        int factor = 1;
        float textFactor = 0.8f;

        const int border = 4;
        const int fill = 4;
        const int headerHeight = 12;

        int height = 192;
        int width = 128;

        Rectangle imgBounds = new Rectangle(0, 0, 96, 96);

        public CardObject()
        {

        }

        public CardObject(Texture2D _texture, Vector2 _location, int _height, int _width, int _factor)
        {
            texture = _texture;
            location = _location;
            height = _height;
            width = _width;
            factor = _factor;
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics, SpriteFont font)
        {
            DrawBackground(spriteBatch, graphics);
            if (!flipped)
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

            Texture2D rect = new Texture2D(graphics, width * factor, height * factor);

            Color[] data = new Color[width * height * factor * factor];
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = Color.Black;
            }
            rect.SetData(data);

            spriteBatch.Draw(rect, location, Color.White);
        }

        private void DrawFill(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            // Draw the Fill

            int bord = 4;
            var w = width - bord;
            var h = height - bord;

            Texture2D rect = new Texture2D(graphics, w * factor, h * factor);

            Color[] data = new Color[w * h * factor * factor];
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = Color.Wheat;
            }
            rect.SetData(data);

            var bordLocation = new Vector2((location.X + bord / 2 * factor), (location.Y + bord / 2 * factor));

            spriteBatch.Draw(rect, bordLocation, Color.White);
        }

        private void DrawImage(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            // Draw the Image

            var dx = (border + fill) * 2 * factor;
            var dy = ((border + fill) * 2 + headerHeight) * factor;

            var bounds = new Rectangle((int)(location.X + dx), 
                                       (int)(location.Y + dy), 
                                       imgBounds.Width * factor, 
                                       imgBounds.Height * factor);

            spriteBatch.Draw(texture, bounds, Color.White); 
        }

        private void DrawHeader(SpriteBatch spriteBatch, GraphicsDevice graphics, SpriteFont font)
        {
            // Draw the Name

            var dx = (border + fill) * factor;
            var dy = (border + fill) * factor;

            var bounds = new Vector2((int)(location.X + dx),
                                       (int)(location.Y + dy));

            spriteBatch.DrawString(font, "Name", bounds, Color.Black, 0, Vector2.Zero, textFactor, SpriteEffects.None, 0);
        }

        private void DrawStats(SpriteBatch spriteBatch, GraphicsDevice graphics, SpriteFont font)
        {
            // Draw Power/Toughness
        }

        private void DrawText(SpriteBatch spriteBatch, GraphicsDevice graphics, SpriteFont font)
        {
            // Draw Rules Text

            var dx = (border + fill) * factor;
            var dy = ((border + fill) * 3 + headerHeight + imgBounds.Height) * factor;

            var bounds = new Vector2((int)(location.X + dx),
                                     (int)(location.Y + dy));

            spriteBatch.DrawString(font, "Text", bounds, Color.Black, 0, Vector2.Zero, textFactor, SpriteEffects.None, 0);
        }

    }
}
