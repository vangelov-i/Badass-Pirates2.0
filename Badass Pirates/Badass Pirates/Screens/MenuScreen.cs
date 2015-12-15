namespace Badass_Pirates.Screens
{
    #region

    using Badass_Pirates.Managers;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    #endregion

    public class MenuScreen : GameScreen
    {
        private Button _btnPlay;

        private GameState _currentGameState = GameState.MainMenu;

        //Screen Adjustments

        private const int _screenWidth = 1366;

        private const int _screenHeight = 768;

        public override void LoadContent()
        {
            base.LoadContent();
            //graphics.PrefferedBackBufferWidth = screenWidth;
            //graphics.PrefferedBackBufferHeight = screenHeight;
            //graphics.ApplayChanges();
            this._btnPlay = new Button(this.Content.Load<Texture2D>("button"));
            this._btnPlay.setPosition(new Vector2(350, 300));
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            switch (this._currentGameState)
            {
                case GameState.MainMenu:
                    if (this._btnPlay.isClicked)
                    {
                        this._currentGameState = GameState.Playing;
                    }
                    this._btnPlay.Update(mouse);
                    break;

                case GameState.Playing:
                    ScreenManager.instance.currentScreen = new TitleScreen();
                    break;

                case GameState.GameOver:

                    break;
            }
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (this._currentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Draw(
                        this.Content.Load<Texture2D>("Backgrounds/sea"),
                        new Rectangle(0, 0, _screenWidth, _screenHeight),
                        Color.White);
                    this._btnPlay.Draw(spriteBatch);
                    break;

                case GameState.Playing:

                    break;

                case GameState.GameOver:

                    break;
            }
            spriteBatch.End();
        }

        enum GameState
        {
            MainMenu,

            Playing,

            GameOver
        }
    }
}