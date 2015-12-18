namespace Badass_Pirates.Models.Ships
{
    using Badass_Pirates.Objects.Specialties;

    public class Destroyer : Ship
    {
        private const int HEALTH = 100;

        private const int DAMAGE = 14;

        private const int SHIELDS = 10;

        private const int ENERGY = 100;

        private const int SPECIALTYDMG = 45; // TODO: balance and change the specials

        private const int SPEED = 3;

        private static readonly Specialty SPECIALTY = new Mine();
        
        public Destroyer()
            : base(DAMAGE, HEALTH, SHIELDS, ENERGY, SPEED,SPECIALTYDMG, SPECIALTY)
        {
        }
    }
}