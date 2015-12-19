using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badass_Pirates.Collisions
{
    using System.Diagnostics;
    
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Models.Mobs.Boss;

    using Microsoft.Xna.Framework;

    //TODO HAS SOME MAGIC NUMBERS
    public static class OctopusCollision
    {
        private const int BALL_COLLISION_OFFSET = 5;

        private const int COLLISION_OFFSET = 40;

        // GROZNO E, NE BIVA
        public static readonly Stopwatch collidedStopWatch = new Stopwatch();
        //

        public static bool Collide(IShip shipColliding)
        {
            if (!collidedStopWatch.IsRunning)
            {
                Rectangle shipRect = new Rectangle(
                   (int)shipColliding.Position.X + COLLISION_OFFSET,
                   (int)shipColliding.Position.Y + COLLISION_OFFSET,
                   shipColliding.FrameSize.X - (COLLISION_OFFSET * 2),
                   shipColliding.FrameSize.Y - (COLLISION_OFFSET * 2));

                Rectangle diBoss = new Rectangle(
                    (int)Boss.Instance.Position.X + COLLISION_OFFSET,
                    (int)Boss.Instance.Position.Y + COLLISION_OFFSET,
                    Boss.Instance.FrameSize.X - (COLLISION_OFFSET * 2),
                    Boss.Instance.FrameSize.Y - (COLLISION_OFFSET * 2));

                if (shipRect.Intersects(diBoss))
                {
                    OctopusCollision.collidedStopWatch.Start();
                    return true;
                }
            }
            else if (OctopusCollision.collidedStopWatch.Elapsed.TotalSeconds > 2)
            {
                OctopusCollision.collidedStopWatch.Stop();
                OctopusCollision.collidedStopWatch.Reset();
            }

            return false;
        }

        #region Balls Collisions

        public static bool BossBallCollide(IProjectile ball)
        {
            Rectangle bossRect = new Rectangle(
               (int)Boss.Instance.Position.X + BALL_COLLISION_OFFSET,
               (int)Boss.Instance.Position.Y + BALL_COLLISION_OFFSET,
               Boss.Instance.FrameSize.X - (BALL_COLLISION_OFFSET * 2),
               Boss.Instance.FrameSize.Y - (BALL_COLLISION_OFFSET * 2));

            Rectangle cannonBall = new Rectangle(
                (int)ball.Position.X + BALL_COLLISION_OFFSET,
                (int)ball.Position.Y + BALL_COLLISION_OFFSET,
                ball.FrameSize.X - (BALL_COLLISION_OFFSET * 2),
                ball.FrameSize.Y - (BALL_COLLISION_OFFSET * 2));

            if (bossRect.Intersects(cannonBall))
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

        #endregion
    }
}
