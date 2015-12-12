using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badass_Pirates.EngineComponents.Collisions
{
    using Badass_Pirates.EngineComponents.Objects;
    using Badass_Pirates.EngineComponents.Objects.Specialties;
    using Badass_Pirates.GameObjects.Ships;

    using Microsoft.Xna.Framework;

    public class SpecialtyCollision
    {
        private const int OFFSET = 10;

        public static bool Collide(Ship shipColliding,DMine mine)
        {
            Rectangle shipRect = new Rectangle(
               (int)shipColliding.Position.X + OFFSET,
               (int)shipColliding.Position.Y + OFFSET,
               Ship.FrameSize.X - (OFFSET * 2),
               Ship.FrameSize.Y - (OFFSET * 2));

            Rectangle mineRectangle = new Rectangle(
                (int)mine.Position.X + OFFSET,
                (int)mine.Position.Y + OFFSET,
                DMine.FRAMESIZE.X - (OFFSET * 2),
                DMine.FRAMESIZE.Y - (OFFSET * 2));

            if (shipRect.Intersects(mineRectangle))
            {
                mine.Position = new Vector2(9999, 9999); // might be buggy
                return true;
            }

            return false;
        }
    }
}
