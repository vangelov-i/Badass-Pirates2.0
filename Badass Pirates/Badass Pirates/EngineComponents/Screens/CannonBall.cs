namespace Badass_Pirates.EngineComponents.Screens
{
    #region

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public static class CannonBall
    {
        private static Image cannonBall;

        public static Vector2 posCannon;

        private static float heightMax;

        private static bool flipper;

        private static int counter;

        

        static CannonBall()
        {
            CannonBall.cannonBall = new Image("cannonball");
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
            CannonBall.cannonBall.LoadContent();
        }

        public static void UnloadContent()
        {
            CannonBall.cannonBall.UnloadContent();
        }

        public static void Update(GameTime gameTime)
        {
            CannonBall.posCannon.X += 10;
            if (!flipper && CannonBall.posCannon.Y > CannonBall.heightMax + 100)
            {
                CannonBall.posCannon.Y -= 10;
            }
            else if (!flipper && CannonBall.posCannon.Y > CannonBall.heightMax)
            {
                CannonBall.posCannon.Y -= 4;
            }
            else if (!flipper)
            {
                CannonBall.flipper = true;
                CannonBall.posCannon.Y += 4;
            }
            else if (CannonBall.counter < 8)
            {
                CannonBall.counter++;
            }
            else if (flipper && CannonBall.posCannon.Y > CannonBall.heightMax + 100)
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
            spriteBatch.Draw(CannonBall.cannonBall.Texture, CannonBall.posCannon);
        }
    }
}