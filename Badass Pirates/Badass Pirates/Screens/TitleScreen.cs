namespace Badass_Pirates.Screens
{
    #region

    using Badass_Pirates.Collisions;
    using Badass_Pirates.Controls;
    using Badass_Pirates.Exceptions;
    using Badass_Pirates.Fonts;
    using Badass_Pirates.GameObjects.Mobs.Boss;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Objects;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Player = Badass_Pirates.Objects.Player;

    #endregion

    public class TitleScreen : GameScreen
    {
        private Image background;

        private bool end;

        private static Player firstPlayer;

        private static Player secondPlayer;

        private bool callTheBoss = false;

        private bool bassCalled = false;
        
        public static Player FirstPlayer
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

        public static Player SecondPlayer
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
        

        public override void Initialise()
        {
            base.Initialise();
            FirstPlayer = new Player();
            SecondPlayer = new Player();
            FirstPlayer.Initialise(ShipType.Battleship, PlayerTypes.FirstPlayer);
            SecondPlayer.Initialise(ShipType.Destroyer, PlayerTypes.SecondPlayer);
            this.end = false;
            this.background = new Image("Backgrounds/seajpg");
            FontsManager.Initialise();
            Item.Initialise(3);
            this.background.Initialise();
        }

        public override void LoadContent()
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
            Boss.Instance.UnloadContent();
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

            if (!this.bassCalled && gameTime.ElapsedGameTime.TotalSeconds > 5)
            {
                Boss.Instance = new Boss();
                this.callTheBoss = true;
                this.bassCalled = true;
                Boss.Instance.CallTheBoss();
                //Boss.Instance.Update();
            }
            else if (this.bassCalled)
            {
                Boss.Instance.Update();
            }
            //try
            //{
            FirstPlayer.Update(gameTime);
                SecondPlayer.Update(gameTime);
            //}
            //catch (OutOfHealthException)
            //{
            //    this.end = true;
            //    PlayerControls.control = false;
            //    BallControls.control = false;
            //}

            FontsManager.Update(gameTime, this.end);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            this.background.Draw(spriteBatch, Vector2.Zero);

            if (this.callTheBoss)
            {
                Boss.Instance.Draw(spriteBatch);
            }

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