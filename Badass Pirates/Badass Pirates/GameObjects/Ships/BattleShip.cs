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

        private const int DAMAGE = 100;

        private const int SHIELDS = 100;

        private const int ENERGY = 100;

        private const int SPEED = 40;

        private const int SPECIALTYDMG = 150; // TODO: balance and change the specials

        public Battleship()
            : base(HEALTH, DAMAGE, SHIELDS, ENERGY, SPEED)
        {
        }

        public override void Attack(Ship target)
        {
            target.Health -= this.Damage;
        }

        public void Mine(Ship targetShip)
        {
            targetShip.Health -= SPECIALTYDMG;
        }
    }
}