namespace Badass_Pirates.GameObjects.Ships
{
    using System.Collections.Generic;
    using Interfaces.Specialties;


    public class Destroyer : Ship, ILightning
    {
        private const int HEALTH = 100;

        private const int DAMAGE = 10;

        private const int SHIELDS = 100;

        private const int ENERGY = 100;

        private const int SPECIALTYDMG = 150; // TODO: balance and change the specials

        private const int SPEED = 4;


        public Destroyer()
            : base(DAMAGE, HEALTH, SHIELDS, ENERGY, SPEED)
        {
        }

        public override void Attack(Ship target)
        {
            target.Health = target.Health - this.Damage;
        }

        public void Lightning(Ship targetShip)
        {
            targetShip.Health -= SPECIALTYDMG;
        }
    }
}