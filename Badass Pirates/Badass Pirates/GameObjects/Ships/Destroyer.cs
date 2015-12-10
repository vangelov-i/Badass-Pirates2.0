namespace Badass_Pirates.GameObjects.Ships
{
    using System.Collections.Generic;
    using Interfaces.Specialties;


    public class Destroyer : Ship, ILightning
    {
        private const int HEALTH = 100;

        private const int DAMAGE = 14;

        private const int SHIELDS = 10;

        private const int ENERGY = 60;

        private const int SPECIALTYDMG = 45; // TODO: balance and change the specials

        private const int SPEED = 3;


        public Destroyer()
            : base(DAMAGE, HEALTH, SHIELDS, ENERGY, SPEED)
        {
        }

       
        public void Lightning(Ship targetShip)
        {
            targetShip.Health -= SPECIALTYDMG;
        }
    }
}