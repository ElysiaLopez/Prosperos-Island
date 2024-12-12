using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperosIsland
{
    internal class MovingSprite : Sprite
    {
        protected Vector2 speed;

        public MovingSprite(Texture2D texture, Vector2 pos, Vector2 scale, Vector2 speed) : base(texture, pos, scale)
        {
            this.speed = speed;
        }

        public MovingSprite(Texture2D texture, Vector2 pos, Rectangle? src, Color col, float rot, Vector2 origin, Vector2 scale, SpriteEffects se, float layerDepth, Vector2 speed) : base(texture, pos, src, col, rot, origin, scale, se, layerDepth)
        {
            this.speed = speed;
        }
    }
}
