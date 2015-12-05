namespace Badass_Pirates.EngineComponents.Screens
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Badass_Pirates.EngineComponents.Player;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Player = Badass_Pirates.EngineComponents.Player.Player;

    public class TitleScreen : GameScreen
    {

       private Player firstPlayer;

       private Image background;

       public override void Initialise()
        {
            base.Initialise();
            this.firstPlayer = new Player();
            this.firstPlayer.Initialise(ShipType.Destroyer, PlayerTypes.FirstPlayer);
            this.background = new Image("Backgrounds/BG");
            this.background.Initialise();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            this.firstPlayer.LoadContent();
            this.background.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
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
            this.firstPlayer.Draw(spriteBatch);
        }
    }
}
