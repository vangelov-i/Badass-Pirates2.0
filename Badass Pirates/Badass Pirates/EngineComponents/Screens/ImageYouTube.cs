//namespace Badass_Pirates.EngineComponents
//{
//    #region

//    using System;
//    using System.CodeDom;
//    using System.Collections.Generic;
//    using System.Runtime.CompilerServices;
//    using System.Xml.Serialization;

//    using Microsoft.Xna.Framework;
//    using Microsoft.Xna.Framework.Content;
//    using Microsoft.Xna.Framework.Graphics;

//    #endregion

//    public class Image
//    {
//        public Image()
//        {
//            this.Path = string.Empty;
//            this.Text = string.Empty;
//            this.Position = Vector2.Zero;
//            this.Scale = Vector2.One;
//            this.Alpha = 1.0f;
//            this.SourceRectangle = Rectangle.Empty;
//            this.effectList = new Dictionary<string, ImageEffect>();
//            this.Fd = (FadeEffect)this.effectList["FadeEffect"];
//        }

//        #region Fields & Properties
//        [XmlIgnore]
//        public Dictionary<string, ImageEffect> effectList { get; set; }

//        public string Effects { get; set; }

//        private ContentManager content;

//        [XmlIgnore]
//        public RenderTarget2D RenderTarget { get; set; }

//        public Rectangle SourceRectangle { get; set; }

//        public float Alpha { get; set; }

//        public string Text { get; set; }

//        public string Path { get; set; }

//        public bool IsActive { get; set; }

//        public FadeEffect FadeEffect { get; set; }

//        [XmlIgnore]
//        public Texture2D Texture { get; set; }

//        public Vector2 Origin { get; set; }

//        public Vector2 Position { get; set; }

//        public Vector2 Scale { get; set; }

//        //TODO Not implemented
//        public FadeEffect Fd { get; set; }

//        #endregion

//        #region Methods
       
//        public void LoadContent()
//        {
//            this.content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
//            Vector2 dimensions = Vector2.Zero;
//        }

//        public void UnloadContent()
//        {
//            this.content.Unload();
//        }

//        public void Update(GameTime gameTime)
//        {
//        }

//        public void Draw(SpriteBatch spriteBatch)
//        {
//            this.Origin = new Vector2(this.SourceRectangle.Width / 2f, this.SourceRectangle.Height / 2f);
//            spriteBatch.Draw(
//                this.Texture, 
//                this.Position + this.Origin, 
//                this.SourceRectangle, 
//                Color.White * this.Alpha, 
//                0.0f, 
//                this.Origin, 
//                this.Scale, 
//                SpriteEffects.None, 
//                0.0f);
//        }

//        private void Effect<T>(ref T effect)
//        {
//            if (effect == null)
//            {
//                effect = (T)Activator.CreateInstance(typeof(T));
//            }
//            else
//            {
//                (effect as ImageEffect).IsActive = true;
//                var obj = this;
//                (effect as ImageEffect).LoadContent(ref obj);
//            }

//            this.effectList.Add(
//                effect.GetType().ToString().Replace("Badass_Pirates.EngineComponents", string.Empty), 
//                effect as ImageEffect);
//        }

//        public void ActivateEffect(string effect)
//        {
//            if (this.effectList.ContainsKey(effect))
//            {
//                this.effectList[effect].IsActive = true;
//                var obj = this;
//                this.effectList[effect].LoadContent(ref obj);

//            }
//        }

//        public void DeactivateEffect(string effect)
//        {
//            if (this.effectList.ContainsKey(effect))
//            {
//                this.effectList[effect].IsActive = false;
//                this.effectList[effect].UnloadContent();
//            }
//        }
        

//        #endregion
//    }
//}