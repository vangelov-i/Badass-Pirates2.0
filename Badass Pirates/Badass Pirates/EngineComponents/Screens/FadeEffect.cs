namespace Badass_Pirates.EngineComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;

    public class FadeEffect : ImageEffect
    {
        public FadeEffect()
        {
            this.FadeSpeed = 1;
            this.Increase = false;
        }

        public float FadeSpeed { get; set; }

        public bool Increase { get; set; }

        public override void LoadContent(ref Image image)
        {
            base.LoadContent(ref image);
            this.Increase = false;
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (this.image.IsActive)
            {
                if (!this.Increase)
                {
                    this.image.Alpha -= this.FadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    this.image.Alpha += this.FadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (this.image.Alpha < 0.0f)
                {
                    this.Increase = true;
                    this.image.Alpha = 0;
                }
                else if (this.image.Alpha > 1.0f)
                {
                    this.Increase = false;
                    this.image.Alpha = 1.0f;
                }
                else
                {
                    this.image.Alpha = 1.0f;
                }
            }
        }
    }
}
