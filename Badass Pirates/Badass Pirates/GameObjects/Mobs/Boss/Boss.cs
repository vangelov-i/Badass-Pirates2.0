namespace Badass_Pirates.GameObjects.Mobs.Boss
{
    using System;

    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Screens;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Boss : IAttack, IMoveable, IPositionable
    {
        // ТАКА НЕ БИВА ! ! !

        public Image image;

        private static Boss instance;

        public static Boss Instance
        {
            get
            {
                //if (instance == null && MainEngine.timeCounter > 4)
                //{
                //    instance = new Boss();
                //}

                return instance;
            }
            set
            {
                instance = value;
            }
        }

        public Vector2 position;

        private int health;

        private int damage;

        public Vector2 speed;

        public readonly Point frameSize = new Point(250,208);

        public Boss()
        {
            this.Health = 3000;
            this.Damage = 85;
            this.speed.X = 6;
            this.speed.Y = 6;
            this.position = new Vector2(500,200);
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

        public void Move(CoordsDirections coordsDirection, Direction direction, int movingSpeed)
        {
            throw new NotImplementedException();
        }

        public void SetPosition(CoordsDirections coordsDirections, float value)
        {
            throw new NotImplementedException();
        }

        public void Initialise()
        {
            this.image = new Image("dibossBIG");
            this.image.Initialise();
        }

        public void LoadContent()
        {
            this.image.LoadContent();
        }

        public void UnloadContent()
        {
            this.image.UnloadContent();
        }

        public void Update()
        {
            this.position += this.speed;

            int MaxX =
                (int)ScreenManager.Instance.Dimensions.X - this.image.Texture.Width;
            int MinX = 0;
            int MaxY =
                (int)ScreenManager.Instance.Dimensions.Y - this.image.Texture.Height;
            int MinY = 0;

            // Check for bounce.
            if (this.position.X > MaxX)
            {
                this.speed.X *= -1;
                this.position.X = MaxX;
            }

            else if (this.position.X < MinX)
            {
                this.speed.X *= -1;
                this.position.X = MinX;
            }

            if (this.position.Y > MaxY)
            {
                this.speed.Y *= -1;
                this.position.Y = MaxY;
            }

            else if (this.position.Y < MinY)
            {
                this.speed.Y *= -1;
                this.position.Y = MinY;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.image.Draw(spriteBatch,this.position);
        }

        public void CallTheBoss()
        {
            Boss.instance.Initialise();
            Boss.instance.LoadContent();

        }
    }
}
