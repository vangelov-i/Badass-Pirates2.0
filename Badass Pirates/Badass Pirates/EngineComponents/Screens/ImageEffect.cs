namespace Badass_Pirates.EngineComponents
{

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class ImageEffect
    {
        public ImageEffect()
        {
            
        }

        public bool IsActive { get; set; }

        protected Image image { get; set; }
        
        public virtual void LoadContent(ref Image image)
        {
            this.image = image;
        }

        public virtual void UnloadContent()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
