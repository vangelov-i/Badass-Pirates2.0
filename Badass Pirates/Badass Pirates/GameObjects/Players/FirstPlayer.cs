namespace Badass_Pirates.GameObjects.Players
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    using Badass_Pirates.GameObjects.Ships;

    using Microsoft.Xna.Framework;

    public class FirstPlayer : Player
    {
        public FirstPlayer(ShipType type, string name)
            : base(type, name)
        {
        }
    }
}
