namespace Badass_Pirates.GameObjects.Ships
{
    #region

    using System;
    using System.Collections.Generic;

    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.EngineComponents.Objects.Specialties;
    using Badass_Pirates.Interfaces;

    #endregion

    public class Battleship : Ship
    {
        private const int HEALTH = 100;

        private const int DAMAGE = 10;

        private const int SHIELDS = 30;

        private const int ENERGY = 100;

        private const int SPEED = 3;

        private const int SPECIALTYDMG = 35; // TODO: balance and change the specials

        private static readonly Specialty SPECIALTY = new BLightning();

        public Battleship()
            : base(DAMAGE, HEALTH, SHIELDS, ENERGY, SPEED,SPECIALTYDMG, SPECIALTY)
        {
        }
    }
}