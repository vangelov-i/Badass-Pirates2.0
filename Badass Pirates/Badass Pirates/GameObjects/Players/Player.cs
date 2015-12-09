namespace Badass_Pirates.GameObjects.Players
{
    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.EngineComponents.Objects;
    using Badass_Pirates.Enums;
    using Badass_Pirates.Factory;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Interfaces;

    using Microsoft.Xna.Framework;

    public abstract class Player 
    {
        protected readonly Vector2 SpawnFirst = Vector2.Zero;

        // TODO Edit the image size
        protected readonly Vector2 SpawnSecond = new Vector2(1366 - 135, 768 - 150);

        private string name;

        private Ship ship;

        public InputManager InputManagerInstance { get; }

        protected Player(ShipType type, string name)
        {
            this.Name = name;
            this.InputManagerInstance = new InputManager();
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
