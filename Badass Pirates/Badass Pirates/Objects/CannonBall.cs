namespace Badass_Pirates.Objects
{
    #region

    using System.Media;

    using Badass_Pirates.Enums;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Managers;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;
    using System.Windows.Media;

    #endregion

    // TODO LOCAL CONSTs
    public class CannonBall : IProjectile
    {
        private readonly Vector2 DefaultInitPos = new Vector2(900f, 900f);

        private static Point frameSize;

        private bool ballFired;

        private int fireFlashCounter;

        private bool ballInitialised;

        private Vector2 ballFiredPos;

        private Vector2 ballRangeX;

        private Image image;

        private Vector2 position;

        private float heightMax;

        private bool flipper;

        private int counter;

        private MediaPlayer cannonEffect;

        private MediaPlayer impacEffect;

        public CannonBall()
        {
            this.position = this.DefaultInitPos;
            this.image = new Image("cannonball");
            this.Fire = new Image("firstFire");
            frameSize = new Point(42, 42);
            this.CannonEffect = new MediaPlayer();
            this.CannonEffect.Open(new System.Uri(@"C:\Users\Iliyan\Desktop\Dropbox\[Git] Badass Pirates2.0\Badass Pirates\Badass Pirates\Content\cannonSound.wav"));
            this.ImpacEffect = new MediaPlayer();
            this.impacEffect.Open(new System.Uri(@"C:\Users\Iliyan\Desktop\Dropbox\[Git] Badass Pirates2.0\Badass Pirates\Badass Pirates\Content\impactSound.wav"));
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

        public Vector2 Position 
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

        public Point FrameSize
        {
            get
            {
                return frameSize;
            }
            set
            {
                frameSize = value;
            }
        }

        public Image Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
            }
        }

        public MediaPlayer CannonEffect
        {
            get
            {
                return this.cannonEffect;
            }
            set
            {
                this.cannonEffect = value;
            }
        }

        public MediaPlayer ImpacEffect
        {
            get
            {
                return this.impacEffect;
            }
            set
            {
                this.impacEffect = value;
            }
        }

        public void Initialise(Vector2 pos,PlayerTypes type)
        {
            this.position = pos;
            this.heightMax = pos.Y - 50; 
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

        public void LoadContent()
        {
            this.image.LoadContent();
            this.Fire.LoadContent();
        }

        public void UnloadContent()
        {
            this.image.UnloadContent();
            this.Fire.UnloadContent();
        }

        public void UpdateFirst(GameTime gameTime)
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

        public void UpdateSecond(GameTime gameTime)
        {
            this.position.X -= 13;
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

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image.Texture, this.position);
        }

        public void SetPositionRangeX(float value)
        {
            this.ballRangeX.X = value;
        }
    }
}