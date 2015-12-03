namespace Badass_Pirates.EngineComponents
{
    #region

    using System.Runtime.CompilerServices;

    using Badass_Pirates.GameObjects.Players;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public static class CannonBall
    {
        private static readonly string PathCannonball = "cannonball";

        private static Texture2D cannonBall;

        private static Vector2 posCannon;

        public static void Draw(SpriteBatch spriteBatch)
        {
           spriteBatch.Draw(CannonBall.cannonBall, CannonBall.posCannon);
        }

        public static void Initialise(Player player)
        {
            CannonBall.posCannon = player.Ship.Position;
        }

        public static void LoadContent(ContentManager content)
        {
            CannonBall.cannonBall = content.Load<Texture2D>(CannonBall.PathCannonball);
        }

        public static void Update(GameTime gameTime)
        {
            CannonBall.posCannon.X += 1;
        }
    }
}