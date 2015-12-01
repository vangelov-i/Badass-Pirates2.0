namespace Badass_Pirates.GameObjects.Players
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Badass_Pirates.GameObjects.Ships;

    public class FirstPlayer : Player
    {
        public FirstPlayer(ShipType type, string name)
            : base(type, name)
        {
            this.Ship.Position.X = 0;
            this.Ship.Position.Y = 0;
        }

    }
}
