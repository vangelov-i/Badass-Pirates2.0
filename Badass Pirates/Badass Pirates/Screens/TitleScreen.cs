namespace Badass_Pirates.Screens
{
    #region

    using System;

    using Badass_Pirates.Enums;
    using Badass_Pirates.Factory;
    using Badass_Pirates.Fonts;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Models.Mobs.Boss;
    using Badass_Pirates.Models.Players;
    using Badass_Pirates.Objects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    #endregion

    public class TitleScreen : GameScreen
    {
        private Image background;

        private Button playAgain;

        private bool gameEnded;

        public TitleScreen()
        {
            this.Initialise();
            this.LoadContent();
        }

        public sealed override void Initialise()
        {
            base.Initialise();
            FirstPlayer.Instance.Initialise();
            SecondPlayer.Instance.Initialise();
            this.background = new Image("Backgrounds/seaFaded");
            FontsManager.Initialise();
            Item.Initialise(3);
            this.background.Initialise();
        }

        public sealed override void LoadContent()
        {
            base.LoadContent();
            this.playAgain = new Button(this.Content.Load<Texture2D>("button"));
            FirstPlayer.Instance.LoadContent();
            SecondPlayer.Instance.LoadContent();
            this.background.LoadContent();
            FontsManager.LoadContent();
            Item.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            FirstPlayer.Instance.UnloadContent();
            SecondPlayer.Instance.UnloadContent();
            this.background.UnloadContent();
            FontsManager.UnloadContent();
            Item.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Item.Update(gameTime);

            FirstPlayer.Instance.Update(gameTime);
            SecondPlayer.Instance.Update(gameTime);

            if ((FirstPlayer.Instance.Ship.Sunk && SecondPlayer.Instance.Ship.Sunk) ||
                (FirstPlayer.Instance.Ship.Sunk && Boss.Instance.Sunk) ||
                (SecondPlayer.Instance.Ship.Sunk && Boss.Instance.Sunk))
            {
                MouseState mouse = Mouse.GetState();
                this.playAgain.Update(mouse);
                this.gameEnded = true;

                if (this.playAgain.IsClicked)
                {
                    Environment.Exit(1);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            this.background.Draw(spriteBatch, Vector2.Zero);

            FirstPlayer.Instance.Draw(spriteBatch);
            SecondPlayer.Instance.Draw(spriteBatch);

            FontsManager.Draw(spriteBatch);

            if (FirstPlayer.Instance.ItemColliding == false)
            {
                Item.Draw(spriteBatch);
            }

            if (this.gameEnded)
            {
                this.playAgain.Draw(spriteBatch);
            }
        }
    }
}