namespace Badass_Pirates.Objects.Specialties
{
    using Badass_Pirates.Collisions;
    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Players;

    using Microsoft.Xna.Framework;

    public class Hurricane : Specialty
    {
        private const string PATH = "Specialties/hurricaneResized";

        private static readonly Point frameSize = new Point(250, 250);

        private const int DAMAGE = 30;

        private const int HURRICANE_SPEED = 10;

        public Hurricane()
            : base(PATH, frameSize, DAMAGE)
        {
        }

        public override void Update(GameTime gameTime, Player currentPlayer)
        {
            if (this.SpecialtyFired)
            {
                // TODO moje da se izvede v private method void Move() i Atack() primerno..
                // nqkak da se porazkachi Update() (ako ima vreme)
                if (currentPlayer is FirstPlayer)
                {
                    Collide = SpecialtyCollision.Collide(this.SecondPlayer.Ship, this);
                    if (Collide)
                    {
                        currentPlayer.Ship.SpecialtyAttack(this.SecondPlayer.Ship);
                    }

                    this.AddToPosition(Direction.Positive, CoordsDirections.Abscissa, HURRICANE_SPEED);
                }
                else
                {
                    Collide = SpecialtyCollision.Collide(this.FirstPlayer.Ship, this);
                    if (Collide)
                    {
                        currentPlayer.Ship.SpecialtyAttack(this.FirstPlayer.Ship);
                    }

                    this.AddToPosition(Direction.Negative, CoordsDirections.Abscissa, HURRICANE_SPEED);
                }
            }
        }
    }
}
