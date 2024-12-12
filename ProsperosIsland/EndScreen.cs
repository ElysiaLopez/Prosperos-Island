using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProsperosIsland
{
    internal class EndScreen : Screen
    {
        ContentManager Content;

        SpriteFont instructionsFont;

        string completeText;
        string displayText = "";
        float typingDelay = 10;
        int typeIndex = 0;
        TimeSpan elapsedTime;

        float beginningDelay = 2000;
        bool waited = false;

        public EndScreen(ContentManager content)
        {
            Content = content;
        }
        public override void Load()
        {
            instructionsFont = Content.Load<SpriteFont>("InstructionsFont");
            elapsedTime = TimeSpan.Zero;

            completeText = "\"Confined together \nIn the same fashion as you gave in charge, \nJust as you left them; all prisoners, sir,\nIn the line grove which weather-fends your cell.\nThey cannot budge till your release.\nThey abide all three distracted,\nAnd the remainder mourning over them,\nBrimful of sorrow and dismay\nYour charm so strongly works them\nThat if you now beheld them, your affections\nWould become tender.\n\nMine would, were I human.\"";

        }
        public override Screens Update(GameTime gt)
        {
            elapsedTime += gt.ElapsedGameTime;

            if(!waited)
            {
                if (elapsedTime.TotalMilliseconds > beginningDelay)
                {
                    waited = true;
                    elapsedTime = TimeSpan.Zero;
                }
                else return Screens.EndScreen;
            }

            if(typeIndex < completeText.Length)
            {
                if(elapsedTime.Milliseconds > typingDelay)
                {
                    displayText += completeText[typeIndex];
                    typeIndex++;
                    elapsedTime = TimeSpan.Zero;
                }
            }

            return Screens.EndScreen;
        }
        public override void Draw(SpriteBatch sb)
        {
            sb.DrawString(instructionsFont, displayText, new Vector2(50, 50), Color.Black);
        }
    }
}
