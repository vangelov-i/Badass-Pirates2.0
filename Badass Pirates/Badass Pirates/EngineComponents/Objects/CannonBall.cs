namespace Badass_Pirates.EngineComponents.Objects
{
    #region

    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.EngineComponents.Screens;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public struct CannonBall
    {
        private static readonly Image Ball;

        private static Vector2 posCannon;

        private static float heightMax;

        private static bool flipper;

        private static int counter;

        static CannonBall()
        {
            CannonBall.Ball = new Image("cannonball");
        }

        public static Vector2 PosCannon
        {
            get
            {
                return posCannon;
            }
            set
            {
                posCannon = value;
            }
        }

        public static void Initialise(Vector2 position)
        {
            CannonBall.posCannon = position;
            CannonBall.heightMax = position.Y - 150;
            CannonBall.counter = 0;
            CannonBall.flipper = false;
        }

        public static void LoadContent()
        {
            CannonBall.Ball.LoadContent();
        }

        public static void UnloadContent()
        {
            CannonBall.Ball.UnloadContent();
        }

        public static void Update(GameTime gameTime)
        {
            CannonBall.posCannon.X += 10;
            if (!CannonBall.flipper && CannonBall.posCannon.Y > CannonBall.heightMax + 100)
            {
                CannonBall.posCannon.Y -= 10;
            }
            else if (!flipper && posCannon.Y > heightMax)
            {
                CannonBall.posCannon.Y -= 4;
            }
            else if (!CannonBall.flipper)
            {
                CannonBall.flipper = true;
                CannonBall.posCannon.Y += 4;
            }
            else if (counter < 8)
            {
                CannonBall.counter++;
            }
            else if (CannonBall.flipper && CannonBall.posCannon.Y > CannonBall.heightMax + 100)
            {
                CannonBall.posCannon.Y += 4;
            }
            else
            {
                CannonBall.posCannon.Y += 10;
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(CannonBall.Ball.Texture, CannonBall.posCannon);
        }
    }
}