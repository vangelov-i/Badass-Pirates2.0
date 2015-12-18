namespace Badass_Pirates.Interfaces
{
    using Badass_Pirates.Enums;

    using Microsoft.Xna.Framework;

    public interface ICreature : IRotatetable
    {
        Vector2 Position { get; set; }

        int Health { get; set; }

        int Damage { get; set; }

        bool Sunk { get; set; }

        void Move(CoordsDirections coordsDirection, Direction direction, int movingSpeed);

        void Attack(IShip target);

        void SetPosition(CoordsDirections coordsDirections, float value);
    }
}
