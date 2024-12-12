using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
//using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProsperosIsland
{
    internal class GameScreen : Screen
    {
        GraphicsDevice GraphicsDevice;
        GraphicsDeviceManager graphics;
        ContentManager Content;

        Texture2D pixel;

        Level Level1;
        Level[] Levels;
        int currLevel = 0;
        public GameScreen(GraphicsDevice graphicsDevice, ContentManager content, GraphicsDeviceManager graphics)
        {
            GraphicsDevice = graphicsDevice;
            Content = content;
            this.graphics = graphics;
        }

        public override void Load()
        {
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });


            #region frames
            Rectangle[] walkingRight =
            {
                new Rectangle(20, 718, 21, 48),
                new Rectangle(84, 719, 25, 47),
                new Rectangle(148, 718, 23, 47),
                new Rectangle(211, 718, 22, 47),
                new Rectangle(274, 718, 24, 48),
                new Rectangle(336, 719, 28, 47),
                new Rectangle(401, 718, 24, 48),
                new Rectangle(466, 718, 23, 48),
                new Rectangle(531, 718, 22, 48)
            };

            Rectangle[] walkingLeft =
            {
                new Rectangle(23, 590, 21, 48),
                new Rectangle(83, 591, 25, 47),
                new Rectangle(149, 590, 23, 47),
                new Rectangle(215, 590, 22, 47),
                new Rectangle(278, 590, 24, 48),
                new Rectangle(340, 591, 28, 47),
                new Rectangle(407, 590, 24, 48),
                new Rectangle(471, 590, 23, 48),
                new Rectangle(535, 590, 22, 48)
            };

            Rectangle[] walkingUp =
            {
                new Rectangle(16, 526, 32, 47),
                new Rectangle(80, 526, 32, 47),
                new Rectangle(144, 526, 31, 48),
                new Rectangle(208, 527, 31, 48),
                new Rectangle(272, 526, 31, 48),
                new Rectangle(336, 526, 32, 47),
                new Rectangle(401, 526, 31, 48),
                new Rectangle(465, 527, 31, 48),
                new Rectangle(529, 526, 31, 48)
            };

            Rectangle[] walkingDown =
            {
                new Rectangle(16, 654, 32, 48),
                new Rectangle(80, 654, 32, 48),
                new Rectangle(144, 654, 32, 49),
                new Rectangle(209, 655, 30, 48),
                new Rectangle(273, 654, 30, 49),
                new Rectangle(336, 654, 32, 48),
                new Rectangle(400, 654, 32, 49),
                new Rectangle(465, 655, 30, 48),
                new Rectangle(529, 654, 30, 49)
            };
            #endregion

            #region Level 1 Creation

            Player caliban;
            Sprite bread;
            Vector2 level1StartPos = new Vector2(200, 200);
            List<Platform> level1Platforms;
            List<Obstacle> level1Obstacles;


            Texture2D calibanTexture = Content.Load<Texture2D>("caliban_spritesheet");

            #region Caliban frames

            var calibanFrames = new Dictionary<Dirs, Rectangle[]>()
            {
                {Dirs.Right, walkingRight},
                {Dirs.Left,  walkingLeft},
                {Dirs.Top, walkingUp},
                {Dirs.Bottom, walkingDown}
            };

            #endregion


            caliban = new Player(calibanTexture, level1StartPos, walkingRight[0], Color.White, 0f, new Vector2(0, 0), new Vector2(2, 2), SpriteEffects.None, 0, new Vector2(8, 8), calibanFrames, Dirs.Bottom);

            level1Platforms = new List<Platform>()
            {
                new Platform(pixel, 0, 0, 120, graphics.PreferredBackBufferHeight), // left wall
                new Platform(pixel, 0, 0, graphics.PreferredBackBufferWidth, 120), // top wall
                new Platform(pixel, 0, graphics.PreferredBackBufferHeight - 120, graphics.PreferredBackBufferWidth, 120), //bottom
                new Platform(pixel, graphics.PreferredBackBufferWidth - 120, 0, 120, graphics.PreferredBackBufferHeight), // right
                new Platform(pixel, 400, 0, 100, 700),
                new Platform(pixel, 1100, 300, 100, 700),
            };

            Texture2D oPixel = new Texture2D(GraphicsDevice, 1, 1);
            oPixel.SetData(new Color[] { Color.Black });

            level1Obstacles = new List<Obstacle>()
            {
                new Obstacle(oPixel, new Vector2(980, 350), new Vector2(40, 40), new Vector2(-8, 0)),
                new Obstacle(oPixel, new Vector2(530, 450), new Vector2(40, 40), new Vector2(8, 0)),
                new Obstacle(oPixel, new Vector2(980, 550), new Vector2(40, 40), new Vector2(-8, 0)),
                new Obstacle(oPixel, new Vector2(530, 650), new Vector2(40, 40), new Vector2(8, 0)),
            };

            Texture2D breadTexture = Content.Load<Texture2D>("bread");
            bread = new Sprite(breadTexture, new Vector2(1250, 700), new Vector2(0.1f, 0.1f));

            Level1 = new Level(caliban, bread, level1StartPos, level1Platforms, level1Obstacles);
            #endregion

            #region Level 2 Creation

            Vector2 level2StartPos = new Vector2(200, 180);
            List<Platform> level2Platforms = new List<Platform>()
            {
                // height 1000, width 1500
                new Platform(pixel, 0, 0, 120, graphics.PreferredBackBufferHeight), // left wall
                new Platform(pixel, 0, 0, graphics.PreferredBackBufferWidth, 120), // top wall
                new Platform(pixel, 0, graphics.PreferredBackBufferHeight - 120, graphics.PreferredBackBufferWidth, 120), //bottom
                new Platform(pixel, graphics.PreferredBackBufferWidth - 120, 0, 120, graphics.PreferredBackBufferHeight), // right
                new Platform(pixel, 0, 300, 1000, 100),
                new Platform(pixel, 400, 550, 1000, 100),
            };
            List<Obstacle> level2Obstacles = new List<Obstacle>()
            {
                new Obstacle(oPixel, new Vector2(1100, 150), new Vector2(40, 40), new Vector2(0, 10)),
                new Obstacle(oPixel, new Vector2(1300, 480), new Vector2(40, 40), new Vector2(0, -10)),
                new Obstacle(oPixel, new Vector2(200, 570), new Vector2(40, 40), new Vector2(5, 0)),
                new Obstacle(oPixel, new Vector2(400, 700), new Vector2(40, 40), new Vector2(0, 7)),
                new Obstacle(oPixel, new Vector2(580, 790), new Vector2(40, 40), new Vector2(0, -7)),
                new Obstacle(oPixel, new Vector2(760, 700), new Vector2(40, 40), new Vector2(0, 7)),
                new Obstacle(oPixel, new Vector2(940, 790), new Vector2(40, 40), new Vector2(0, -7)),
            };

            var mirandaFrames = new Dictionary<Dirs, Rectangle[]>()
            {
                {Dirs.Right, walkingRight },
                {Dirs.Left, walkingLeft},
                {Dirs.Top, walkingUp},
                {Dirs.Bottom, walkingDown}
            };

            Texture2D mirandaSpritesheet = Content.Load<Texture2D>("miranda_spritesheet");
            Texture2D ferdinandTexture = Content.Load<Texture2D>("ferdinand");
            Player miranda = new Player(mirandaSpritesheet, new Vector2(100, 100), walkingRight[0], Color.White, 0, Vector2.Zero, new Vector2(2f, 2f), SpriteEffects.None, 0, new Vector2(10, 10), mirandaFrames, Dirs.Right);
            Sprite ferdinand = new Sprite(ferdinandTexture, new Vector2(1200, 650), new Vector2(0.2f, 0.2f));

            Level level2 = new Level(miranda, ferdinand, level2StartPos, level2Platforms, level2Obstacles);
            #endregion

            Levels = new Level[] { Level1, level2 };

            Levels[currLevel].ResetLevel();
        }

        public override Screens Update(GameTime gt)
        {
            bool finished = Levels[currLevel].Update(gt);

            if (finished)
            {
                if (currLevel < Levels.Length - 1)
                {
                    currLevel++;
                    Levels[currLevel].ResetLevel();
                }
                else
                {
                    return Screens.EndScreen;
                }
            }

            return Screens.GameScreen;
        }

        public override void Draw(SpriteBatch sb)
        {
            Levels[currLevel].Draw(sb);
        }
    }
}
