namespace Badass_Pirates.EngineComponents
{
    #region

    using System.Runtime.CompilerServices;

    using Badass_Pirates.Factory;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    #endregion

    public class SplashScreen : GameScreen
    {
        private readonly string pathBg = "Backgrounds/BG";

        private readonly string pathShip = "Ships/ship3novo";

        private Player currentPlayer;

        private Vector2 posShip;

        private Texture2D ImageBg { get; set; }

        private Texture2D ImageShip { get; set; }

        private bool isPressed = false;

        public override void Initialise()
        {
            base.Initialise();
            this.currentPlayer = CreatePlayer.Create(PlayerTypes.FirstPlayer, ShipType.Destroyer, "ivan4o");
            //CannonBall.Initialise(this.currentPlayer);
            CannonBall.Initialise(this.posShip);

        }

        public override void LoadContent()
        {
            base.LoadContent();
            this.ImageShip = this.Content.Load<Texture2D>(this.pathShip);
            this.ImageBg = this.Content.Load<Texture2D>(this.pathBg);
            CannonBall.LoadContent(this.Content);
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
            //CannonBall.Update(gameTime);
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Down))
            {
                this.posShip.Y += 3;
            }

            if (state.IsKeyDown(Keys.Up))
            {
                this.posShip.Y -= 3;
            }

            if (state.IsKeyDown(Keys.Right))
            {
                this.posShip.X += 3;
            }

            if (state.IsKeyDown(Keys.Left))
            {
                this.posShip.X -= 3;
            }

            if (state.IsKeyDown(Keys.Space))
            {
                isPressed = true;
                //CannonBall.Update(gameTime);
            }
            if (isPressed)
            {
                CannonBall.Update(gameTime);
            }
            //if (state.IsKeyUp(Keys.Space))
            //{
            //    isPressed = false;
            //}
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.ImageBg, new Vector2(0, 0));
            spriteBatch.Draw(this.ImageShip, this.posShip);
            if (isPressed)
            {
                if (CannonBall.PosCannon.X < 700)
                {
                    CannonBall.Draw(spriteBatch);
                }
                else
                {
                    isPressed = false;
                    CannonBall.Initialise(new Vector2(this.posShip.X + this.ImageShip.Width, this.posShip.Y + this.ImageShip.Height/2));
                }
                //isPressed = false;
            }
        }
    }
}