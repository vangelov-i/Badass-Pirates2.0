namespace Badass_Pirates.GameObjects.Ships
{
    #region

    using System;
    using System.Collections.Generic;

    using Badass_Pirates.GameObjects.Items;
    using Badass_Pirates.GameObjects.Items.Potions;
    using Badass_Pirates.Interfaces;

    using Microsoft.Xna.Framework;

    #endregion

    public abstract class Ship : IAttack, IMoveable, IGet
    {
        private Vector2 position;

        private int energy;

        private int damage;

        private int health;

        private int shields;

        private int speed;
        
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
                this.speed = value; 
            }
        }

        public abstract void Attack(Ship target);

        public void Move(Vector2 targetPosition)
        {
            throw new NotImplementedException();
        }

        public virtual void Get(Items.Item item)
        {
            throw new NotImplementedException();
        }

    }
}