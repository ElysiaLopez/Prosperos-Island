using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProsperosIsland
{
    internal class Platform : MovingSprite
    {
        public Platform(Texture2D texture, float x, float y, float width, float height) : this(texture, new Vector2(x, y), new Vector2(width, height), Vector2.Zero) { }
        public Platform(Texture2D texture, Vector2 pos, Vector2 scale, Vector2 speed) : base(texture, pos, scale, speed)
        {
            Color = Color.LightSkyBlue;
        }
    }
}
