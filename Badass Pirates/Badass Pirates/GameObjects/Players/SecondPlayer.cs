namespace Badass_Pirates.GameObjects.Players
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Badass_Pirates.GameObjects.Ships;

    public class SecondPlayer : Player
    {
        public SecondPlayer(ShipType type, string name)
            : base(type, name)
        {
        }
    }
}
