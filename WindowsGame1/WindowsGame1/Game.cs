using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameCore;

namespace GameMain
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        CardObject[] cards = new CardObject[10];
        SpriteFont font;

        // Test Variables
        CursorObject _cursor;
        HandObject _topHand;
        HandObject _bottomHand;
        CardDatabase _cardsDB = new CardDatabase();
        Vector2 location;
        int height = 192;
        int width = 128;
        Random rand = new Random();
        int factor = 2;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            var form = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(this.Window.Handle);
            form.Location = new System.Drawing.Point(0, 0);
        }

        private void PopulateCardsDatabase()
        {
            var texture = Content.Load<Texture2D>("arrowed");
            var card = new Card { Attack = 3, Defence = 4, Cost = 5, Name = "arrowed" };
            _cardsDB.Add(card, texture);

            texture = Content.Load<Texture2D>("bleeding-heart");
            card = new Card { Attack = 4, Defence = 5, Cost = 3, Name = "heart" };
            _cardsDB.Add(card, texture);

            texture = Content.Load<Texture2D>("boiling-bubbles");
            card = new Card { Attack = 5, Defence = 3, Cost = 4, Name = "bubbles" };
            _cardsDB.Add(card, texture);
        }




        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("font");

            

            PopulateCardsDatabase();
            CreateCursor();
            CreateHands();

            //CreateCards();

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            var mouseState = Mouse.GetState();

            _cursor.Location = new Vector2(mouseState.X, mouseState.Y);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            _topHand.Draw(spriteBatch, graphics.GraphicsDevice, font);
            _bottomHand.Draw(spriteBatch, graphics.GraphicsDevice, font);
            _cursor.Draw(spriteBatch, graphics.GraphicsDevice, font);
            //foreach (var c in cards)
            //{
            //    c.Draw(spriteBatch, graphics.GraphicsDevice, font);
            //}
            spriteBatch.End();

            base.Draw(gameTime);
        }

        void CreateHands()
        {
            _topHand = CreateHand(true);
            _bottomHand = CreateHand(false);
        }

        HandObject CreateHand(bool topHand)
        {
            var hand = new Hand(false);
            for (int i = 0; i < 7; i++)
            {
                hand.Cards.Add(_cardsDB.SelectRandomCard());
            }
            var handObject = new HandObject(hand, topHand, height, width, _cardsDB);
            return handObject;
        }

        //void CreateCards()
        //{
        //    for (int i = 0; i < cards.Length; i++)
        //    {
        //        double cardsPerRow = graphics.PreferredBackBufferWidth / (width * factor);

        //        int row = (int)Math.Floor((i / cardsPerRow));

        //        var x = ((i * width) - (row * (float)cardsPerRow * width)) * factor;
        //        var y = (row * height) * factor;
        //        location = new Vector2(x, y);

        //        cards[i] = new CardObject(new Texture2D(), location, height, width, factor);
        //    }
        //}

        void CreateCursor()
        {
            var cursorTexture = Content.Load<Texture2D>("Cursor");
            var b = graphics.GraphicsDevice.Viewport.Bounds;
            var location = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

            _cursor = new CursorObject(true, cursorTexture, location);
        }
    }
}
