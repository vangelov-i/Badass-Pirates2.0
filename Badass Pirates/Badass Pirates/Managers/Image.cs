namespace Badass_Pirates.Managers
{
    #region

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    #endregion
    // TODO ЧИСТИЧЪК И СПРЕТНАТ
    public sealed class Image
    {
        private ContentManager content;

        public Image(string path)
        {
            this.Path = path;
        }

        public Texture2D Texture { get; private set; }

        public bool IsActive { get; set; }

        private string Path { get; } // pyrvonachalno beshe bez setter, no pishteshe che iska!

        public void Initialise()
        {
            this.IsActive = true;
        }

        public void LoadContent()
        {
            this.content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
            this.Texture = this.content.Load<Texture2D>(this.Path);
            this.IsActive = true;
        }

        public void UnloadContent()
        {
            this.content.Unload();
            this.IsActive = false;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            spriteBatch.Draw(this.Texture, pos);
        }
    }
}