using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badass_Pirates.Collisions
{
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using Badass_Pirates.GameObjects.Mobs.Boss;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Objects;

    using Microsoft.Xna.Framework;

    public class OctopusCollision
    {
        private const int COLLISION_OFFSET = 5;

        // GROZNO E, NE BIVA
        public static Stopwatch collidedStopWatch = new Stopwatch();
        //

        public static bool Collide(Ship shipColliding, Boss boss)
        {
            if (!collidedStopWatch.IsRunning)
            {
                Rectangle shipRect = new Rectangle(
                   (int)shipColliding.Position.X + COLLISION_OFFSET,
                   (int)shipColliding.Position.Y + COLLISION_OFFSET,
                   Ship.FrameSize.X - (COLLISION_OFFSET * 2),
                   Ship.FrameSize.Y - (COLLISION_OFFSET * 2));

                Rectangle diBoss = new Rectangle(
                    (int)boss.Position.X + COLLISION_OFFSET,
                    (int)boss.Position.Y + COLLISION_OFFSET,
                    boss.frameSize.X - (COLLISION_OFFSET * 2),
                    boss.frameSize.Y - (COLLISION_OFFSET * 2));

                if (shipRect.Intersects(diBoss))
                {
                    return true;
                }
            }
            


            return false;
        }

        //private static void Intersect(Boss boss)
        //{
        //        boss.speed.X *= -1;
        //        boss.speed.Y *= -1;
        //}

    }
}
