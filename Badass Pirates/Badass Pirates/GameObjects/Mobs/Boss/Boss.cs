namespace Badass_Pirates.GameObjects.Mobs.Boss
{
    using System;

    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Managers;
    using Objects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Boss 
    {
        // ТАКА НЕ БИВА ! ! !

        public static Image image;
        
        public static Vector2 position;

        private static int health;

        private static int damage;

        public static Vector2 speed;

        private static bool sinked;

        private static Vector2 textureOrigin;

        public static readonly Point frameSize = new Point(250,208);

        static Boss()
        {
            Health = 100;
            Damage = 40;
            speed.X = 2;
            speed.Y = 2;
            sinked = false;
        }

        public static int Health
        {
            get
            {
                return health;
            }

            set
            {
                if (value < 0)
                {
                    value = 0;
                    sinked = true;
                }
                if (value > 100)
                {
                    value = 100;
                }

                health = value;
            }
        }

        public static int Damage
        {
            get
            {
                return damage;
            }

            set
            {
                damage = value;
            }
        }

        public static Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public static void Attack(Ship target)
        {
            if (target.Shields > 0)
            {
                target.Shields -= Damage;
                if (target.Shields < 0)
                {
                    target.Health += target.Shields;
                    target.Shields = 0;
                }
            }
            else
            {
                target.Health -= Damage;
            }
        }

        public static void Initialise()
        {
            image = new Image("dibossBIG");
            image.Initialise();
            position = new Vector2(500, 200);
        }

        public static void LoadContent()
        {
            image.LoadContent();
            textureOrigin = new Vector2(image.Texture.Width / 2f, image.Texture.Height / 2f);

        }

        public static void UnloadContent()
        {
            image.UnloadContent();
        }

        public static void Update()
        {
            if (!sinked)
            {
                position += speed;

                int MaxX =
                    (int)ScreenManager.Instance.Dimensions.X - image.Texture.Width;
                int MinX = 0;
                int MaxY =
                    (int)ScreenManager.Instance.Dimensions.Y - image.Texture.Height;
                int MinY = 0;

                // Check for bounce.
                if (position.X > MaxX)
                {
                    speed.X *= -1;
                    position.X = MaxX;
                }

                else if (position.X < MinX)
                {
                    speed.X *= -1;
                    position.X = MinX;
                }

                if (position.Y > MaxY)
                {
                    speed.Y *= -1;
                    position.Y = MaxY;
                }

                else if (position.Y < MinY)
                {
                    speed.Y *= -1;
                    position.Y = MinY;
                }
            }
            else
            {
                Boss.Sink();
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {

            if (!sinked)
            {
                image.Draw(spriteBatch, position);
            }
            else
            {
                spriteBatch.Draw(
                    image.Texture,
                    Boss.Position,
                    null,
                    Color.DarkCyan,
                    0f,
                    textureOrigin,
                    1.0f,
                    SpriteEffects.FlipVertically,
                    0f);
            }
        }

        public static void Move(CoordsDirections coordsDirection, Direction direction, int movingSpeed)
        {
            switch (direction)
            {
                case Direction.Positive:
                    switch (coordsDirection)
                    {
                        case CoordsDirections.Abscissa:
                            Boss.position.X += movingSpeed;
                            break;
                        case CoordsDirections.Ordinate:
                            Boss.position.Y += movingSpeed;
                            break;
                    }

                    break;

                case Direction.Negative:
                    switch (coordsDirection)
                    {
                        case CoordsDirections.Abscissa:
                            Boss.position.X -= movingSpeed;
                            break;
                        case CoordsDirections.Ordinate:
                            Boss.position.Y -= movingSpeed;
                            break;
                    }

                    break;
            }
        }

        static void Sink()
        {
            var sinkingSpeed = 1;
            Boss.Move(CoordsDirections.Ordinate, Direction.Positive, sinkingSpeed);
        }
    }
}
