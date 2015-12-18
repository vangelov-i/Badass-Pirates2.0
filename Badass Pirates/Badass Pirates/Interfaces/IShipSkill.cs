namespace Badass_Pirates.Interfaces
{
    using Badass_Pirates.Objects.Specialties;

    public interface IShipSkill
    {
        ISpecialty Specialty { get; }

        void SpecialtyAttack(IShip target);
    }
}
