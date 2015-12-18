﻿namespace Badass_Pirates.Collisions
{
    using System.Diagnostics.CodeAnalysis;

    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Models.Ships;
    using Badass_Pirates.Objects;

    using Microsoft.Xna.Framework;

    public class ItemsCollision
    {
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore", Justification = "Reviewed. Suppression is OK here.")]
        private const int COLLISION_OFFSET = 5;
        
        public static bool Collide(IShip shipColliding)
        {
            Rectangle shipRect = new Rectangle(
               (int)shipColliding.Position.X + COLLISION_OFFSET,
               (int)shipColliding.Position.Y + COLLISION_OFFSET,
               shipColliding.FrameSize.X - (COLLISION_OFFSET * 2),
               shipColliding.FrameSize.Y - (COLLISION_OFFSET * 2));

            Rectangle itemRect = new Rectangle(
                (int)Item.Position.X + COLLISION_OFFSET,
                (int)Item.Position.Y + COLLISION_OFFSET,
                Item.FrameSize.X - (COLLISION_OFFSET * 2),
                Item.FrameSize.Y - (COLLISION_OFFSET * 2));

            if (shipRect.Intersects(itemRect))
            {
                Item.Position = new Vector2(9900,9900);
                return true;
            }

            return false;
        }

    }
}
