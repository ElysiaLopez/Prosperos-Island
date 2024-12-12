using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperosIsland
{
    internal class Level
    {
        public Player Player { get; set; }
        public Sprite Goal { get; set; }
        public Vector2 PlayerStartPosition { get; set; }
        public List<Platform> Platforms { get; set; }
        public List<Obstacle> Obstacles { get; set; }

        public Level(Player player, Sprite goal, Vector2 startPos, List<Platform> plats, List<Obstacle> obs)
        {
            Player = player;
            Goal = goal;
            PlayerStartPosition = startPos;
            Platforms = plats;
            Obstacles = obs;
        }

        public void ResetLevel()
        {
            Player.Position = PlayerStartPosition;
            Player.SetPlatforms(Platforms);
        }

        public bool Update(GameTime gt)
        {
            Player.Update(gt);

            foreach(var o in Obstacles)
            {
                o.Update(Platforms);

                if (Player.HitBox.Intersects(o.HitBox))
                {
                    ResetLevel();
                }
            }

            return Player.HitBox.Intersects(Goal.HitBox);
        }

        public void Draw(SpriteBatch sb)
        {
            Player.Draw(sb);

            for (int i = 0; i < Platforms.Count; i++)
            {
                Platforms[i].Draw(sb);
            }

            foreach (Obstacle o in Obstacles)
            {
                o.Draw(sb);
            }

            Goal.Draw(sb);
        }
    }
}
