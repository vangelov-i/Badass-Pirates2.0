﻿namespace Badass_Pirates.EngineComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class GameScreen
    {
        [XmlIgnore]
        public Type Type { get; set; }

        public GameScreen()
        {
            this.Type = this.GetType();
        }

        protected ContentManager Content { get; set; }

        #region Methods
        public virtual void LoadContent()
        {
            this.Content = new ContentManager(ScreenManager.Instance.content.ServiceProvider, "Content");
        }

        public virtual void Initialise()
        {
        }

        public virtual void UnloadContent()
        {
            this.Content.Unload();
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }
        #endregion
    }
}
