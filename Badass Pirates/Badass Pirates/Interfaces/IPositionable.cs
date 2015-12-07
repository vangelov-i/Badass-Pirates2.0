﻿namespace Badass_Pirates.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Badass_Pirates.Enums;

    public interface IPositionable
    {
        void SetPosition(CoordsDirections coordsDirections, float value);
    }
}