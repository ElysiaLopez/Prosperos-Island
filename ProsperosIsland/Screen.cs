using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperosIsland
{
    internal abstract class Screen
    {
        public abstract void Load();
        public abstract Screens Update(GameTime gt);
        public abstract void Draw(SpriteBatch sb);
    }
}
