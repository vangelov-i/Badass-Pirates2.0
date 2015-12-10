using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badass_Pirates.EngineComponents.Fonts
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class Font
    {
        private SpriteFont currentFont;

        private readonly Color color;

        private ContentManager content;

        private readonly string fontName;

        private readonly string fontsFolderName;

        public Font(Color fontColor, string folderName, string fontsName)
        {
            this.color = fontColor;
            this.fontsFolderName = folderName;
            this.fontName = this.fontsFolderName + "/" + fontsName;
        }

        //public void Initialise(string messageInput,Color fontColor,string folderName,string fontsName)
        //{
        //    this.message = messageInput;
        //    this.color = fontColor;
        //    this.fontsFolderName = folderName;
        //    this.fontName = this.fontsFolderName + fontsName;
        //}

        public void LoadContent()
        {
            this.content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
            this.currentFont = this.content.Load<SpriteFont>(this.fontName);
        }

        public void UnloadContent()
        {
            this.content.Unload();
        }

        public void Draw(SpriteBatch spriteBatch,Vector2 pos,string message)
        {
            spriteBatch.DrawString(this.currentFont,message,pos,this.color);
        }
    }
}
