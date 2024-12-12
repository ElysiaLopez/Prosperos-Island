using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperosIsland
{
    internal class Button : Sprite
    {
        SpriteFont font;
        Color unselected;
        Color selected;
        Color textColor;
        string text;

        public Button(Texture2D texture, Vector2 pos, Vector2 scale, Color unselected, Color selected, Color textColor, SpriteFont font, string text) : base(texture, pos, scale)
        {
            this.unselected= unselected;
            this.selected = selected;
            this.font = font;
            this.text = text;
            this.textColor = textColor;

            Color = unselected;
        }

        public bool IsClicked()
        {
            MouseState ms = Mouse.GetState();
            return HitBox.Contains(ms.Position) && ms.LeftButton == ButtonState.Pressed;
        }

        public override void Update(GameTime gt)
        {
            MouseState ms = Mouse.GetState();

            if(HitBox.Contains(ms.Position))
            {
                Color = selected;
            }
            else
            {
                Color = unselected;
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);

            Vector2 textSize = font.MeasureString(text);
            Vector2 buttonCenter = new Vector2(x + width / 2, y + height / 2);

            sb.DrawString(font, text, new Vector2(buttonCenter.X - textSize.X / 2, buttonCenter.Y - textSize.Y / 2), textColor);
        }
    }
}
