using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using SharpDX.DirectWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperosIsland
{
    internal class Player : AnimatedSprite
    {
        Dictionary<Dirs, Platform> intersectedPlatforms;
        Dictionary<Platform, (Dirs dir, float dist)> intersectedDistances;
        List<Platform> platforms;

        public Player(Texture2D texture, Vector2 pos, Rectangle? src, Color col, float rot, Vector2 origin, Vector2 scale, SpriteEffects se, float layerDepth, Vector2 speed, Dictionary<Dirs, Rectangle[]> frames, Dirs dir) : base(texture, pos, col, rot, origin, scale, se, layerDepth, speed, frames, dir)
        {
            this.speed = speed;

            intersectedPlatforms = new Dictionary<Dirs, Platform>(){
                {Dirs.Left, null },
                {Dirs.Right, null },
                {Dirs.Top, null },
                {Dirs.Bottom, null }
            };

            intersectedDistances = new Dictionary<Platform, (Dirs dir, float dist)>();
        }

        public void SetPlatforms(List<Platform> platforms)
        {
            this.platforms = platforms;
        }

        public override void Update(GameTime gt)
        {
            base.Update(gt);

            var ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Right))
            {
                x += speed.X;
                changeDir(Dirs.Right);
            }
            else if (ks.IsKeyDown(Keys.Left))
            {
                x -= speed.X;
                changeDir(Dirs.Left);
            }
            else if (ks.IsKeyDown(Keys.Up))
            {
                y -= speed.Y;
                changeDir(Dirs.Top);
            }
            else if (ks.IsKeyDown(Keys.Down))
            {
                y += speed.Y;
                changeDir(Dirs.Bottom);
            }

            bool intersectingPlat = updateIntersections(platforms);

            if(intersectingPlat)
            {
                float clampedX = x;
                float clampedY = y;

                foreach(KeyValuePair<Dirs, Platform> kvp in intersectedPlatforms)
                {
                    Dirs dir = kvp.Key;
                    Platform plat = kvp.Value;

                    if (plat == null) continue;

                    if(dir == Dirs.Left)
                    {
                        clampedX = plat.HitBox.Right;
                    }
                    else if(dir == Dirs.Right)
                    {
                        clampedX = plat.HitBox.Left - width;
                    }
                    else if(dir == Dirs.Top)
                    {
                        clampedY = plat.HitBox.Bottom;
                    }
                    else if(dir == Dirs.Bottom)
                    {
                        clampedY = plat.HitBox.Top - height;
                    }
                }

                x = clampedX;
                y = clampedY;
            }
        }

        private void updateIntersection(float amountIntersected, Dirs dir, Platform p)
        {
            //is the platform intersecting in multiple directions? if so, only store the closest dir 
            bool shouldReplace = !intersectedDistances.ContainsKey(p) || intersectedDistances[p].dist > amountIntersected;

            if (shouldReplace) 
            {
                if (!intersectedDistances.ContainsKey(p))
                {
                    intersectedDistances.Add(p, (0, 0));
                }

                foreach(Dirs d in intersectedPlatforms.Keys)
                {
                    if (intersectedPlatforms[d] == p)
                    {
                        intersectedPlatforms[d] = null;
                    }
                }

                intersectedPlatforms[dir] = p;
                intersectedDistances[p] = (dir, amountIntersected);
            }
        }

        private bool updateIntersections(List<Platform> platforms)
        {
            foreach(Dirs dir in intersectedPlatforms.Keys)
            {
                intersectedPlatforms[dir] = null; // clear intersected platforms
            }

            intersectedDistances.Clear();

            bool isIntersectingPlatform = false;

            foreach (var p in platforms)
            {
                if (HitBox.Intersects(p.HitBox))
                {
                    isIntersectingPlatform = true;
                }
                else continue;

                if (left.Intersects(p.HitBox))
                {
                    float amountIntersected = Math.Abs(p.HitBox.Right - left.X);
                    updateIntersection(amountIntersected, Dirs.Left, p);
                }
                if(right.Intersects(p.HitBox))
                {
                    float amountIntersected = Math.Abs(right.X - p.HitBox.Left);
                    updateIntersection(amountIntersected, Dirs.Right, p);
                }
                if(top.Intersects(p.HitBox))
                {
                    float amountIntersected = Math.Abs(p.HitBox.Bottom - top.Y);
                    updateIntersection(amountIntersected, Dirs.Top, p);
                }
                if(bottom.Intersects(p.HitBox))
                {
                    float amountIntersected = Math.Abs(bottom.Y - p.HitBox.Top);
                    updateIntersection(amountIntersected, Dirs.Bottom, p);
                }
            }

            return isIntersectingPlatform;
        }
    }
}
