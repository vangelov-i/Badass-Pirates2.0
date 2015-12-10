namespace Badass_Pirates.GameObjects.Ships
{
    #region

    using System;
    using System.Collections.Generic;
    using Interfaces.Specialties;

    #endregion

    public class Battleship : Ship, IMine
    {
        private const int HEALTH = 100;

        private const int DAMAGE = 10;

        private const int SHIELDS = 30;

        private const int ENERGY = 70;

        private const int SPEED = 3;

        private const int SPECIALTYDMG = 35; // TODO: balance and change the specials

        public Battleship()
            : base(DAMAGE, HEALTH, SHIELDS, ENERGY, SPEED)
        {
        }

        

        public void Mine(Ship targetShip)
        {
            targetShip.Health -= SPECIALTYDMG;
        }
    }
}