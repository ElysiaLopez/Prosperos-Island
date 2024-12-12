using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace ProsperosIsland
{
    internal class TextWindow : Sprite
    {
        SpriteFont Font;
        string Text;
        Color TextColor;

        Button closeButton;
        public TextWindow(Texture2D texture, Vector2 pos, Vector2 scale, Color windowColor, SpriteFont font, string text, Color textColor) : base(texture, pos, scale)
        {
            Font = font;
            Text = text;
            TextColor = textColor;
            Color = windowColor;

            Vector2 buttonSize = new Vector2(70, 70);
            closeButton = new Button(texture, new Vector2(right.X - buttonSize.X, top.Y), buttonSize, Color.Purple, Color.MediumPurple, Color.White, font, "X");
        }

        public bool ClickedClose() => closeButton.IsClicked();

        public override void Update(GameTime gt)
        {
            closeButton.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);

            sb.DrawString(Font, Text, new Vector2(Position.X + 20, Position.Y + 20), TextColor);
            closeButton.Draw(sb);
        }
    }
}
