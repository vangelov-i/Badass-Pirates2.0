namespace Badass_Pirates.GameObjects.Mobs.Boss
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Interfaces;

    using Microsoft.Xna.Framework;

    public class Boss : IAttack, IMoveable, IPositionable
    {
        private int health;

        private int damage;

        private float speed;

        public Boss()
        {
            this.Health = 3000;
            this.Damage = 85;
            this.Speed = 20;
        }

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                this.health = value;
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
                this.damage = value;
            }
        }

        public float Speed
        {
            get
            {
                return this.speed;
            }

            set
            {
                this.speed = value;
            }
        }

        public void Attack(Ship target)
        {
            target.Health -= this.Damage;
        }

        public void Move(CoordsDirections coordsDirection, Direction direction, int movingSpeed)
        {
            throw new NotImplementedException();
        }

        public void SetPosition(CoordsDirections coordsDirections, float value)
        {
            throw new NotImplementedException();
        }
    }
}
