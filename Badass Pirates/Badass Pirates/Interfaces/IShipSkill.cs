namespace Badass_Pirates.Interfaces
{
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Objects.Specialties;

    public interface IShipSkill
    {
        Specialty Specialty { get; }

        void SpecialtyAttack(IShip target);
    }
}
