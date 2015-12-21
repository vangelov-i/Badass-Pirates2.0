namespace Badass_Pirates.Objects
{
    #region
    
    using System.Diagnostics;

    using Badass_Pirates.Enums;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Models.Players;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    // TODO LOCAL CONSTs
    public class CannonBall : IProjectile
    {
        private readonly Vector2 DefaultInitPos = new Vector2(900f, 900f);

        private static Point frameSize;

        private static bool ballControler;

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

        private const int defaultBallTimer = 2;

        private Stopwatch ballTimer = new Stopwatch();

        private PlayerTypes playerType;

        public CannonBall(Vector2 pos, PlayerTypes type)
        {
            this.Position = this.DefaultInitPos;
            this.Image = new Image("cannonball");
            this.Fire = new Image("firstFire");
            this.FrameSize = new Point(42, 42);
            this.BallControler = true;
            this.position = pos;
            this.heightMax = pos.Y - 50;
            this.counter = 0;
            this.flipper = false;
            this.playerType = type;
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

        public Stopwatch BallTimer
        {
            get
            {
                return this.ballTimer;
            }
            set
            {
                this.ballTimer = value;
            }
        }

        public static int DefaultBallTimer
        {
            get
            {
                return defaultBallTimer;
            }
        }

        public  bool BallControler
        {
            get
            {
                return ballControler;
            }
            set
            {
                ballControler = value;
            }
        }

        public Vector2 BallRangeX
        {
            get
            {
                return this.ballRangeX;
            }
            set
            {
                this.ballRangeX = value;
            }
        }

        public void Initialise()
        {
            switch (this.playerType)
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
        
        public void Update(GameTime gameTime)
        {
            switch (this.playerType)
            {
                case PlayerTypes.FirstPlayer:
                    this.position.X += 14;
                break;
                case PlayerTypes.SecondPlayer:
                    this.position.X -= 13;
                break;   
            }

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