namespace Badass_Pirates.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;

    public interface IItem : IPositionable
    {
        Vector2 Position { get; }
    }
}
