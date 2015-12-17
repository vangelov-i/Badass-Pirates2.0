namespace Badass_Pirates.Screens
{
    #region

    using Badass_Pirates.Fonts;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Objects;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public class TitleScreen : GameScreen
    {
        private Image background;

        private bool end;

        private static VirtualPlayer firstPlayer;

        private static VirtualPlayer secondPlayer;

        public static VirtualPlayer FirstPlayer
        {
            get
            {
                return firstPlayer;
            }
            set
            {
                firstPlayer = value;
            }
        }

        public static VirtualPlayer SecondPlayer
        {
            get
            {
                return secondPlayer;
            }
            set
            {
                secondPlayer = value;
            }
        }

        public TitleScreen ()
        {
            this.Initialise();
            this.LoadContent();
        }

        public sealed override void Initialise()
        {
            base.Initialise();
            FirstPlayer = new VirtualPlayer();
            SecondPlayer = new VirtualPlayer();
            FirstPlayer.Initialise(MenuScreen.FirstShip, PlayerTypes.FirstPlayer);
            SecondPlayer.Initialise(MenuScreen.SecondShip, PlayerTypes.SecondPlayer);
            this.end = false;
            this.background = new Image("Backgrounds/seaFaded");
            FontsManager.Initialise();
            Item.Initialise(3);
            this.background.Initialise();
        }

        public sealed override void LoadContent()
        {
            base.LoadContent();
            FirstPlayer.LoadContent();
            SecondPlayer.LoadContent();
            this.background.LoadContent();
            FontsManager.LoadContent();
            Item.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            FirstPlayer.UnloadContent();
            SecondPlayer.UnloadContent();
            this.background.UnloadContent();
            FontsManager.UnloadContent();
            Item.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Item.Update(gameTime);

            FirstPlayer.Update(gameTime);
            SecondPlayer.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            this.background.Draw(spriteBatch, Vector2.Zero);

            FirstPlayer.Draw(spriteBatch);
            SecondPlayer.Draw(spriteBatch);

            FontsManager.Draw(spriteBatch);

            if (FirstPlayer.itemColliding == false)
            {
                Item.Draw(spriteBatch);
            }
        }
    }
}