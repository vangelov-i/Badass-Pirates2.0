namespace Badass_Pirates.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;

    public class CreatePlayer
    {
        public static Player Create(PlayerTypes playerType, ShipType ship, string name)
        {
            switch (playerType)
            {
                    case PlayerTypes.FirstPlayer:
                    return new FirstPlayer(ship, name);
                    case PlayerTypes.SecondPlayer:
                    return new SecondPlayer(ship, name);
                default:
                    throw new InvalidOperationException("inccorect player type");
            }
        }
    }
}
