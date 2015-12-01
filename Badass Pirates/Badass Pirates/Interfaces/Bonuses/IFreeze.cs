namespace Badass_Pirates.Interfaces.Bonuses
{
    using Badass_Pirates.GameObjects.Ships;

    public interface IFreeze
    {
        public double Timer { get; set; }
        void Freeze(Ship targeShip);
    }
}
