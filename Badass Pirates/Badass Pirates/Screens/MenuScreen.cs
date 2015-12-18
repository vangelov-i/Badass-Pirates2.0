namespace Badass_Pirates.Screens
{
    #region

    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Objects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    #endregion

    public class MenuScreen : GameScreen
    {
        private Button cruiser;

        private GameState _currentGameState = GameState.MainMenu;

        //Screen Adjustments

        private const int _screenWidth = 1366;

        private const int _screenHeight = 768;


        // SelectShipScreen
        private Button _btnPlay;

        private Button destroyer;

        private Button battleship;

        bool firstChoiceMade;

        bool secondChoiceMade;

        public static ShipType FirstShip { get; private set; }

        public static ShipType SecondShip { get; private set; }
        //


        public override void LoadContent()
        {
            base.LoadContent();
            this._btnPlay = new Button(this.Content.Load<Texture2D>("button"));
            this._btnPlay.setPosition(new Vector2(570, 290));

            this.destroyer = new Button(this.Content.Load<Texture2D>("ShipsContents/destroyerLeft"));
            this.destroyer.setPosition(new Vector2(100, 140));
            this.destroyer.size = new Vector2(137, 150);

            this.battleship = new Button(this.Content.Load<Texture2D>("ShipsContents/battleshipLeft"));
            this.battleship.setPosition(new Vector2(600, 140));
            this.battleship.size = new Vector2(137, 150);

            this.cruiser = new Button(this.Content.Load<Texture2D>("ShipsContents/cruiserLeft"));
            this.cruiser.setPosition(new Vector2(1100, 140));
            this.cruiser.size = new Vector2(137, 150);

        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            switch (this._currentGameState)
            {
                case GameState.MainMenu:
                    if (this._btnPlay.IsClicked && this.firstChoiceMade && this.secondChoiceMade)
                    {
                        this._currentGameState = GameState.Playing;
                    }
                    this._btnPlay.Update(mouse);
                    break;

                case GameState.Playing:
                    ScreenManager.Instance.CurrentScreen = new TitleScreen();
                    break;

                case GameState.GameOver:

                    break;
            }

            #region SelectShipScreen

            // destroyer
            if (this.destroyer.IsClicked && !this.firstChoiceMade)
            {
                this.firstChoiceMade = true;
                FirstShip = ShipType.Destroyer;
            }
            else if (this.destroyer.IsClicked && this.firstChoiceMade && !this.secondChoiceMade
                && FirstShip != ShipType.Destroyer)
            {
                this.secondChoiceMade = true;
                this._btnPlay.ConstFlash = true;
                SecondShip = ShipType.Destroyer;
            }
            //

            // battleship
            if (this.battleship.IsClicked && !this.firstChoiceMade)
            {
                this.firstChoiceMade = true;
                FirstShip = ShipType.Battleship;
            }
            else if (this.battleship.IsClicked && this.firstChoiceMade && !this.secondChoiceMade 
                && FirstShip != ShipType.Battleship)
            {
                this.secondChoiceMade = true;
                this._btnPlay.ConstFlash = true;
                SecondShip = ShipType.Battleship;
            }
            //

            // cruiser
            if (this.cruiser.IsClicked && !this.firstChoiceMade)
            {
                this.firstChoiceMade = true;
                FirstShip = ShipType.Cruiser;
            }
            else if (this.cruiser.IsClicked && this.firstChoiceMade && !this.secondChoiceMade
                && FirstShip != ShipType.Cruiser)
            {
                this.secondChoiceMade = true;
                this._btnPlay.ConstFlash = true;
                SecondShip = ShipType.Cruiser;
            }
            //

            this.destroyer.Update(mouse);
            this.cruiser.Update(mouse);
            this.battleship.Update(mouse);

            #endregion


            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (this._currentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Draw(
                        this.Content.Load<Texture2D>("Backgrounds/sea"),
                        new Rectangle(0, 0, _screenWidth, _screenHeight),
                        Color.White);


                    if (!this.firstChoiceMade || !this.secondChoiceMade)
                    {
                        // Player 1 / Player 2          TODO: grozno e taka, trqbva po- elegantno
                        spriteBatch.Draw(this.Content.Load<Texture2D>("PLAYER"),
                            new Rectangle(600, 35, 100, 27),
                            Color.White);

                        // CTRL + SHIFT controls draw
                        spriteBatch.Draw(this.Content.Load<Texture2D>("Ctrl"),
                            new Rectangle(950, 0, 50, 50),
                            Color.White);

                        spriteBatch.Draw(this.Content.Load<Texture2D>("Shift"),
                            new Rectangle(950, 55, 159, 60),
                            Color.White);
                        //
                    }



                    if (!this.firstChoiceMade)
                    {
                        spriteBatch.Draw(this.Content.Load<Texture2D>("PlayerOne"),
                            new Rectangle(700, 0, 50, 72),
                            Color.White);

                        // Controls
                        spriteBatch.Draw(this.Content.Load<Texture2D>("arrowKeys"),
                            new Rectangle(750, 0, 160, 110),
                            Color.White);
                    }
                    else if (!this.secondChoiceMade)
                    {
                        spriteBatch.Draw(this.Content.Load<Texture2D>("PlayerTwo"),
                            new Rectangle(700, 0, 50, 72),
                            Color.White);

                        // Controls
                        spriteBatch.Draw(this.Content.Load<Texture2D>("wasd"),
                            new Rectangle(750, 0, 169, 110),
                            Color.White);
                    }


                    if (this.secondChoiceMade)
                    {
                        this._btnPlay.Draw(spriteBatch);
                    }

                    if (!this.battleship.ShipTaken && !this.secondChoiceMade)
                    {
                        this.battleship.Draw(spriteBatch);
                    }

                    if (!this.cruiser.ShipTaken && !this.secondChoiceMade)
                    {
                        this.cruiser.Draw(spriteBatch);
                    }

                    if (!this.destroyer.ShipTaken && !this.secondChoiceMade)
                    {
                        this.destroyer.Draw(spriteBatch);
                    }




                    break;

                case GameState.Playing:

                    break;

                case GameState.GameOver:

                    break;
            }
            spriteBatch.End();
        }
    }
}