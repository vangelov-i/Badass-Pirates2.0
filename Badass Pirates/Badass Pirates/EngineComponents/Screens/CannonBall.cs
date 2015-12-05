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

        static CannonBall()
        {
            CannonBall.cannonBall = new Image("cannonball");
        }

        public static void Initialise()
        {
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
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(CannonBall.cannonBall.Texture, CannonBall.posCannon);
        }
    }
}