namespace Badass_Pirates.Objects.Specialties
{
    using Badass_Pirates.Collisions;
    using Badass_Pirates.Enums;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Models.Players;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Mine : Specialty
    {
        #region Fields

        private const int DAMAGE = 45;

        private const string PATH = "Specialties/seamineResized";

        private static readonly Point frameSize = new Point(150, 150);
        
        private static Vector2 mineStartPos;

        private static int SPEED = 10;

        private static int flag;

        #endregion

        #region Constructor
        
        public Mine()
            : base(PATH, frameSize, DAMAGE)
        {
            flag = 0;
            this.SetPosition(CoordsDirections.Abscissa, 9000);
            this.SetPosition(CoordsDirections.Ordinate, 9000);
        }
        #endregion
        
        public override void Update(GameTime gameTime, IPlayer currentPlayer)
        {
            // ЛОГИКА ПРИ КОЛИЗИЯ НА МИНАТА
            // TODO NOT WORKING COLLISION
                if (currentPlayer != FirstPlayer.Instance)
                {
                    Collide = SpecialtyCollision.Collide(FirstPlayer.Instance.Ship, this);
                    if (Collide)
                    {
                        currentPlayer.Ship.SpecialtyAttack(FirstPlayer.Instance.Ship);
                        this.DoDraw = false;
                    }
                }
                else
                {
                    Collide = SpecialtyCollision.Collide(SecondPlayer.Instance.Ship, this);
                    if (Collide)
                    {
                        currentPlayer.Ship.SpecialtyAttack(SecondPlayer.Instance.Ship);
                        this.DoDraw = false;
                    }
                }
           
            
            // НАСТРОЙКА НА ПОЗИЦИЯТА ПРИ ПУСКАНЕ НА МИНАТА
            if (this.SpecialtyFired)
            {
                this.DoDraw = true;
                flag++; 
                if (flag == 1)
                {
                    mineStartPos = new Vector2(currentPlayer.Ship.Position.X - this.Image.Texture.Width, currentPlayer.Ship.Position.Y);
                    this.SetPosition(CoordsDirections.Abscissa, ScreenManager.Instance.Dimensions.X - this.Image.Texture.Width - currentPlayer.Ship.Position.X);
                    this.SetPosition(CoordsDirections.Ordinate, -30);
                }
            }
            if (this.Position.Y < mineStartPos.Y)
            {
                this.AddToPosition(Direction.Positive, CoordsDirections.Ordinate, SPEED);
            }
            else
            {
                this.SpecialtyFired = false;
                flag = 0;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            if (this.DoDraw)
            {
                this.Image.Draw(spriteBatch, pos);
            }
        }
    }
}
