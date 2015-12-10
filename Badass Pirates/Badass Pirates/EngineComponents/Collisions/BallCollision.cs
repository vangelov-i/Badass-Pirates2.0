using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Badass_Pirates.EngineComponents.Objects;
using Badass_Pirates.GameObjects.Ships;
using Microsoft.Xna.Framework;

namespace Badass_Pirates.EngineComponents.Collisions
{
    public class BallCollision
    {
        private const int COLLISION_OFFSET = 10;

        public static bool Collide(Ship shipColliding,CannonBall ball)
        {
            Rectangle shipRect = new Rectangle(
               (int)shipColliding.Position.X + COLLISION_OFFSET,
               (int)shipColliding.Position.Y + COLLISION_OFFSET,
               Ship.FrameSize.X - (COLLISION_OFFSET * 2),
               Ship.FrameSize.Y - (COLLISION_OFFSET * 2));

            Rectangle cannonBall = new Rectangle(
                (int)ball.Position.X + COLLISION_OFFSET,
                (int)ball.Position.Y + COLLISION_OFFSET,
                CannonBall.frameSize.X - (COLLISION_OFFSET * 2),
                CannonBall.frameSize.Y - (COLLISION_OFFSET * 2));

            if (shipRect.Intersects(cannonBall))
            {

                ball.Position = new Vector2(9999,9999); // might be buggy
                return true;
            }

            return false;
        }
    }
}
