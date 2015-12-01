namespace Badass_Pirates.GameObjects.Ships
{
    #region

    using System;
    using System.Collections.Generic;

    #endregion

    public class Battleship : Ship
    {
        private const int HEALTH = 100;

        private const int DAMAGE = 100;

        private const int SHIELDS = 100;

        private const int ENERGY = 100;

        public Battleship()
            : base(HEALTH, DAMAGE, SHIELDS, ENERGY)
        {
        }

        public override void Attack(Ship target)
        {
        }
    }
}