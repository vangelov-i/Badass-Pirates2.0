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
        private readonly string pathBg = "Backgrounds/BG";

        private readonly string pathShip = "Ships/ship3novo";

        private Player currentPlayer;

        //private bool isPressed = false;

        //private CannonBall cannon { get; set; }

        private Vector2 posShip;

        // public Image Image { get; set; }
        private Texture2D imageBg { get; set; }

        private Texture2D imageShip { get; set; }

        private float X { get; set; }

        private float Y { get; set; }

        //private readonly SpriteBatch spriteBatch = ScreenManager.Instance.SpriteBatch;

        public override void Initialise()
        {
            base.Initialise();
            this.currentPlayer = CreatePlayer.Create(PlayerTypes.FirstPlayer, ShipType.Destroyer, "ivan4o");
            //this.cannon.Initialise();
            // this.posCannon.X = this.posShip.X;
            // this.posCannon.Y = this.posShip.Y;
        }

        public override void LoadContent()
        {
            base.LoadContent();
            //this.cannon.LoadContent();
            this.imageShip = this.Content.Load<Texture2D>(this.pathShip);
            this.imageBg = this.Content.Load<Texture2D>(this.pathBg);

            /*this.Image.LoadContent()*/
        }

        public override void UnloadContent()
        {
            base.UnloadContent();

            // this.Image.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

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

            //if (state.IsKeyDown(Keys.Space))
            //{
            //    this.cannon.Update(gameTime);
            //}
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.imageBg, new Vector2(0, 0));
            spriteBatch.Draw(this.imageShip, this.posShip);

            // this.Image.Draw(spriteBatch);
        }
    }
}