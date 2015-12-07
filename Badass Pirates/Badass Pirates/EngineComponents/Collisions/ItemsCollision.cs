namespace Badass_Pirates.EngineComponents.Collisions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    using Badass_Pirates.EngineComponents.Objects;
    using Badass_Pirates.GameObjects.Ships;

    using Microsoft.Xna.Framework;

    public class ItemsCollision
    {
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore", Justification = "Reviewed. Suppression is OK here.")]
        private const int COLLISION_OFFSET = 10;

        public static bool Collide(Ship shipColliding)
        {
            Rectangle shipRect = new Rectangle(
               (int)shipColliding.Position.X + COLLISION_OFFSET,
               (int)shipColliding.Position.Y + COLLISION_OFFSET,
               Ship.FrameSize.X - (COLLISION_OFFSET * 2),
               Ship.FrameSize.Y - (COLLISION_OFFSET * 2));

            Rectangle itemRect = new Rectangle(
                (int)Item.Position.X + COLLISION_OFFSET,
                (int)Item.Position.Y + COLLISION_OFFSET,
                Item.FrameSize.X - (COLLISION_OFFSET * 2),
                Item.FrameSize.Y - (COLLISION_OFFSET * 2));

            if (shipRect.Intersects(itemRect))
            {
                return true;
            }

            return false;
        }
    }
}
