namespace Badass_Pirates.EngineComponents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class ScreenManager
    {
        #region Properties
        private static ScreenManager instance;

        GameScreen currentScreen;

        public GraphicsDevice GraphicsDevice { get; set; }

        public SpriteBatch SpriteBatch { get; set; }

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
        } // => instance ?? (instance = new ScreenManager());


        public Vector2 Dimensions { get; private set; }

        public ContentManager content { get; private set; }

        public XmlManager<GameScreen> xmlGamescreenManager;
        #endregion

        #region Constructor
        public ScreenManager()
        {
            this.Dimensions = new Vector2(768, 1366);
            this.currentScreen = new SplashScreen();
            this.xmlGamescreenManager = new XmlManager<GameScreen>();
            this.xmlGamescreenManager.Tpye = this.currentScreen.Type;
            this.currentScreen = this.xmlGamescreenManager.Load("Content/Load/SplashScreen.xml");
        }
        #endregion

        #region Methods

        public void Initialise()
        {
            this.currentScreen.Initialise();
        }

        public void LoadContent(ContentManager contentParam)
        {
            this.content = new ContentManager(contentParam.ServiceProvider, "Content");
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
