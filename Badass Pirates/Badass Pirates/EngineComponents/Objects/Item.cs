namespace Badass_Pirates.EngineComponents.Objects
{
    #region

    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    using Badass_Pirates.EngineComponents.Managers;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public struct Item
    {
        #region Fields

        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore",
            Justification = "Reviewed. Suppression is OK here.")]
        private const int TIME_SHOWN = 4;
        
        private static Random random;

        private readonly Image bonusImage;

        private Vector2 position;

        private Stopwatch stopWatch;

        private int timeInterval;

        private bool draw;

        private float screenHeight;

        private float screenWidth;

        private int timeCounter;

        private float timer;

        #endregion

        public Item(string path)
        {
            this.bonusImage = new Image(path);
            this.draw = false;
            this.position = new Vector2();
            this.screenHeight = 0f;
            this.screenWidth = 0f;
            this.stopWatch = null;
            this.timeCounter = 0;
            this.timer = 0;
            random = new Random();
            this.timeInterval = 0;
        }

        public void Initialise(int intervalShown)
        {
            this.draw = false;
            this.timeInterval = intervalShown;
            this.screenHeight = ScreenManager.Instance.Dimensions.X;
            this.screenWidth = ScreenManager.Instance.Dimensions.Y;
            this.stopWatch = new Stopwatch();
        }

        public void LoadContent()
        {
            this.bonusImage.LoadContent();
        }

        public void UnloadContent()
        {
            this.bonusImage.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            this.timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.timeCounter += (int)this.timer;
            if (this.timer >= 1.0F)
            {
                this.timer = 0F;
            }

            if (Math.Abs(this.timeCounter % TIME_SHOWN) < 0.0000001)
            {
                this.stopWatch.Start();
                this.draw = true;
            }

            if (this.stopWatch.Elapsed.Seconds >= this.timeInterval
                && Math.Abs(this.timeCounter % TIME_SHOWN) > 0.0000001)
            {
                this.stopWatch.Stop();
                this.stopWatch.Reset();
                this.SetRandoms();
                this.draw = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.draw && this.stopWatch.Elapsed.Seconds <= TIME_SHOWN)
            {
                spriteBatch.Draw(this.bonusImage.Texture, this.position);
            }
        }

        private void SetRandoms()
        {
            this.position = new Vector2(
                random.Next(0, (int)this.screenWidth - this.bonusImage.Texture.Width), 
                random.Next(0, (int)this.screenHeight - this.bonusImage.Texture.Height));
        }
    }
}