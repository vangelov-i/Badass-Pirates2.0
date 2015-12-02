namespace Badass_Pirates.EngineComponents
{
    #region

    using Badass_Pirates.GameObjects.Players;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public class CannonBall
    {
        private readonly string pathCannonball = "cannonball";

        private Texture2D cannonBall;

        private Player currentPlayer;

        public Vector2 posCannon;

        private Vector2 posShip;

        private ContentManager content;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.cannonBall, this.posCannon);
        }

        public void Initialise()
        {
            this.posShip.X = this.currentPlayer.Ship.Position.X;
            this.posShip.Y = this.currentPlayer.Ship.Position.Y;
        }

        public void LoadContent()
        {
            this.cannonBall = this.content.Load<Texture2D>(this.pathCannonball);
        }

        public void Update(GameTime gameTime)
        {
            this.posCannon.X += 1;
        }
    }
}