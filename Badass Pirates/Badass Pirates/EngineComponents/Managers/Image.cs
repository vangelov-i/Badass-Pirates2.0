namespace Badass_Pirates.EngineComponents.Managers
{
    #region

    using Badass_Pirates.Enums;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public class Image
    {
        private ContentManager content;

        private Vector2 position;

        public Image(string path)
        {
            this.Path = path;
        }

        public Vector2 Position
        {
            get
            {
                return this.position;
            }
        }

        public Texture2D Texture { get; private set; }

        public bool IsActive { get; set; }

        private string Path { get; set; } // pyrvonachalno beshe bez setter, no pishteshe che iska!

        public virtual void Initialise()
        {
            this.IsActive = true;
        }

        public virtual void LoadContent()
        {
            this.content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
            this.Texture = this.content.Load<Texture2D>(this.Path);
            this.IsActive = true;
        }

        public virtual void UnloadContent()
        {
            this.content.Unload();
            this.IsActive = false;
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            spriteBatch.Draw(this.Texture, pos);
        }

        public void SetPosition(Vector2 pos)
        {
            this.position = pos;
        }
    }
}