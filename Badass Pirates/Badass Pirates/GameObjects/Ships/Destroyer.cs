namespace Badass_Pirates.GameObjects.Ships
{
    using System.Collections.Generic;

    public class Destroyer : Ship
    {
        private const int HEALTH = 100;

        private const int DAMAGE = 100;

        private const int SHIELDS = 100;

        private const int ENERGY = 100;

        public Destroyer()
            : base(HEALTH, DAMAGE, SHIELDS, ENERGY)
        {
        }

        public override void Attack(Ship target)
        {
        }
    }
}