namespace Badass_Pirates.Factory
{
    #region

    using System;

    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Models.Ships;

    #endregion

    public static class CreateShip
    {
        public static Ship Create(ShipType type)
        {
            switch (type)
            {
                case ShipType.Battleship:
                    return new Battleship();
                case ShipType.Cruiser:
                    return new Cruiser();
                case ShipType.Destroyer:
                    return new Destroyer();
                default:
                    throw new InvalidOperationException("invalid ship");
            }
        }
    }
}