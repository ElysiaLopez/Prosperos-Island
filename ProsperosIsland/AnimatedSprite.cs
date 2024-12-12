using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keyboard = Microsoft.Xna.Framework.Input.Keyboard;

namespace ProsperosIsland
{
    internal class AnimatedSprite : MovingSprite
    {
        Dictionary<Dirs, Rectangle[]> frames = new Dictionary<Dirs, Rectangle[]>();
        protected Dirs currDir { get; private set; }
        protected Rectangle[] currFrames => frames[currDir];
        protected int currFrameIndex { get; set; }

        TimeSpan timeSinceLastUpdate;
        float incrementTime = 100;
        public AnimatedSprite(Texture2D texture, Vector2 pos, Color col, float rot, Vector2 origin, Vector2 scale, SpriteEffects se, float layerDepth, Vector2 speed, Dictionary<Dirs, Rectangle[]> frames, Dirs currDir) : base(texture, pos, frames[currDir][0], col, rot, origin, scale, se, layerDepth, speed)
        {
            this.frames = frames;
            this.currDir = currDir;
            timeSinceLastUpdate = TimeSpan.Zero;
        }

        protected void changeDir(Dirs newDir)
        {
            if(currDir != newDir)
            {
                currDir = newDir;
                currFrameIndex = 0;
            }
        }

        public override void Update(GameTime gt)
        {
            KeyboardState ks = Keyboard.GetState();
            timeSinceLastUpdate += gt.ElapsedGameTime;

            if (ks.IsKeyDown(Keys.Left) || ks.IsKeyDown(Keys.Right) || ks.IsKeyDown(Keys.Up) || ks.IsKeyDown(Keys.Down))
            {
                if (timeSinceLastUpdate.TotalMilliseconds > incrementTime)
                {
                    currFrameIndex += 1;
                    currFrameIndex %= currFrames.Length;
                    timeSinceLastUpdate = TimeSpan.Zero;
                }
            }
            else
            {
                currFrameIndex = 0;
                timeSinceLastUpdate = TimeSpan.Zero;
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(Texture, Position, currFrames[currFrameIndex], Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
        }
    }
}
