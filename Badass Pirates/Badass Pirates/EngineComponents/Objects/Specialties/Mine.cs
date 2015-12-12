namespace Badass_Pirates.EngineComponents.Objects.Specialties
{
    using Badass_Pirates.EngineComponents.Collisions;
    using Badass_Pirates.GameObjects.Players;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Mine : Specialty
    {
        #region Fields

        private const int DAMAGE = 45;

        private const string PATH = "Specialties/seamineResized";

        private static readonly Point FRAMESIZE = new Point(150, 150);

        private static Vector2 mineStartPos;

        private static int flag;

        #endregion

        #region Constructor
        
        public Mine()
            : base(PATH, FRAMESIZE, DAMAGE)
        {
            flag = 0;
        }
        #endregion

        public static int Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        public override void Initialise(Vector2 pos)
        {
            this.position.X = ScreenManager.Instance.Dimensions.X - pos.X;
            this.position.Y = -30f;
        }

        public override void Update(GameTime gameTime, Player currentPlayer)
        {
            // Проверка за играча и колизия с мината
            if (currentPlayer != this.firstPlayer)
            {
                collide = SpecialtyCollision.Collide(this.firstPlayer.Ship, this);
                if (collide)
                {
                    currentPlayer.Ship.SpecialtyAttack(this.firstPlayer.Ship);
                    this.draw = false;
                }
            }
            else
            {
                collide = SpecialtyCollision.Collide(this.secondPlayer.Ship, this);
                if (collide)
                {
                    currentPlayer.Ship.SpecialtyAttack(this.secondPlayer.Ship);
                    this.draw = false;
                }
            }
            
            if (this.SpecialtyFired)
            {
                this.draw = true;
                flag++; 
                if (flag == 1)
                {
                    mineStartPos = new Vector2(currentPlayer.Ship.Position.X, currentPlayer.Ship.Position.Y);
                    this.position.X = ScreenManager.Instance.Dimensions.X - currentPlayer.Ship.Position.X;
                    this.position.Y = -30f;
                }
            }
            if (this.position.Y < mineStartPos.Y)
            {
                this.position.Y += 5;
            }
            else
            {
                this.SpecialtyFired = false;
                flag = 0;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            // TODO set timeout by energy points needed

            if (this.draw)
            {
                this.image.Draw(spriteBatch, pos);
            }
        }
    }
}
