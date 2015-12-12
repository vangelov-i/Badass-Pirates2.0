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

        private Point FRAMESIZE;

        protected Vector2 position;

        private bool specialtyFired;

        private int damage;

        public bool draw;

        protected Player firstPlayer ;

        protected Player secondPlayer;

        protected Specialty(string path, Point framesize,int dmg)
        {
            this.image = new Image(path);
            this.FRAMESIZE = framesize;
            this.Damage = dmg;
            this.specialtyFired = false;
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

        public Point Framesize
        {
            get
            {
                return this.FRAMESIZE;
            }
            set
            {
                this.FRAMESIZE = value;
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
            this.firstPlayer = PlayersInfo.GetCurrentPlayer(PlayerTypes.FirstPlayer);
            this.secondPlayer = PlayersInfo.GetCurrentPlayer(PlayerTypes.SecondPlayer);
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
