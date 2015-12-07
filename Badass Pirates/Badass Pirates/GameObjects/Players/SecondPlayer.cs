namespace Badass_Pirates.GameObjects.Players
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    using Badass_Pirates.EngineComponents;
    using Badass_Pirates.GameObjects.Ships;

    using Microsoft.Xna.Framework;

    public class SecondPlayer : Player
    {
        public SecondPlayer(ShipType type, string name)
            : base(type, name)
        {
            this.Ship.Position = this.SpawnSecond;
        }
    }
}
