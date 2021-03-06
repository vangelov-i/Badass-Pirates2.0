﻿namespace Badass_Pirates.Screens
{
    #region

    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Objects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;

    #endregion

    public class MenuScreen : GameScreen
    {
        private Button cruiser;

        //private ContentManager content = ScreenManager.Instance.Content;

        //private GameState _currentGameState = GameState.MainMenu;

        //Screen Adjustments

        private const int _screenWidth = 1366;

        private const int _screenHeight = 768;


        // SelectShipScreen
        private Button _btnPlay;

        private Button _controls;

        private Button destroyer;

        private Button battleship;

        private Image logo;

        //private static MenuScreen instance = new MenuScreen();

        bool firstChoiceMade;

        bool secondChoiceMade;

        public static ShipType FirstShip { get; private set; }

        public static ShipType SecondShip { get; private set; }

        //public static MenuScreen Instance
        //{
        //    get
        //    {
        //        //if (instance == null)
        //        //{
        //        //    instance = new MenuScreen();
        //        //}
        //        return instance;
        //    }
        //    set
        //    {
        //        instance = value;
        //    }
        //}
        //


        public override void LoadContent()
        {
            base.LoadContent();
            this.logo = new Image("logo");
            this.logo.LoadContent();

            this._btnPlay = new Button(this.Content.Load<Texture2D>("Buttons/play"));
            this._btnPlay.Size = new Vector2(200,100);
            this._btnPlay.setPosition(new Vector2(1166, 170));
            this._btnPlay.ConstFlash = true;

            this._controls = new Button(this.Content.Load<Texture2D>("Buttons/controls"));
            this._controls.setPosition(new Vector2(0, 150));
            this._controls.Size = new Vector2(200, 100);

            this.destroyer = new Button(this.Content.Load<Texture2D>("ShipsContents/destroyerLeft"));
            this.destroyer.setPosition(new Vector2(100, 400));
            this.destroyer.Size = new Vector2(137, 150);

            this.battleship = new Button(this.Content.Load<Texture2D>("ShipsContents/battleshipLeft"));
            this.battleship.setPosition(new Vector2(600, 550));
            this.battleship.Size = new Vector2(137, 150);

            this.cruiser = new Button(this.Content.Load<Texture2D>("ShipsContents/cruiserLeft"));
            this.cruiser.setPosition(new Vector2(1100, 400));
            this.cruiser.Size = new Vector2(137, 150);

        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();

            if (this._controls.IsClicked)
            {
                ScreenManager.Instance.CurrentScreen = new ControlScreen();
            }
            else if (this._btnPlay.IsClicked)
            {
                ScreenManager.Instance.CurrentScreen = new TitleScreen();
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

            if (this.firstChoiceMade && this.secondChoiceMade)
            {
                this._btnPlay.Update(mouse);
            }

            this._controls.Update(mouse);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            
            spriteBatch.Draw(
                this.Content.Load<Texture2D>("Backgrounds/sea"),
                new Rectangle(0, 0, _screenWidth, _screenHeight),
                Color.White);

            spriteBatch.Draw(this.logo.Texture,new Vector2(400,250));

            if (!this.firstChoiceMade || !this.secondChoiceMade)
            {
                // Player 1 / Player 2          TODO: grozno e taka, trqbva po- elegantno
                spriteBatch.Draw(this.Content.Load<Texture2D>("PLAYER"),
                    new Rectangle(600, 35, 100, 27),
                    Color.White);
                //
            }

            if (!this.firstChoiceMade)
            {
                spriteBatch.Draw(this.Content.Load<Texture2D>("PlayerOne"),
                    new Rectangle(700, 0, 50, 72),
                    Color.White);
            }
            else if (!this.secondChoiceMade)
            {
                spriteBatch.Draw(this.Content.Load<Texture2D>("PlayerTwo"),
                    new Rectangle(700, 0, 50, 72),
                    Color.White);
            }


            if (this.secondChoiceMade)
            {
                this._btnPlay.Draw(spriteBatch);
            }

            if (!this.battleship.ShipTaken && !this.secondChoiceMade)
            {
                this.battleship.Draw(spriteBatch);
                // grozno go napraih tva... ne mi se zanimava veche :/
                //spriteBatch.Draw(this.Content.Load<Texture2D>("statsDestroyer"),
                //    new Rectangle(250, 300, 122, 110),
                //    Color.White);
            }

            if (!this.cruiser.ShipTaken && !this.secondChoiceMade)
            {
                this.cruiser.Draw(spriteBatch);
            }

            if (!this.destroyer.ShipTaken && !this.secondChoiceMade)
            {
                this.destroyer.Draw(spriteBatch);
            }

            this._controls.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}