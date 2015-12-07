namespace Badass_Pirates.EngineComponents.Screens
{
    #region

    using System.Diagnostics;
    using System.Text;

    using Badass_Pirates.EngineComponents.Collisions;
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

        private Image smoke;

        private Player firstPlayer;

        private bool colliding;

        public override void Initialise()
        {
            base.Initialise();
            this.firstPlayer = new Player();
            this.firstPlayer.Initialise(ShipType.Destroyer, PlayerTypes.FirstPlayer);
            this.background = new Image("Backgrounds/BG");
            // Инициализация на класа колизия
            this.colliding = ItemsCollision.Collide(this.firstPlayer.CurrentPlayer.Ship);

            // Чрез конструктор се създава нов Item.Като параметър му се подава пътя на картинката
            Item.Initialise(6);

            // Чрез параметърът на Initialise,се подава интервала,през който се показва Item - a
            this.background.Initialise();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            this.firstPlayer.LoadContent();
            this.background.LoadContent();
            Item.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            this.firstPlayer.UnloadContent();
            this.background.UnloadContent();
            Item.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.firstPlayer.Update(gameTime);
            Item.Update(gameTime);

            // проверка във всеки framе за колизия
            this.colliding = ItemsCollision.Collide(this.firstPlayer.CurrentPlayer.Ship);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            this.background.Draw(spriteBatch, Vector2.Zero);
            this.firstPlayer.Draw(spriteBatch);

            // ако няма колизия,рисува Item-a
            if (!this.colliding)
            {
                Item.Draw(spriteBatch);
            }
        }
    }
}