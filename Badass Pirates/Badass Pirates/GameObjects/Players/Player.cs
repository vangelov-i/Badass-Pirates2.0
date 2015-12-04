namespace Badass_Pirates.GameObjects.Players
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Badass_Pirates.EngineComponents;
    using Badass_Pirates.Factory;
    using Badass_Pirates.GameObjects.Ships;

    using Microsoft.Xna.Framework;

    public abstract class Player  
    {
        private string name;

        private ShipType shipType;

        private Ship ship;

        public Vector2 spawnFirst = Vector2.Zero;

        //TODO Edit the image size

        public Vector2 spawnSecond = new Vector2(1366 - 135 , 768 - 150);

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

        public ShipType ShipType
        {
            get
            {
                return this.shipType;
            }

            set
            {
                this.shipType = value;
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
