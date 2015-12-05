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

        public static float hightMax;

        public static bool flipper;

        static CannonBall()
        {
            CannonBall.cannonBall = new Image("cannonball");
        }

        public static void Initialise(Vector2 position)
        {
            CannonBall.posCannon = position;
            CannonBall.hightMax = position.Y - 250;
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
            if (!flipper && CannonBall.posCannon.Y > CannonBall.hightMax)
            {
                CannonBall.posCannon.Y -= 10;
            }
            else if ( CannonBall.posCannon.Y <= CannonBall.hightMax + 250)
            {
                CannonBall.flipper = true;
                CannonBall.posCannon.Y += 10;
            }

        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(CannonBall.cannonBall.Texture, CannonBall.posCannon);
        }
    }
}