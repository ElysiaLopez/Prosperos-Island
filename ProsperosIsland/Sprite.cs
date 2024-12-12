using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperosIsland
{
    internal class Sprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle? SourceRectangle { get; set; }
        public Color Color { get; set; }
        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }
        public Vector2 Scale { get; set; }
        public SpriteEffects SpriteEffects { get; set; }
        public float LayerDepth { get; set; }
        public Rectangle HitBox => new Rectangle((int)x, (int)y, (int)width, (int)height);

        #region convenience variables
        protected float x
        {
            get
            {
                return Position.X;
            }
            set
            {
                Position = new Vector2(value, Position.Y);
            }
        }
        protected float y
        {
            get
            {
                return Position.Y;
            }
            set
            {
                Position = new Vector2(Position.X, value);
            }
        }
        protected float width => SourceRectangle == null ? Texture.Width * Scale.X : SourceRectangle.Value.Width * Scale.X;
        protected float height => SourceRectangle == null ? Texture.Height * Scale.Y : SourceRectangle.Value.Height * Scale.Y;
        protected Rectangle left => new Rectangle((int)x, (int)y + 1, 1, (int)height - 2);
        protected Rectangle top => new Rectangle((int)x + 1, (int)y, (int)width - 2, 1);
        protected Rectangle right => new Rectangle((int)(x + width), (int)y + 1, 1, (int)height - 2);
        protected Rectangle bottom => new Rectangle((int)x + 1, (int)(y + height), (int)width - 2, 1);
        #endregion

        public Sprite(Texture2D texture, Vector2 pos, Vector2 scale)
        {
            Texture = texture;
            Position = pos;
            Scale = scale;
            Origin = new Vector2(0, 0);
            Color = Color.White;
        }
        public Sprite(Texture2D texture, Vector2 pos, Rectangle? src, Color col, float rot, Vector2 origin, Vector2 scale, SpriteEffects se, float layerDepth)
        {
            Texture = texture;
            Position = pos;
            SourceRectangle = src;
            Color = col;
            Rotation = rot;
            Origin = origin;
            Scale = scale;
            SpriteEffects = se;
            LayerDepth = layerDepth;
        }

        public virtual void Update(GameTime gt) { }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(Texture, Position, SourceRectangle, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
        }
    }
}
