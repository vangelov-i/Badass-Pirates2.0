namespace Badass_Pirates.EngineComponents.Objects.Specialties
{
    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.EngineComponents.Screens;
    using Badass_Pirates.GameObjects.Players;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Specialty 
    {
        protected Image image;

        private Point frameSize;

        protected Vector2 position;

        private bool specialtyFired;

        private int damage;

        protected bool draw;

        protected Specialty(string path, Point frameSize,int dmg)
        {
            this.image = new Image(path);
            this.frameSize = frameSize;
            this.Damage = dmg;
            this.specialtyFired = false;
            /* добави тази булева във валидацията на draw-а тук ( && draw) 
            и я прави false във ъпдейта на DMine */
            this.draw = false;
        }

        #region Properties
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

        public virtual void Update(GameTime gameTime, GameObjects.Players.Player currentPlayer)
        {
        }

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
        #endregion

    }
}
