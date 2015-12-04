namespace Badass_Pirates.EngineComponents.Screens
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class Image
    {
        private ContentManager content;

        public Image(string path)
        {
            this.Path = path;
        }

        public Texture2D Texture { get; private set; }

        public bool IsActive { get; set; }

        public string Path { get; set; }

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

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(this.Texture, position);
        }
    }
}
