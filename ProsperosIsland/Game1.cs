using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ProsperosIsland
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        Screens currScreen;

        GameScreen gameScreen;
        TitleScreen titleScreen;
        EndScreen endScreen;

        Dictionary<Screens, Screen> screensMap;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1500;
            graphics.PreferredBackBufferHeight= 1000;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var screenSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            gameScreen = new GameScreen(GraphicsDevice, Content, graphics);
            titleScreen = new TitleScreen(Content, GraphicsDevice, screenSize);
            endScreen = new EndScreen(Content);

            screensMap = new Dictionary<Screens, Screen>()
            {
                { Screens.TitleScreen, titleScreen},
                { Screens.GameScreen, gameScreen},
                { Screens.EndScreen, endScreen },
            };

            currScreen = Screens.TitleScreen;

            screensMap[currScreen].Load();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Screens screen = screensMap[currScreen].Update(gameTime);

            if(screen != currScreen)
            {
                currScreen = screen;
                screensMap[currScreen].Load();
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LemonChiffon);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            screensMap[currScreen].Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}