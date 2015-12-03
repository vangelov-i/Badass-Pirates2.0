namespace Badass_Pirates.EngineComponents
{
    #region

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public class ScreenManager
    {
        #region Properties

        private static ScreenManager instance;

        private readonly GameScreen currentScreen;

        #region Constructor

        public ScreenManager()
        {
            this.Dimensions = new Vector2(1366, 768); // 768, 1366
            this.currentScreen = new SplashScreen();
            this.XmlGamescreenManager = new XmlManager<GameScreen>();
            this.XmlGamescreenManager.Tpye = this.currentScreen.Type;
            this.currentScreen = this.XmlGamescreenManager.Load("Content/Load/SplashScreen.xml");
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

        public SpriteBatch SpriteBatch { get; set; }

        public Vector2 Dimensions { get; private set; }

        public ContentManager Content { get; private set; }

        public XmlManager<GameScreen> XmlGamescreenManager { get; set; }

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