namespace Badass_Pirates.Objects.Specialties
{
    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Screens;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Specialty 
    {
        #region Fields

        private bool doDraw;

        private Image image;

        private Point frameSize;

        private Vector2 position;

        private bool specialtyFired;

        private int damage;

        private Player firstPlayer;

        private Player secondPlayer;

        private static bool collide;

        #endregion

        protected Specialty(string path, Point frameSize,int dmg)
        {
            this.image = new Image(path);
            this.frameSize = frameSize;
            this.Damage = dmg;
            this.specialtyFired = false;
            this.doDraw = false;
        }


        #region Properties

        public bool DoDraw
        {
            get
            {
                return this.doDraw;
            }
            set
            {
                this.doDraw = value;
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

        public Point FrameSize
        {
            get
            {
                return this.frameSize;
            }
            set
            {
                this.frameSize = value;
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

        public bool SpecialtyFired
        {
            get
            {
                return this.specialtyFired;
            }
            set
            {
                this.specialtyFired = value;
            }
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }
            set
            {
                this.damage = value;
            }
        }

        public Player FirstPlayer
        {
            get
            {
                return this.firstPlayer;
            }
            set
            {
                this.firstPlayer = value;
            }
        }

        public Player SecondPlayer
        {
            get
            {
                return this.secondPlayer;
            }
            set
            {
                this.secondPlayer = value;
            }
        }

        public static bool Collide
        {
            get
            {
                return collide;
            }
            set
            {
                collide = value;
            }
        }


        #endregion

        #region Methods

        public virtual void Initialise(Vector2 pos)
        {
            this.image.IsActive = true;
            this.position = pos;
        }

        public void LoadContent()
        {
            this.firstPlayer = PlayersInfo.GetCurrentPlayer(PlayerTypes.FirstPlayer);
            this.secondPlayer = PlayersInfo.GetCurrentPlayer(PlayerTypes.SecondPlayer);
            this.image.LoadContent();
        }

        public void UnloadContent()
        {
            this.image.UnloadContent();
        }

        public abstract void Update(GameTime gameTime, GameObjects.Players.Player currentPlayer);

        public virtual void Draw(SpriteBatch spriteBatch,Vector2 pos)
        {
            //TODO how much time to draw
            // TODO ADD SPECIALTYFIRED = FALSE;
            if (this.SpecialtyFired)
            {
                this.image.Draw(spriteBatch, pos);
            }
        }

        public virtual void ActivateSpecialty(Player currentPlayer)
        {
            if (currentPlayer is FirstPlayer)
            {
                TitleScreen.FirstPlayer.CurrentPlayer.Ship.Specialty.Initialise(TitleScreen.FirstPlayer.CurrentPlayer.Ship.Position);
            }
            else
            {
                TitleScreen.SecondPlayer.CurrentPlayer.Ship.Specialty.Initialise(TitleScreen.SecondPlayer.CurrentPlayer.Ship.Position);
            }

            this.specialtyFired = true;
        }

        protected void SetPosition(CoordsDirections direction,float val)
        {
            switch (direction)
                {
                    case CoordsDirections.Abscissa:
                        this.position.X = val;
                        break;
                    case CoordsDirections.Ordinate:
                        this.position.Y = val;
                        break;
                }
        }

        protected void AddToPosition(Direction plusOrMinus, CoordsDirections direction, float val)
        {
            switch (plusOrMinus)
            {
                case Direction.Positive:
                    switch (direction)
                    {
                        case CoordsDirections.Abscissa:
                            this.position.X += val;
                            break;
                        case CoordsDirections.Ordinate:
                            this.position.Y += val;
                            break;
                    }
                    break;
                case Direction.Negative:
                    switch (direction)
                    {
                        case CoordsDirections.Abscissa:
                            this.position.X -= val;
                            break;
                        case CoordsDirections.Ordinate:
                            this.position.Y -= val;
                            break;
                    }
                    break;
            }
        }
        #endregion

    }
}
