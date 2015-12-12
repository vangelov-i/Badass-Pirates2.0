﻿using System;
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
        private const int OFFSET = 5;

        public static bool Collide(Ship shipColliding,Specialty specialtyItem)
        {
            Rectangle shipRect = new Rectangle(
               (int)shipColliding.Position.X + OFFSET,
               (int)shipColliding.Position.Y + OFFSET,
               Ship.FrameSize.X - (OFFSET * 2),
               Ship.FrameSize.Y - (OFFSET * 2));

            Rectangle mineRectangle = new Rectangle(
                (int)specialtyItem.Position.X + OFFSET,
                (int)specialtyItem.Position.Y + OFFSET,
                specialtyItem.FRAMESIZE.X - (OFFSET * 2),
                specialtyItem.FRAMESIZE.Y - (OFFSET * 2));

            if (shipRect.Intersects(mineRectangle))
            {
                specialtyItem.Position = new Vector2(9999, 9999); // might be buggy
                return true;
            }

            return false;
        }
    }
}
