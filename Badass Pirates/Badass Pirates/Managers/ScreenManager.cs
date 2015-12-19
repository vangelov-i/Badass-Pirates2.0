namespace Badass_Pirates.Managers
{
    #region

    using Badass_Pirates.Screens;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    // TODO ЧИСТИЧЪК И СПРЕТНАТ
    public class ScreenManager
    {
        #region Properties
        
        private static ScreenManager instance;

        private GameScreen currentScreen;

        #region Constructor

        private ScreenManager()
        {
            this.Dimensions = new Vector2(1366, 768);
            this.currentScreen = MenuScreen.Instance;
        }

        #endregion

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScreenManager();
                }

                return instance;
            }
        }

        public GraphicsDevice GraphicsDevice { get; set; }

        // TODO referenciii beeee !!!! trqa sa slojat! da sa polzva tva

        public SpriteBatch SpriteBatch { get; set; }

        public Vector2 Dimensions { get; private set; }

        public ContentManager Content { get; private set; }

        public GameScreen CurrentScreen
        {
            get
            {
                return this.currentScreen;
            }
            set
            {
                this.currentScreen = value;
            }
        }

        #endregion

        #region Methods

        public void Initialise()
        {
            this.currentScreen.Initialise();
        }

        public void LoadContent(ContentManager contentParam)
        {
            this.Content = new ContentManager(contentParam.ServiceProvider, "Content");
            this.currentScreen.LoadContent();
        }

        public void UnloadContent()
        {
            this.currentScreen.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            this.currentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.currentScreen.Draw(spriteBatch);
        }

        #endregion
    }
}