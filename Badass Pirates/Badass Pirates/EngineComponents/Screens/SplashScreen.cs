namespace Badass_Pirates.EngineComponents
{
    #region

    using Badass_Pirates.Factory;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    #endregion

    public class SplashScreen : GameScreen
    {
        private readonly string pathBg = "Backgrounds/sea";

        private readonly string pathShip = "Ships/ship3novo";

        private bool ballInitialised;

        private Player currentPlayer;

        private bool isPressed;

        private Vector2 posShip;

        private Texture2D ImageBg { get; set; }

        private Texture2D ImageShip { get; set; }

        public override void Initialise()
        {
            base.Initialise();
            this.currentPlayer = CreatePlayer.Create(PlayerTypes.FirstPlayer, ShipType.Destroyer, "ivan4o");
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
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Down))
            {
                this.posShip.Y += 3;
                this.ValidateShipPos();
            }

            if (state.IsKeyDown(Keys.Up))
            {
                this.posShip.Y -= 3;
                this.ValidateShipPos();
            }

            if (state.IsKeyDown(Keys.Right))
            {
                this.posShip.X += 3;
                this.ValidateShipPos();
            }

            if (state.IsKeyDown(Keys.Left))
            {
                this.posShip.X -= 3;
                this.ValidateShipPos();
            }

            if (state.IsKeyDown(Keys.Space))
            {
                this.isPressed = true;
                if (!this.ballInitialised)
                {
                    CannonBall.Initialise(
                        new Vector2(
                            this.posShip.X + this.ImageShip.Width, 
                            this.posShip.Y + (this.ImageShip.Height / 2f)));
                    this.ballInitialised = true;
                }
            }

            if (this.isPressed)
            {
                CannonBall.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.ImageBg, new Vector2(0, 0));
            spriteBatch.Draw(this.ImageShip, this.posShip);
            if (this.isPressed)
            {
                if (CannonBall.PosCannon.X < ScreenManager.Instance.Dimensions.X)
                {
                    CannonBall.Draw(spriteBatch);
                }
                else
                {
                    this.ballInitialised = false;
                    this.isPressed = false;
                }
            }
        }

        private void ValidateShipPos()
        {
            if (this.posShip.X < 0)
            {
                this.posShip.X = 0;
            }

            if (this.posShip.Y < 0)
            {
                this.posShip.Y = 0;
            }

            if (this.posShip.Y > ScreenManager.Instance.Dimensions.Y - this.ImageShip.Height)
            {
                this.posShip.Y = ScreenManager.Instance.Dimensions.Y - this.ImageShip.Height;
            }

            if (this.posShip.X > ScreenManager.Instance.Dimensions.X - this.ImageShip.Width)
            {
                this.posShip.X = ScreenManager.Instance.Dimensions.X - this.ImageShip.Width;
            }
        }
    }
}