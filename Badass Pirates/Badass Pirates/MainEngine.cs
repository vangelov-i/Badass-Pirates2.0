namespace Badass_Pirates
{
    using System.Runtime.CompilerServices;

    using Badass_Pirates.EngineComponents;
    using Badass_Pirates.Factory;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainEngine : Game
    {
        private GraphicsDeviceManager graphics;

        private SpriteBatch spriteBatch;

        public static SpriteBatch InstanceBatch;
        
        public MainEngine()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            MainEngine.InstanceBatch = this.spriteBatch;
            // TODO: Add your initialization logic here
            this.Content.RootDirectory = "Content";
            this.graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.Dimensions.Y;
            this.graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.Dimensions.X;
            this.graphics.IsFullScreen = this.IsActive;
            ScreenManager.Instance.Initialise();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            ScreenManager.Instance.GraphicsDevice = this.GraphicsDevice;
            ScreenManager.Instance.SpriteBatch = this.spriteBatch;
            ScreenManager.Instance.LoadContent(this.Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            ScreenManager.Instance.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            ScreenManager.Instance.Update(gameTime);
            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Transparent);
            this.spriteBatch.Begin();
            ScreenManager.Instance.Draw(this.spriteBatch);
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
