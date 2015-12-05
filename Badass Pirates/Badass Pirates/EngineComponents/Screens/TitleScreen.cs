namespace Badass_Pirates.EngineComponents.Screens
{
    #region

    using System;

    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Player = Badass_Pirates.EngineComponents.Objects.Player;

    #endregion

    public class TitleScreen : GameScreen
    {
        private Image background;

        private Player firstPlayer;

        private Image firstBonus;

        public override void Initialise()
        {
            base.Initialise();
            this.firstPlayer = new Player();
            this.firstPlayer.Initialise(ShipType.Destroyer, PlayerTypes.FirstPlayer);
            this.background = new Image("Backgrounds/BG");
            this.firstBonus = new Image("BonusItems/imag2");
            this.background.Initialise();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            this.firstPlayer.LoadContent();
            this.background.LoadContent();
            this.firstBonus.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            this.firstBonus.UnloadContent();
            this.firstPlayer.UnloadContent();
            this.background.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.firstPlayer.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            this.background.Draw(spriteBatch, Vector2.Zero);
            this.firstBonus.Draw(spriteBatch, Vector2.Zero);
            this.firstPlayer.Draw(spriteBatch);
        }
    }
}