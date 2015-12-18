namespace Badass_Pirates.Collisions
{
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Models.Ships;
    using Badass_Pirates.Objects.Specialties;

    using Microsoft.Xna.Framework;

    public class SpecialtyCollision
    {
        private const int OFFSET = 5;

        public static bool Collide(IShip shipColliding, ISpecialty specialtyItem)
        {
            Rectangle shipRect = new Rectangle(
               (int)shipColliding.Position.X + OFFSET,
               (int)shipColliding.Position.Y + OFFSET,
               shipColliding.FrameSize.X - (OFFSET * 2),
               shipColliding.FrameSize.Y - (OFFSET * 2));

            Rectangle mineRectangle = new Rectangle(
                (int)specialtyItem.Position.X + OFFSET,
                (int)specialtyItem.Position.Y + OFFSET,
                specialtyItem.FrameSize.X - (OFFSET * 2),
                specialtyItem.FrameSize.Y - (OFFSET * 2));

            if (shipRect.Intersects(mineRectangle))
            {
                specialtyItem.Position = new Vector2(9999, 9999); // might be buggy
                return true;
            }

            return false;
        }
    }
}
