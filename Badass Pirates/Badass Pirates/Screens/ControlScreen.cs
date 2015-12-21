namespace Badass_Pirates.Screens
{
    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Objects;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class ControlScreen : GameScreen
    {
        //TODO ADD TO CONST's CLASS

        private const int _screenWidth = 1366;

        private const int _screenHeight = 768;

        private Texture2D background;

        //private GameState _currentGameState = GameState.Controls;

        private Button back;

        public ControlScreen()
        {
            this.Content = ScreenManager.Instance.Content;
            this.back = new Button(this.Content.Load<Texture2D>("Buttons/back"));
            this.back.setPosition(new Vector2(50, 50));
            this.back.Size = new Vector2(75, 75);
        }

        public override void LoadContent()
        {
            base.LoadContent();
            this.Content.Load<Texture2D>("Backgrounds/sea");
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            this.Content.Unload();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            MouseState mouse = Mouse.GetState();

            if (this.back.IsClicked)
            {
                ScreenManager.Instance.CurrentScreen = ScreenManager.Instance.MenuScreen;
            }
            this.back.Update(mouse);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                        this.Content.Load<Texture2D>("Backgrounds/sea"),
                        new Rectangle(0, 0, _screenWidth, _screenHeight),
                        Color.White);

            this.back.Draw(spriteBatch);

            // Player 1 
            spriteBatch.Draw(this.Content.Load<Texture2D>("PLAYER"),
                           new Rectangle(200, 35, 100, 27),
                           Color.White);
            //

            spriteBatch.Draw(this.Content.Load<Texture2D>("PlayerOne"),
                            new Rectangle(300, 0, 50, 72),
                            Color.White);

            spriteBatch.Draw(this.Content.Load<Texture2D>("wasd"),
                new Rectangle(150, 110, 160, 110),
                Color.White);

            spriteBatch.Draw(this.Content.Load<Texture2D>("Shift"),
                new Rectangle(350, 100, 159, 60),
                Color.White);

            spriteBatch.Draw(this.Content.Load<Texture2D>("Ctrl"),
                new Rectangle(350, 165, 50, 50),
                Color.White);


            // Player 2 
            spriteBatch.Draw(this.Content.Load<Texture2D>("PLAYER"),
               new Rectangle(950, 35, 100, 27),
               Color.White);


            spriteBatch.Draw(this.Content.Load<Texture2D>("PlayerTwo"),
                           new Rectangle(1050, 0, 50, 72),
                           Color.White);


            spriteBatch.Draw(this.Content.Load<Texture2D>("arrowKeys"),
                new Rectangle(900, 110, 169, 110),
                Color.White);


            spriteBatch.Draw(this.Content.Load<Texture2D>("Shift"),
                new Rectangle(1100, 100, 159, 60),
                Color.White);

            spriteBatch.Draw(this.Content.Load<Texture2D>("Ctrl"),
                new Rectangle(1100, 165, 50, 50),
                Color.White);

            base.Draw(spriteBatch);
        }
    }
}
