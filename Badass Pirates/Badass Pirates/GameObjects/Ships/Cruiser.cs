namespace Badass_Pirates.GameObjects.Ships
{
    using System.Collections.Generic;
    using Interfaces.Specialties;

    public class Cruiser : Ship, IRocket
    {
        private const int HEALTH = 100;

        private const int DAMAGE = 8;

        private const int SHIELDS = 20;

        private const int ENERGY = 80;

        private const int SPEED = 4;

        private const int SPECIALTYDMG = 30; // TODO: balance and change the specials


        public Cruiser()
            : base(DAMAGE, HEALTH, SHIELDS, ENERGY, SPEED)
        {
        }

        

        public void Rocket(Ship targetShip)
        {
            targetShip.Health -= SPECIALTYDMG;
        }
    }
}