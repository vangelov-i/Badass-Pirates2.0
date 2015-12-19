namespace Badass_Pirates.Models.Mobs.Boss
{
    #region

    using Badass_Pirates.Enums;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Managers;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public class Boss : IBoss
    {
        private static Boss instance = new Boss();

        private Point frameSize;

        private int health;

        public Image image;

        private Vector2 position;

        private Vector2 speed;

        private Vector2 textureOrigin;

        private Boss()
        {
            this.Health = 200;
            this.Damage = 20;
            this.speed.X = 2;
            this.speed.Y = 2;
            this.Sunk = false;
            this.frameSize = new Point(250, 208);
        }

        public static Boss Instance
        {
            get { return instance; }
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
                    value = 0;
                    this.Sunk = true;
                }

                this.health = value;
            }
        }

        public int Damage { get; set; }

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

        public Point FrameSize
        {
            get
            {
                return this.frameSize;
            }
            set
            {
                this.frameSize = value;
            }
        }

        public bool Sunk { get; set; }

        public Vector2 Speed
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

        public void Move(CoordsDirections coordsDirection, Direction direction, int movingSpeed)
        {
            switch (direction)
            {
                case Direction.Positive:
                    switch (coordsDirection)
                    {
                        case CoordsDirections.Abscissa:
                            Instance.position.X += movingSpeed;
                            break;
                        case CoordsDirections.Ordinate:
                            Instance.position.Y += movingSpeed;
                            break;
                    }

                    break;

                case Direction.Negative:
                    switch (coordsDirection)
                    {
                        case CoordsDirections.Abscissa:
                            Instance.position.X -= movingSpeed;
                            break;
                        case CoordsDirections.Ordinate:
                            Instance.position.Y -= movingSpeed;
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

        public void Initialise()
        {
            this.image = new Image("dibossBIG");
            this.image.Initialise();
            this.position = new Vector2(550, 300); // TODO: consts ?
        }

        public void LoadContent()
        {
            this.image.LoadContent();
            this.textureOrigin = new Vector2(this.image.Texture.Width / 2f, this.image.Texture.Height / 2f);
        }

        public void UnloadContent()
        {
            this.image.UnloadContent();
        }

        public void Update()
        {
            if (!this.Sunk)
            {
                this.position += this.speed;

                int MaxX = (int)ScreenManager.Instance.Dimensions.X - this.image.Texture.Width;
                int MinX = 0;
                int MaxY = (int)ScreenManager.Instance.Dimensions.Y - this.image.Texture.Height;
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
            else
            {
                Instance.Sink();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!this.Sunk)
            {
                this.image.Draw(spriteBatch, this.position);
            }
            else
            {
                spriteBatch.Draw(
                    this.image.Texture,
                    Instance.Position,
                    null,
                    Color.DarkCyan,
                    0f,
                    this.textureOrigin,
                    1.0f,
                    SpriteEffects.FlipVertically,
                    0f);
            }
        }

        public void Sink()
        {
            var sinkingSpeed = 1;
            Instance.Move(CoordsDirections.Ordinate, Direction.Positive, sinkingSpeed);
        }
    }
}