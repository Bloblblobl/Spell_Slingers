using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameMain
{
    class CursorObject : IGameObject
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
                //spriteBatch.Draw(_texture, _location, Color.White);

                var rect = new Rectangle((int)_location.X, (int)_location.Y, _texture.Width, _texture.Height);
                spriteBatch.Draw(_texture, rect, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, 0f);
            }
        }


        public void Update(MouseState mouseState, KeyboardState keyboardState)
        {
            _location.X = mouseState.X;
            _location.Y = mouseState.Y;
        }
    }
}
