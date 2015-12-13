namespace Badass_Pirates.GameObjects.Ships
{
    #region

    using Badass_Pirates.Enums;
    using Badass_Pirates.Objects.Specialties;

    #endregion

    public class Battleship : Ship
    {
        private const int HEALTH = 100;

        private const int DAMAGE = 10;

        private const int SHIELDS = 30;

        private const int ENERGY = 100;

        private const int SPEED = 3;

        private const int SPECIALTYDMG = 35; // TODO: balance and change the specials

        private static readonly Specialty SPECIALTY = new Lightning();

        public Battleship()
            : base(DAMAGE, HEALTH, SHIELDS, ENERGY, SPEED,SPECIALTYDMG, SPECIALTY)
        {
        }
    }
}