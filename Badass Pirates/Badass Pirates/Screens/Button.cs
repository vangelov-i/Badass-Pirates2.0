﻿namespace Badass_Pirates.Screens
{
    #region

    using Badass_Pirates.Managers;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    #endregion

    public class Button
    {
        readonly Texture2D texture;

        Color colour = new Color(255, 255, 255, 255);

        bool down;

        private bool shipTaken;

        Vector2 position;

        Rectangle rectangle;

        private Vector2 size;

        private readonly GraphicsDevice graphics;

        public Button(Texture2D newTexture)
        {
            this.graphics = ScreenManager.Instance.GraphicsDevice;
            this.texture = newTexture;
            //screenWidth = 800, ScreenHeight = 600
            //ImageWidth = 100, ImageHeight = 20
            this.size = new Vector2(this.graphics.Viewport.Width / 8f, this.graphics.Viewport.Height / 30f);
        }

        public bool IsClicked { get; set; }

        public bool ConstFlash { get; set; }

        public bool ShipTaken
        {
            get { return this.shipTaken; }
        }

        public Vector2 Size
        {
            get { return this.size; }
            set { this.size = value; }
        }

        public Vector2 Position
        {
            get { return this.position; }
            set
            {
                this.position = value;
            }
        }

        public void Update(MouseState mouse)
        {
            this.rectangle = new Rectangle(
                (int)this.position.X,
                (int)this.position.Y,
                (int)this.size.X,
                (int)this.size.Y);
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouseRectangle.Intersects(this.rectangle) || this.ConstFlash)
            {
                if (this.colour.A == 255)
                {
                    this.down = false;
                }
                if (this.colour.A == 0)
                {
                    this.down = true;
                }
                if (this.down)
                {
                    this.colour.A += 3;
                }
                else
                {
                    this.colour.A -= 3;
                }
                if (mouse.LeftButton == ButtonState.Pressed && mouseRectangle.Intersects(this.rectangle))
                {
                    this.IsClicked = true;
                    this.shipTaken = true;
                }
            }
            else if (this.colour.A < 255)
            {
                this.colour.A += 3;
                this.IsClicked = false;
            }
        }

        public void setPosition(Vector2 newPosition)
        {
            this.position = newPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.rectangle, this.colour);
        }
    }
}