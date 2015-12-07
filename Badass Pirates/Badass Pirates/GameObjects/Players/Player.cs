namespace Badass_Pirates.GameObjects.Players
{
    using Badass_Pirates.EngineComponents.Objects;
    using Badass_Pirates.Enums;
    using Badass_Pirates.Factory;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Interfaces;

    using Microsoft.Xna.Framework;

    public abstract class Player 
    {
        public readonly Vector2 SpawnFirst = Vector2.Zero;

        // TODO Edit the image size
        public readonly Vector2 SpawnSecond = new Vector2(1366 - 135, 768 - 150);

        private string name;

        private Ship ship;

        protected Player(ShipType type, string name)
        {
            this.Name = name;
            this.Ship = CreateShip.Create(type);            
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public Ship Ship
        {
            get
            {
                return this.ship;
            }

            set
            {
                this.ship = value;
            }
        }
    }
}
