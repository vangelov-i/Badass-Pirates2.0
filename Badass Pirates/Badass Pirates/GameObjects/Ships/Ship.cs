namespace Badass_Pirates.GameObjects.Ships
{
    #region

    using System;

    using Badass_Pirates.EngineComponents.Objects;
    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Items;
    using Badass_Pirates.GameObjects.Items.BonusTypes;
    using Badass_Pirates.Interfaces;

    using Microsoft.Xna.Framework;

    #endregion

    public abstract class Ship : IAttack, IMoveable, ISink, IPositionable
    {
        private Vector2 position;

        protected Ship(int damage, int health, int shields, int energy, int speed)
        {
            this.Damage = damage;
            this.Health = health;
            this.Shields = shields;
            this.Energy = energy;
            this.Speed = speed;
        }

        public Vector2 Position
        {
            get
            {
                return this.position;
            }

            set
            {
                this.position = value;
            }
        }

        public int Damage { get; set; }

        public int Health { get; set; }

        public int Shields { get; set; }

        public int Energy { get; set; }

        public int Speed { get; set; }

        public abstract void Attack(Ship target);

        public void Sink(Ship target)
        {
            throw new NotImplementedException("METHOD SINK NOT IMPLEMENTED");
        }

        public void Move(CoordsDirections coordsDirection, Direction direction, int movingSpeed)
        {
            switch (direction)
            {
                case Direction.Positive:
                    switch (coordsDirection)
                    {
                        case CoordsDirections.Abscissa:
                            this.position.X += movingSpeed;
                            break;
                        case CoordsDirections.Ordinate:
                            this.position.Y += movingSpeed;
                            break;
                    }

                    break;

                case Direction.Negative:
                    switch (coordsDirection)
                    {
                        case CoordsDirections.Abscissa:
                            this.position.X -= movingSpeed;
                            break;
                        case CoordsDirections.Ordinate:
                            this.position.Y -= movingSpeed;
                            break;
                    }

                    break;
            }
        }

        public void SetPosition(CoordsDirections coordsDirections, float value)
        {
            switch (coordsDirections)
            {
                case CoordsDirections.Abscissa:
                    this.position.X = value;
                    break;
                case CoordsDirections.Ordinate:
                    this.position.Y = value;
                    break;
            }
        }
    }
}