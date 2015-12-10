namespace Badass_Pirates.GameObjects.Ships
{
    #region

    using System;
    using System.Diagnostics;

    using Badass_Pirates.EngineComponents.Objects;
    using Badass_Pirates.Enums;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Interfaces.Bonuses;

    using Microsoft.Xna.Framework;

    #endregion

    public abstract class Ship : IAttack, IMoveable, ISink, IPositionable, IFreeze, IDamage, IWind
    {

        public static readonly Point FrameSize = new Point(137, 150);

        private Vector2 position;

        private readonly int previousSpeed;

        protected Ship(int damage, int health, int shields, int energy, int speed)
        {
            this.Damage = damage;
            this.Health = health;
            this.Shields = shields;
            this.Energy = energy;
            this.Speed = speed;
            this.FreezTimeOut = new Stopwatch();
            this.BonusDamageTimeOut = new Stopwatch();
            this.WindTimeOut = new Stopwatch();
            this.previousSpeed = this.Speed;

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

        public Stopwatch FreezTimeOut { get; set; }

        public void Freeze()
        {
            this.FreezTimeOut.Start();

            this.Speed = (int)BonusType.Freeze;
        }

        public void DeFrost()
        {
            this.Speed = this.previousSpeed;
            this.FreezTimeOut.Stop();
            this.FreezTimeOut.Reset();
        }

        public Stopwatch BonusDamageTimeOut { get; set; }

        public void BonusDamage()
        {
            this.BonusDamageTimeOut.Start();
            this.Damage += (int)BonusType.Damage;
        }

        public void UnBonusDamage()
        {
            this.BonusDamageTimeOut.Stop();
            this.BonusDamageTimeOut.Reset();
            this.Damage -= (int)BonusType.Damage;
        }

        public Stopwatch WindTimeOut { get; set; }

        public void Wind()
        {
            this.WindTimeOut.Start();
            this.Speed += (int)BonusType.Wind;
        }

        public void UnWind()
        {
            this.Speed -= (int)BonusType.Wind;
            this.WindTimeOut.Stop();
            this.WindTimeOut.Reset();
        }
    }
}