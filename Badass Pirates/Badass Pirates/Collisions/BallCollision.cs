namespace Badass_Pirates.Collisions
{
    using Badass_Pirates.Interfaces;

    using Microsoft.Xna.Framework;

    public class BallCollision
    {
        private const int COLLISION_OFFSET = 5;

        public static bool Collide(IShip shipColliding, IBall ball)
        {
            Rectangle shipRect = new Rectangle(
               (int)shipColliding.Position.X + COLLISION_OFFSET,
               (int)shipColliding.Position.Y + COLLISION_OFFSET,
               shipColliding.FrameSize.X - (COLLISION_OFFSET * 2),
               shipColliding.FrameSize.Y - (COLLISION_OFFSET * 2));

            Rectangle cannonBall = new Rectangle(
                (int)ball.Position.X + COLLISION_OFFSET,
                (int)ball.Position.Y + COLLISION_OFFSET,
                ball.FrameSize.X - (COLLISION_OFFSET * 2),
                ball.FrameSize.Y - (COLLISION_OFFSET * 2));

            if (shipRect.Intersects(cannonBall))
            {
                ball.Position = new Vector2(9999,9999); // might be buggy
                return true;
            }
            if (ball.Position.Y >= ball.BallFiredPos.Y)
            {
                ball.Position = new Vector2(999,999);
            }

            return false;
        }
    }
}
