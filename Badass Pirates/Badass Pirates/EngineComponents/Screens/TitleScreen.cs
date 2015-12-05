namespace Badass_Pirates.EngineComponents.Screens
{
    #region

    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.EngineComponents.Objects;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Player = Badass_Pirates.EngineComponents.Objects.Player;

    #endregion

    public class TitleScreen : GameScreen
    {
        private Image background;

        private Item firstItem;

        private Player firstPlayer;

        public override void Initialise()
        {
            base.Initialise();
            this.firstPlayer = new Player();
            this.firstPlayer.Initialise(ShipType.Destroyer, PlayerTypes.FirstPlayer);
            this.background = new Image("Backgrounds/BG");

            // Чрез конструктор се създава нов Item.Като параметър му се подава пътя на картинката
            this.firstItem = new Item("PotionsContents/energyPotion");

            // Чрез параметърът на Initialise,се подава интервала,през който се показва Item - a
            this.firstItem.Initialise(12);
            this.background.Initialise();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            this.firstPlayer.LoadContent();
            this.background.LoadContent();
            this.firstItem.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            this.firstPlayer.UnloadContent();
            this.background.UnloadContent();
            this.firstItem.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.firstPlayer.Update(gameTime);
            this.firstItem.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            this.background.Draw(spriteBatch, Vector2.Zero);
            this.firstPlayer.Draw(spriteBatch);
            this.firstItem.Draw(spriteBatch);
        }
    }
}