namespace Badass_Pirates.EngineComponents.Objects.Specialties
{
    using Badass_Pirates.EngineComponents.Collisions;
    using Badass_Pirates.GameObjects.Players;

    using Microsoft.Xna.Framework;

    public class Hurricane : Specialty
    {
        private const string PATH = "Specialties/hurricaneResized";

        private static readonly Point FRAMESIZE = new Point(250, 250);

        private const int DAMAGE = 30;

        private const int HURRICANE_SPEED = 10;

        public Hurricane()
            : base(PATH, FRAMESIZE, DAMAGE)
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
