namespace Badass_Pirates.Interfaces
{
    using Badass_Pirates.Objects;

    public interface IShip : ICreature,IBonuses,IShipSkill
    {
        int Energy { get; set; }

        int Shields { get; set; }

        int Speed { get; }

        //TODO shouldnt be player - ICreature
        void Sink(IPlayer player);

    }
}
