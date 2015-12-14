using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badass_Pirates.Collisions
{
    using Badass_Pirates.GameObjects.Mobs.Boss;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Objects;

    using Microsoft.Xna.Framework;

    class OctopusBallsCollision
    {
        private const int COLLISION_OFFSET = 5;

        public static bool Collide(CannonBall ball)
        {
            Rectangle shipRect = new Rectangle(
               (int)Boss.Position.X + COLLISION_OFFSET,
               (int)Boss.Position.Y + COLLISION_OFFSET,
               Boss.frameSize.X - (COLLISION_OFFSET * 2),
               Boss.frameSize.Y - (COLLISION_OFFSET * 2));

            Rectangle cannonBall = new Rectangle(
                (int)ball.Position.X + COLLISION_OFFSET,
                (int)ball.Position.Y + COLLISION_OFFSET,
                CannonBall.frameSize.X - (COLLISION_OFFSET * 2),
                CannonBall.frameSize.Y - (COLLISION_OFFSET * 2));

            if (shipRect.Intersects(cannonBall))
            {
                ball.Position = new Vector2(9999, 9999); // might be buggy
                return true;
            }
            if (ball.Position.Y >= ball.BallFiredPos.Y)
            {
                ball.Position = new Vector2(999, 999);
            }

            return false;
        }

    }
}
