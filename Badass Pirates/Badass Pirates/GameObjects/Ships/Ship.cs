namespace Badass_Pirates.GameObjects.Ships
{
    #region

    using System;
    using System.Diagnostics;

    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.EngineComponents.Objects;
    using Badass_Pirates.EngineComponents.Objects.Specialties;
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

        public static int energyStatic = 100;

        private int specialtyDamage;

        private Specialty specialty;

        protected Ship(int damage, int health, int shields, int energy, int speed, int specialtyDamage, Specialty specialty)
        {
            this.Damage = damage;
            this.Health = health;
            this.Shields = shields;
            this.Energy = energy;
            this.Speed = speed;
            this.specialtyDamage = specialtyDamage;
            this.FreezTimeOut = new Stopwatch();
            this.BonusDamageTimeOut = new Stopwatch();
            this.WindTimeOut = new Stopwatch();
            this.previousSpeed = this.Speed;
            this.specialty = specialty;
        }

        #region Properties
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
        
        public Stopwatch WindTimeOut { get; set; }

        public Stopwatch BonusDamageTimeOut { get; set; }

        public Stopwatch FreezTimeOut { get; set; }
        
        public Specialty Specialty
        {
            get
            {
                return this.specialty;
            }
            set
            {
                this.specialty = value;
            }
        }

        #endregion

        #region Methods

        public void Attack(Ship target)
        {
            if (target.Shields > 0)
            {
                target.Shields -= this.Damage;
                if (target.Shields < 0)
                {
                    target.Health += target.Shields;
                    target.Shields = 0;
                }
            }
            else
            {
                target.Health -= this.Damage;
            }
        }

        public void SpecialtyAttack(Ship target)
        {
            if (target.Shields > 0)
            {
                target.Shields -= this.specialtyDamage;
                if (target.Shields < 0)
                {
                    target.Health += target.Shields;
                    target.Shields = 0;
                }
            }
            else
            {
                target.Health -= this.specialtyDamage;
            }
        }

        private void ValidateShields(Ship target)
        {
           throw new NotImplementedException();
        }

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

        #endregion
    }
}