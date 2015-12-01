namespace Badass_Pirates.EngineComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class Image
    {
        #region Fields & Properties

        private ContentManager content;
        
        public RenderTarget2D RenderTarget { get; set; }

        public Rectangle SourceRectangle { get; set; }

        public float Alpha { get; set; }

        public string Text { get; set; }

        public string Path { get; set; }

        public Texture2D Texture { get; set; }

        public Vector2 Origin { get; set; }

        public Vector2 Position { get; set; }

        public Vector2 Scale { get; set; }
        #endregion

        public Image()
        {
            this.Path = string.Empty;
            this.Text = string.Empty;
            this.Position = Vector2.Zero;
            this.Scale = Vector2.One;
            this.Alpha = 1.0f;
            this.SourceRectangle = Rectangle.Empty;
        }

        #region Methods
        public void LoadContent()
        {
            this.content = new ContentManager(ScreenManager.Instance.content.ServiceProvider, "Content");
            Vector2 dimensions = Vector2.Zero;
            if (this.Path != string.Empty)
            {
                this.Texture = this.content.Load<Texture2D>(this.Path);
            }

            if (this.SourceRectangle == Rectangle.Empty)
            {
                this.SourceRectangle = new Rectangle(0, 0, (int)dimensions.X, (int)dimensions.Y);
            }

            if (this.Texture != null)
            {
                dimensions.X += this.Texture.Width;
                dimensions.Y += this.Texture.Height;
            }

            this.RenderTarget = new RenderTarget2D(ScreenManager.Instance.GraphicsDevice, (int)dimensions.X, (int)dimensions.Y);
            ScreenManager.Instance.GraphicsDevice.SetRenderTarget(this.RenderTarget);
            ScreenManager.Instance.GraphicsDevice.Clear(Color.Transparent);
            ScreenManager.Instance.SpriteBatch.Begin();
            ScreenManager.Instance.Draw(this.Texture,);
            ScreenManager.Instance.SpriteBatch.End();
        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }
        #endregion
    }
}
