namespace Badass_Pirates.Screens
{
    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Objects;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class ConstrolsScreen : GameScreen
    {
        //TODO ADD TO CONST's CLASS

        private const int _screenWidth = 1366;

        private const int _screenHeight = 768;

        private Texture2D background;


        private GameState _currentGameState = GameState.Controls;      

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                        this.Content.Load<Texture2D>("Backgrounds/sea"),
                        new Rectangle(0, 0, _screenWidth, _screenHeight),
                        Color.White);
            // Player 1 / Player 2 
            spriteBatch.Draw(this.Content.Load<Texture2D>("PLAYER"),
                           new Rectangle(600, 35, 100, 27),
                           Color.White);
            //

            spriteBatch.Draw(this.Content.Load<Texture2D>("PlayerOne"),
                            new Rectangle(700, 0, 50, 72),
                            Color.White);

            spriteBatch.Draw(this.Content.Load<Texture2D>("PlayerOne"),
                           new Rectangle(700, 0, 50, 72),
                           Color.White);

            spriteBatch.Draw(this.Content.Load<Texture2D>("PlayerTwo"),
                           new Rectangle(700, 0, 50, 72),
                           Color.White);

            base.Draw(spriteBatch);
            // CTRL + SHIFT controls draw
            spriteBatch.Draw(this.Content.Load<Texture2D>("Ctrl"),
                new Rectangle(950, 0, 50, 50),
                Color.White);

            spriteBatch.Draw(this.Content.Load<Texture2D>("Shift"),
                new Rectangle(950, 55, 159, 60),
                Color.White);
            //

            // Controls First Player
            spriteBatch.Draw(this.Content.Load<Texture2D>("arrowKeys"),
                new Rectangle(750, 0, 160, 110),
                Color.White);
            //

            // Controls Second Player
            spriteBatch.Draw(this.Content.Load<Texture2D>("wasd"),
                new Rectangle(750, 0, 169, 110),
                Color.White);
            //
        }
    }
}
