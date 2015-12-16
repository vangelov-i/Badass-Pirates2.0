namespace Badass_Pirates.Screens
{
    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Objects;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class SelectShipScreen : GameScreen
    {
        //TODO ADD TO CONST's CLASS
        private static readonly float Width = ScreenManager.Instance.Dimensions.X;

        private static readonly float Height = ScreenManager.Instance.Dimensions.Y;

        private Texture2D background;

        private Button destroyer;

        private Button battleship;

        private Button cruiser;

        private GameState _currentGameState = GameState.MainMenu;

        bool firstChoiceMade;

        bool secondChouceMade;

        public override void Initialise()
        {

        }

        public override void LoadContent()
        {
            this.destroyer = new Button(this.Content.Load<Texture2D>("ShipsContents/destroyerLeft"));
            this.destroyer.setPosition(new Vector2(100, 100));
            this.battleship = new Button(this.Content.Load<Texture2D>("ShipsContents/battleLeft"));
            this.battleship.setPosition(new Vector2(300, 300));
            this.cruiser = new Button(this.Content.Load<Texture2D>("ShipsContents/cruiserLeft"));
            this.cruiser.setPosition(new Vector2(500, 500));
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            // destroyer
            if (this.destroyer.isClicked && !this.firstChoiceMade)
            {
                this.firstChoiceMade = true;
                TitleScreen.FirstPlayer = new VirtualPlayer();
                TitleScreen.FirstPlayer.Initialise(ShipType.Destroyer, PlayerTypes.FirstPlayer);

                //this._currentGameState = GameState.Playing;
            }
            else if (this.destroyer.isClicked && this.firstChoiceMade)
            {
                this.secondChouceMade = true;
                TitleScreen.SecondPlayer = new VirtualPlayer();
                TitleScreen.SecondPlayer.Initialise(ShipType.Destroyer, PlayerTypes.SecondPlayer);

            }
            //

            // battleship
            if (this.battleship.isClicked && !this.firstChoiceMade)
            {
                this.firstChoiceMade = true;
                TitleScreen.FirstPlayer = new VirtualPlayer();
                TitleScreen.FirstPlayer.Initialise(ShipType.Battleship, PlayerTypes.FirstPlayer);

                //this._currentGameState = GameState.Playing;
            }
            else if (this.destroyer.isClicked && this.firstChoiceMade)
            {
                this.secondChouceMade = true;
                TitleScreen.SecondPlayer = new VirtualPlayer();
                TitleScreen.SecondPlayer.Initialise(ShipType.Battleship, PlayerTypes.SecondPlayer);

            }
            //

            // cruiser
            if (this.cruiser.isClicked && !this.firstChoiceMade)
            {
                this.firstChoiceMade = true;
                TitleScreen.FirstPlayer = new VirtualPlayer();
                TitleScreen.FirstPlayer.Initialise(ShipType.Cruiser, PlayerTypes.FirstPlayer);

                //this._currentGameState = GameState.Playing;
            }
            else if (this.destroyer.isClicked && this.firstChoiceMade)
            {
                this.secondChouceMade = true;
                TitleScreen.SecondPlayer = new VirtualPlayer();
                TitleScreen.SecondPlayer.Initialise(ShipType.Cruiser, PlayerTypes.SecondPlayer);

            }
            //

            if (this.firstChoiceMade && this.secondChouceMade)
            {
                
            }
            this.destroyer.Update(mouse);
            this.cruiser.Update(mouse);
            this.battleship.Update(mouse);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }


    }
}
