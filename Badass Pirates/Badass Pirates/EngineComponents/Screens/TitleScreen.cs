﻿namespace Badass_Pirates.EngineComponents.Screens
{
    #region

    using System;

    using Badass_Pirates.EngineComponents.Controls;
    using Badass_Pirates.EngineComponents.Fonts;
    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.EngineComponents.Objects;
    using Badass_Pirates.Exceptions;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Player = Badass_Pirates.EngineComponents.Objects.Player;

    #endregion

    public class TitleScreen : GameScreen
    {
        private Image background;

        private Font gameOver;

        private bool end;

        private FirstPlayer player;

        public static Player FirstPlayer { get; private set; }

        public static Player SecondPlayer { get; private set; }

        public override void Initialise()
        {
            base.Initialise();
            this.end = false;
            this.gameOver = new Font(Color.DarkRed, "Fonts", "big");
            FirstPlayer = new Player();
            SecondPlayer = new Player();
            FirstPlayer.Initialise(ShipType.Destroyer, PlayerTypes.FirstPlayer);
            SecondPlayer.Initialise(ShipType.Cruiser, PlayerTypes.SecondPlayer);
            this.background = new Image("Backgrounds/BG");

            Item.Initialise(3);

            this.background.Initialise();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            FirstPlayer.LoadContent();
            SecondPlayer.LoadContent();
            this.background.LoadContent();
            this.gameOver.LoadContent();
            Item.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            FirstPlayer.UnloadContent();
            SecondPlayer.UnloadContent();
            this.background.UnloadContent();
            this.gameOver.UnloadContent();
            Item.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            try
            {
                base.Update(gameTime);
                FirstPlayer.Update(gameTime);
                SecondPlayer.Update(gameTime);
                Item.Update(gameTime);
            }
            catch (OutOfHealthException)
            {
                this.end = true;
                PlayerControls.control = false;
                BallControls.controls = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            this.background.Draw(spriteBatch, Vector2.Zero);
            FirstPlayer.Draw(spriteBatch);
            SecondPlayer.Draw(spriteBatch);
            if (this.end)
            {
                this.gameOver.Draw(
                    spriteBatch,
                    new Vector2(400, 140),
                    $"SHIP {(FirstPlayer.CurrentPlayer.Ship.Health <= 0  ? " Second" : $" {(SecondPlayer.CurrentPlayer.Ship.Health <= 0 ? "First" : null)} VICTORY")}");
                    
            }
            if (FirstPlayer.Colliding == false)
            {
                Item.Draw(spriteBatch);
            }
        }
    }
}