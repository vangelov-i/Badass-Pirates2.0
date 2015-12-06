﻿namespace Badass_Pirates.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects;

    using Microsoft.Xna.Framework;

    public interface IMoveable
    {
        void Move(CoordsDirections coordsDirection, Direction direction, int movingSpeed);
    }
}
