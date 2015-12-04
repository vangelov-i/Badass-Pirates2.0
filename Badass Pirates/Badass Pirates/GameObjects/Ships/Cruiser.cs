namespace Badass_Pirates.GameObjects.Ships
{
    using System.Collections.Generic;
    using Interfaces.Specialties;

    public class Cruiser : Ship, IRocket
    {
        private const int HEALTH = 100;

        private const int DAMAGE = 100;

        private const int SHIELDS = 100;

        private const int ENERGY = 100;

        private const int SPEED = 3;


        private const int SPECIALTYDMG = 150; // TODO: balance and change the specials


        public Cruiser()
            : base(HEALTH, DAMAGE, SHIELDS, ENERGY, SPEED)
        {
        }

        public override void Attack(Ship target)
        {
            target.Health -= this.Damage;
        }

        public void Rocket(Ship targetShip)
        {
            targetShip.Health -= SPECIALTYDMG;
        }
    }
}