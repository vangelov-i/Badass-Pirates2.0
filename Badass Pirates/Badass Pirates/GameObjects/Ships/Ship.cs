namespace Badass_Pirates.GameObjects.Ships
{
    #region

    using System;
    using System.Diagnostics;
    
    using Badass_Pirates.Enums;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Interfaces.Bonuses;
    using Badass_Pirates.Objects.Specialties;

    using Microsoft.Xna.Framework;

    #endregion

    public abstract class Ship : IAttack, IMoveable, ISink, IPositionable, IFreeze, IDamage, IWind
    {
        #region Fields
        public static readonly Point FrameSize = new Point(137, 150);

        private Vector2 position;

        private readonly int previousSpeed;

        public const int MAX_ENERGY = 100;

        private readonly int specialtyDamage;

        private Specialty specialty;

        #region Points
        private int damage;
        private int health;
        private int shields;
        private int energy;
        private int speed;
        private int flag;

        #endregion


        #endregion

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
            this.flag = -1;
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

        public int Damage
        {
            get
            {
                return this.damage;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),"cannot be negative !");
                }
                this.damage = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "cannot be negative !");
                }
                if (value > 101)
                {
                    this.flag = 0;
                }
                if (this.flag == 0)
                {
                    value = 100;
                }

                this.health = value;
                this.flag = -1;
            }
        }

        public int Shields
        {
            get
            {
                return this.shields;
            }
            set
            {
                this.shields = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "cannot be negative !");
                }
                if (this.energy + value > 100)
                {
                    this.flag = 0;
                }
                if (this.flag == 0)
                {
                    value = 100;
                }

                this.energy = value;
                this.flag = -1;
            }
        }

        public int Speed
        {
            get
            {
                return this.speed;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "cannot be negative !");
                }
                if (this.speed + value > 8)
                {
                    this.flag = 0;
                }
                if (this.flag == 0)
                {
                    value = 8;
                }

                this.speed = value;
                this.flag = -1;
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