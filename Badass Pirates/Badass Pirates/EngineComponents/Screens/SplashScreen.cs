namespace Badass_Pirates.EngineComponents.Screens
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
        private readonly string pathBg = "Backgrounds/BG";

        private readonly string pathShip = "Ships/ship3novo";

        private bool ballInitialised;

        private GameObjects.Players.Player currentPlayer;

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
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            KeyboardState state = Keyboard.GetState();

            // TODO NOT IMPLEMENTED BALL LOGIC AND DRAW
            //if (state.IsKeyDown(Keys.Space))
            //{
            //    this.isPressed = true;
            //    if (!this.ballInitialised)
            //    {
            //        CannonBall.Initialise();
            //        this.ballInitialised = true;
            //    }
            //}

            //if (this.isPressed)
            //{
            //    CannonBall.Update(gameTime);
            //}

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.ImageBg, new Vector2(0, 0));
            spriteBatch.Draw(this.ImageShip, this.posShip);

            // TODO NOT IMPLEMENTED BALL LOGIC AND DRAW
            //if (this.isPressed)
            //{
            //    //if (CannonBall.PosCannon.X < ScreenManager.Instance.Dimensions.X)
            //    //{
            //    //    CannonBall.Draw(spriteBatch);
            //    //}
            //    else
            //    {
            //        this.ballInitialised = false;
            //        this.isPressed = false;
            //    }
            //}
        }
    }
}