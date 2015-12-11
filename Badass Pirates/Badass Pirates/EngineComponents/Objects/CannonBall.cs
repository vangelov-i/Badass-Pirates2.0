namespace Badass_Pirates.EngineComponents.Objects
{
    #region

    using System.Runtime.CompilerServices;

    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.EngineComponents.Screens;
    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public class CannonBall : IPositionable
    {
        protected readonly Vector2 DefaultInitPos = new Vector2(900f, 900f);

        public static Point frameSize = new Point(42,42);

        protected bool ballFired;

        protected int fireFlashCounter;

        protected bool ballInitialised;

        protected Vector2 ballFiredPos;

        protected Vector2 ballRangeX;

        protected Image Ball;

        protected Vector2 position;

        protected float heightMax;

        protected bool flipper;

        protected int counter;

        public CannonBall()
        {
            //this.position.X = DefaultInitPos.X;
            //this.position.Y = DefaultInitPos.Y;
            this.position = this.DefaultInitPos;
            this.Ball = new Image("cannonball");
            this.Fire = new Image("firstFire");
        }

        public Vector2 BallFiredPos 
        { 
            get
            {
                return this.ballFiredPos;
            }

            set
            {
                this.ballFiredPos = value;
            }
        }

        public Image Fire { get; set; }
        
        public bool BallFired 
        { 
            get
            {
                return this.ballFired;
            }

            set
            {
                this.ballFired = value;
            }
        }   

        public int FireFlashCounter 
        { 
            get
            {
                return this.fireFlashCounter;
            }

            set
            {
                this.fireFlashCounter = value;
            }
        }

        public Vector2 Position //=> this.position;
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

        public bool BallInitialised
        {
            get
            {
                return this.ballInitialised;
            }
            set
            {
                this.ballInitialised = value;
            }
        }

        public virtual void Initialise(Vector2 pos,PlayerTypes type)
        {
            this.position = pos;
            this.heightMax = pos.Y - 50; // - 150
            this.counter = 0;
            this.flipper = false;
            switch (type)
            {
                case PlayerTypes.FirstPlayer:
                    this.Fire = new Image("firstFire");
                    this.LoadContent();
                    break;
                case PlayerTypes.SecondPlayer:
                    this.Fire = new Image("secondFire");
                    this.LoadContent();
                    break;
            }
        }

        public virtual void LoadContent()
        {
            this.Ball.LoadContent();
            this.Fire.LoadContent();
        }

        public virtual void UnloadContent()
        {
            this.Ball.UnloadContent();
            this.Fire.UnloadContent();
        }

        public virtual void UpdateFirst(GameTime gameTime)
        {
            this.position.X += 14;
            if (!this.flipper && this.position.Y > this.heightMax + 100)
            {
                this.position.Y -= 5;
            }
            else if (!this.flipper && this.position.Y > this.heightMax)
            {
                this.position.Y -= 2;
            }
            else if (!this.flipper)
            {
                this.flipper = true;
                this.position.Y += 2;
            }
            else if (this.counter < 8)
            {
                this.counter++;
            }
            else if (this.flipper && this.position.Y > this.heightMax + 100)
            {
                this.position.Y += 2;
            }
            else
            {
                this.position.Y += 5;
            }
        }

        public virtual void UpdateSecond(GameTime gameTime)
        {
            this.position.X -= 13;
            if (!this.flipper && this.position.Y > this.heightMax + 100)
            {
                this.position.Y -= 5; //-=10
            }
            else if (!this.flipper && this.position.Y > this.heightMax)
            {
                this.position.Y -= 2; // -= 4
            }
            else if (!this.flipper)
            {
                this.flipper = true;
                this.position.Y += 2; // +=4
            }
            else if (this.counter < 8)
            {
                this.counter++;
            }
            else if (this.flipper && this.position.Y > this.heightMax + 100)
            {
                this.position.Y += 2; // +=4
            }
            else
            {
                this.position.Y += 5; // += 10
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Ball.Texture, this.position);
        }
        
        public void SetPosition(CoordsDirections coordsDirections,float value)
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

        public void SetPositionRangeX(float value)
        {
            this.ballRangeX.X = value;
        }
    }
}