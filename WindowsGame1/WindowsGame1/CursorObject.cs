using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameMain
{
    class CursorObject
    {
        bool _isVisible = true;
        Texture2D _texture;
        public Vector2 _location;

        public Vector2 Location
        {
            set { _location = value; }
        }

        public CursorObject(bool isVisible, Texture2D texture, Vector2 location)
        {
            _isVisible = isVisible;
            _texture = texture;
            _location = location;
        }


        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics, SpriteFont font)
        {
            if (_isVisible)
            {
                spriteBatch.Draw(_texture, _location, Color.White);
            }
        }
    }
}
