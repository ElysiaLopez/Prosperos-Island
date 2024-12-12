using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperosIsland
{
    internal class Obstacle : MovingSprite
    {
        public Obstacle(Texture2D texture, Vector2 pos, Vector2 scale, Vector2 speed) : base(texture, pos, scale, speed)
        {
        }

        public void Update(List<Platform> platforms)
        {
            x += speed.X;
            y += speed.Y;

            foreach(var p in platforms)
            {
                if (!HitBox.Intersects(p.HitBox))
                {
                    speed = new Vector2(speed.X * -1, speed.Y * -1);
                }
            }
        }
    }
}
