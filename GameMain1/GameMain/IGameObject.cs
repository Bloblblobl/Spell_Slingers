using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameMain
{
    interface IGameObject
    {
        void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics, SpriteFont font);
        void Update(MouseState mouseState, KeyboardState keyboardState);
    }
}
