namespace Badass_Pirates.EngineComponents.Screens
{
    #region

    using Badass_Pirates.EngineComponents.Fonts;
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

        private static Player firstPlayer;

        private static Player secondPlayer;

        private GameObjects.Players.FirstPlayer player;

        public static Player FirstPlayer
        {
            get
            {
                return firstPlayer;
            }   
        }

        public static Player SecondPlayer
        {
            get
            {
                return secondPlayer;
            }    
        }

        
        public override void Initialise()
        {
            base.Initialise();
            firstPlayer = new Player();
            secondPlayer = new Player();
            firstPlayer.Initialise(ShipType.Destroyer, PlayerTypes.FirstPlayer);
            secondPlayer.Initialise(ShipType.Cruiser, PlayerTypes.SecondPlayer);
            this.background = new Image("Backgrounds/BG");
            
            Item.Initialise(3);
            
            this.background.Initialise();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            firstPlayer.LoadContent();
            secondPlayer.LoadContent();
            this.background.LoadContent();
            Item.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            firstPlayer.UnloadContent();
            secondPlayer.UnloadContent();
            this.background.UnloadContent();
            Item.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            firstPlayer.Update(gameTime);
            secondPlayer.Update(gameTime);
            Item.Update(gameTime);

            // проверка във всеки framе за колизия
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            this.background.Draw(spriteBatch, Vector2.Zero);
            firstPlayer.Draw(spriteBatch);
            secondPlayer.Draw(spriteBatch);

            /* ако няма колизия,рисува Item-a
            needs improvement -> made this way the item's not drawing only while the collision is presend
            in other words - when there is a collision at the current moment, the item isn't drawing, but it shouldn't start
            drawing again when the ship moves away. One option is to implement some counter checking if there was a collision 
            before the current moment and implement it in the if statement */
            if (firstPlayer.Colliding == false)
            {
                Item.Draw(spriteBatch);
            }
        }
    }
}