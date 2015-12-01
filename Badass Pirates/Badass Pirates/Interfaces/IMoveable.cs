namespace Badass_Pirates.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Badass_Pirates.GameObjects;

    using Microsoft.Xna.Framework;

    public interface IMoveable
    {
        void Move(Vector2 targetPosition);
    }
}
