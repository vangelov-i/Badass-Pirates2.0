namespace Badass_Pirates.EngineComponents.Objects.Specialties
{
    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Specialty : ISpecialty
    {
        private Image image;

        private Point frameSize;

        private Vector2 position;

        private bool specialtyFired;

        private int damage;

        private readonly Vector2 DefaultInitialPosition = new Vector2(9900f,9900f);

        protected Specialty(string path, Point frameSize,int dmg)
        {
            this.image = new Image(path);
            this.frameSize = frameSize;
            this.position = this.DefaultInitialPosition;
            this.Damage = dmg;
            this.specialtyFired = false;
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

        public void Initialise()
        {
            this.image.IsActive = true;
        }

        public void LoadContent()
        {
            this.image.LoadContent();
        }

        public void UnloadContent()
        {
            this.image.UnloadContent();
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch,Vector2 pos)
        {
            // TODO how much time to draw
            // TODO ADD SPECIALTYFIRED = FALSE;
            if (this.SpecialtyFired)
            {
                this.image.Draw(spriteBatch,  pos);
            }

        }

        public virtual void ActivateSpecialty(Ship targetShip)
        {
            // NEED TO BE CORRECTED - kogato shilds = 1 i se nanese damage, health-a shte e nezasegnat
            //if (targetShip.Shields > 0)
            //{
            //    targetShip.Shields -= this.Damage;
            //    if (targetShip.Shields < 0)
            //    {
            //        targetShip.Health -= targetShip.Shields;
            //        targetShip.Shields = 0;
            //    }
            //}
            //else
            //{
            //    targetShip.Health -= this.Damage;
            //}

            this.SpecialtyFired = true;
        }

        #endregion

    }
}
