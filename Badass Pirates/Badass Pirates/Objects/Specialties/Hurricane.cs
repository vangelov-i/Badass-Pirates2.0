namespace Badass_Pirates.Objects.Specialties
{
    using Badass_Pirates.Collisions;
    using Badass_Pirates.Enums;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Models.Players;

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

        public override void Update(GameTime gameTime, IPlayer currentPlayer)
        {
            if (this.SpecialtyFired)
            {
                // TODO moje da se izvede v private method void Move() i Atack() primerno..
                // nqkak da se porazkachi Update() (ako ima vreme)
                if (currentPlayer is FirstPlayer)
                {
                    Collide = SpecialtyCollision.Collide(SecondPlayer.Instance.Ship, this);
                    if (Collide)
                    {
                        currentPlayer.Ship.SpecialtyAttack(SecondPlayer.Instance.Ship);
                    }

                    this.AddToPosition(Direction.Positive, CoordsDirections.Abscissa, HURRICANE_SPEED);
                }
                else
                {
                    Collide = SpecialtyCollision.Collide(FirstPlayer.Instance.Ship, this);
                    if (Collide)
                    {
                        currentPlayer.Ship.SpecialtyAttack(FirstPlayer.Instance.Ship);
                    }

                    this.AddToPosition(Direction.Negative, CoordsDirections.Abscissa, HURRICANE_SPEED);
                }
            }
        }
    }
}
