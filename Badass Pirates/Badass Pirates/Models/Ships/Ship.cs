namespace Badass_Pirates.Models.Ships
{
    #region

    using System;
    using System.Diagnostics;

    using Badass_Pirates.Controls;
    using Badass_Pirates.Enums;
    using Badass_Pirates.Exceptions;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Models.Players;
    using Badass_Pirates.Objects;
    using Badass_Pirates.Objects.Specialties;

    using Microsoft.Xna.Framework;

    #endregion

    public abstract class Ship : IShip
    {
        #region Fields

        private static Point frameSize;

        private Vector2 position;

        private readonly int previousSpeed;

        public const int MAX_ENERGY = 100;

        private readonly int MAX_SPEED;

        private readonly int specialtyDamage;

        private ISpecialty specialty;

        #region Points
        private int damage;
        private int health;

        private int energy;
        private int speed;
        private bool sunk;
        #endregion


        #endregion

        protected Ship(int damage, int health, int shields, int energy, int speed, int specialtyDamage, Specialty specialty)
        {
            this.Damage = damage;
            this.Health = health;
            this.Shields = shields;
            this.previousSpeed = speed;
            this.MAX_SPEED = speed + (int)BonusType.Wind;
            this.Speed = speed;
            this.Energy = energy;
            this.specialtyDamage = specialtyDamage;
            this.FreezTimeOut = new Stopwatch();
            this.BonusDamageTimeOut = new Stopwatch();
            this.WindTimeOut = new Stopwatch();
            this.specialty = specialty;
            this.FrameSize = new Point(137, 150);
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
        
        public ISpecialty Specialty
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

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value","cannot be negative !");
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
                if (value <= 0)
                {
                    value = 0;

                    this.Sunk = true;
                    
                }
                if (value > 100)
                {
                    value = 100;
                }

                if (this.Sunk)
                {
                    value = 0;
                }

                this.health = value;
            }
        }

        public int Shields { get; set; }

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
                    throw new OutOfEnergyException();
                }
                if (value > 100)
                {
                    value = 100;
                }

                this.energy = value;
            }
        }
        
        public int Speed
        {
            get
            {
                return this.speed;
            }

             set
            {
                if (value > this.MAX_SPEED)
                {
                    value = this.MAX_SPEED;
                }

                this.speed = value;
            }

        }

        public Point FrameSize
        {
            get
            {
                return frameSize;
            }
            set
            {
                frameSize = value;
            }
        }

        public bool Sunk
        {
            get
            {
                return this.sunk;
            }
            set
            {
                this.sunk = value;
            }
        }

        #endregion

        #region Methods

        public void Attack(IShip target)
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

        public void SpecialtyAttack(IShip target)
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

        public void Sink(IPlayer player)
        {
            var sinkingSpeed = 1;
            if (player is FirstPlayer)
            {
                PlayerControls.FirstControler = false;
                BallControls.FirstController = false;
            }
            else
            {
                PlayerControls.SecondControler = false;
                BallControls.SecondController = false;
            }
            player.Ship.Move(CoordsDirections.Ordinate, Direction.Positive, sinkingSpeed);
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

        #region Bonuses
        public void Freeze()
        {
            if (this.FreezTimeOut.IsRunning == false)
            {
                this.FreezTimeOut.Start();

                this.Speed = (int)BonusType.Freeze;
            }
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

        #endregion
        
    }
}