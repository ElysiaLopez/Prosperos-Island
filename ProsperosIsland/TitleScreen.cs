using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperosIsland
{
    internal class TitleScreen : Screen
    {
        ContentManager Content;
        GraphicsDevice GraphicsDevice;

        Texture2D pixel;

        SpriteFont titleFont;
        string titleText = "Prospero's Island";
        Vector2 screenSize;

        Button startButton;
        Button instructionsButton;
        TextWindow instructionsWindow;
        SpriteFont instructionsFont;

        bool showInstructions = false;
        public TitleScreen(ContentManager content, GraphicsDevice gd, Vector2 screenSize)
        {
            Content = content;
            GraphicsDevice = gd;
            this.screenSize = screenSize;
        }
        public override void Load()
        {
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            titleFont = Content.Load<SpriteFont>("TitleFont");
            instructionsFont = Content.Load<SpriteFont>("InstructionsFont");

            string instructions = "Use the arrow keys to move. Avoid hitting the \nmoving obstacles or you'll reset at the beginning. \nCollect the level item to pass the level.";

            SpriteFont buttonFont = Content.Load<SpriteFont>("ButtonFont");
            startButton = new Button(pixel, new Vector2(600, 500), new Vector2(350, 150), Color.Green, Color.DarkGreen, Color.White, buttonFont, "Start Game");
            instructionsButton = new Button(pixel, new Vector2(600, 700), new Vector2(350, 150), Color.Green, Color.DarkGreen, Color.White, buttonFont, "Instructions");
            instructionsWindow = new TextWindow(pixel, new Vector2(350, 100), new Vector2(800, 800), Color.Black, instructionsFont, instructions, Color.White);
        }
        public override Screens Update(GameTime gt)
        {
            startButton.Update(gt);
            instructionsButton.Update(gt);

            if(startButton.IsClicked())
            {
                return Screens.GameScreen;
            }

            if(instructionsButton.IsClicked())
            {
                showInstructions = true;
            }

            if(instructionsWindow.ClickedClose())
            {
                showInstructions = false;
            }

            if (showInstructions)
            {
                instructionsWindow.Update(gt);
            }

            return Screens.TitleScreen;
        }
        public override void Draw(SpriteBatch sb)
        {
            Vector2 stringSize = titleFont.MeasureString(titleText);
            Vector2 screenCenter = screenSize / 2;

            sb.DrawString(titleFont, titleText, new Vector2(screenCenter.X - stringSize.X / 2, 200), Color.Black);
            startButton.Draw(sb);
            instructionsButton.Draw(sb);

            if(showInstructions)
            {
                instructionsWindow.Draw(sb);
            }
                

        }
    }
}
