namespace Badass_Pirates.EngineComponents.Objects
{
    #region

    using System.Runtime.CompilerServices;

    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.EngineComponents.Screens;
    using Badass_Pirates.Enums;
    using Badass_Pirates.Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public class CannonBall : IPositionable
    {
        private readonly Image Ball;

        private Vector2 position;

        private float heightMax;

        private bool flipper;

        private int counter;

        public CannonBall()
        {
            this.Ball = new Image("cannonball");
            this.Fire = new Image("smoke41");
        }
        public Image Fire { get; set; }

        public Vector2 Position => this.position;

        public void Initialise(Vector2 pos)
        {
            this.position = pos;
            this.heightMax = pos.Y - 150;
            this.counter = 0;
            this.flipper = false;
        }

        public void LoadContent()
        {
            this.Ball.LoadContent();
            this.Fire.LoadContent();
        }

        public void UnloadContent()
        {
            this.Ball.UnloadContent();
            this.Fire.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            this.position.X += 10;
            if (!this.flipper && this.position.Y > this.heightMax + 100)
            {
                this.position.Y -= 10;
            }
            else if (!this.flipper && this.position.Y > this.heightMax)
            {
                this.position.Y -= 4;
            }
            else if (!this.flipper)
            {
                this.flipper = true;
                this.position.Y += 4;
            }
            else if (this.counter < 8)
            {
                this.counter++;
            }
            else if (this.flipper && this.position.Y > this.heightMax + 100)
            {
                this.position.Y += 4;
            }
            else
            {
                this.position.Y += 10;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Ball.Texture, this.position);
        }
        
        public void SetPosition(CoordsDirections coordsDirections, float value)
        {
            switch (coordsDirections)
            {
                case CoordsDirections.Abscissa:
                    this.position.X = value;
                    break;
                case CoordsDirections.Ordinate:
                    this.position.Y = value;
                    break;
            }
        }
    }
}