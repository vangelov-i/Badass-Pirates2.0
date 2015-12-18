namespace Badass_Pirates.Objects.Specialties
{
    using Badass_Pirates.Enums;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Models.Players;
    using Badass_Pirates.Screens;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Specialty : ISpecialty
    {
        #region Fields

        private bool doDraw;

        private Image image;

        private Point frameSize;

        private Vector2 position;

        private bool specialtyFired;

        private int damage;

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
            this.image.LoadContent();
        }

        public void UnloadContent()
        {
            this.image.UnloadContent();
        }

        public abstract void Update(GameTime gameTime, IPlayer currentPlayer);

        public virtual void Draw(SpriteBatch spriteBatch,Vector2 pos)
        {
            //TODO how much time to draw
            // TODO ADD SPECIALTYFIRED = FALSE;
            if (this.SpecialtyFired)
            {
                this.image.Draw(spriteBatch, pos);
            }
        }

        public virtual void ActivateSpecialty(IPlayer currentPlayer)
        {
            if (currentPlayer is FirstPlayer)
            {
                FirstPlayer.Instance.Ship.Specialty.Initialise(FirstPlayer.Instance.Ship.Position);
            }
            else
            {
                SecondPlayer.Instance.Ship.Specialty.Initialise(SecondPlayer.Instance.Ship.Position);
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
