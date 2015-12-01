namespace Badass_Pirates.EngineComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SplashScreen : GameScreen
    {
        private Texture2D image;
        
        private string Path { get; set; }

        public override void LoadContent()
        {
            base.LoadContent();
            this.image = this.Content.Load<Texture2D>(this.Path);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, Vector2.Zero, Color.White);
        }
    }
}
