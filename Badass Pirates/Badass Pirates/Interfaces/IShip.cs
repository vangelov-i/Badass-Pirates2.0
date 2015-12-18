namespace Badass_Pirates.Interfaces
{
    public interface IShip : ICreature,IBonuses,IShipSkill
    {
        int Energy { get; set; }

        int Shields { get; set; }

        int Speed { get; }
        
        void Sink(IPlayer player);

    }
}
