namespace Badass_Pirates.Objects.Specialties
{
    using Badass_Pirates.Collisions;
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
                if (currentPlayer is FirstPlayer)
                {
                    collide = SpecialtyCollision.Collide(this.secondPlayer.Ship, this);
                    if (collide)
                    {
                        currentPlayer.Ship.SpecialtyAttack(this.secondPlayer.Ship);
                    }

                    this.position.X += HURRICANE_SPEED;
                }
                else
                {
                    collide = SpecialtyCollision.Collide(this.firstPlayer.Ship, this);
                    if (collide)
                    {
                        currentPlayer.Ship.SpecialtyAttack(this.firstPlayer.Ship);
                    }

                    this.position.X -= HURRICANE_SPEED;
                }
            }
        }
    }
}
