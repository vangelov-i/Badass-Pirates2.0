namespace Badass_Pirates.GameObjects.Ships
{
    using System.Collections.Generic;

    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.EngineComponents.Objects.Specialties;
    using Badass_Pirates.Interfaces;

    public class Cruiser : Ship
    {
        private const int HEALTH = 100;

        private const int DAMAGE = 8;

        private const int SHIELDS = 20;

        private const int ENERGY = 100;

        private const int SPEED = 4;

        private const int SPECIALTYDMG = 30; // TODO: balance and change the specials

        private static readonly Specialty SPECIALTY = new Hurricane();


        public Cruiser()
            : base(DAMAGE, HEALTH, SHIELDS, ENERGY, SPEED,SPECIALTYDMG, SPECIALTY)
        {
        }
    }
}