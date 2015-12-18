namespace Badass_Pirates.Objects.Specialties
{
    using System.Diagnostics;

    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Models.Players;

    using Microsoft.Xna.Framework;

    public class Lightning : Specialty
    {
        private const string PATH = "Specialties/lightingResized";

        private static readonly Point frameSize = new Point(250,245);

        private const int LIGHTNING_TIME = 3;

        private const int DAMAGE = 25;

        private readonly Stopwatch lightningTimer;
        
        public Lightning()
            : base(PATH, frameSize, DAMAGE)
        {
            this.lightningTimer = new Stopwatch();
        }

        public override void ActivateSpecialty(IPlayer currentPlayer) // currentPlayer is the enemy 
        {
            // this Position might have bugs when applied to the FirstPlayer
            this.Position = new Vector2(currentPlayer.Ship.Position.X - this.Image.Texture.Width/2f, currentPlayer.Ship.Position.Y - this.Image.Texture.Height);
            this.SpecialtyFired = true;
            this.lightningTimer.Start();
        }

        public override void Update(GameTime gameTime, IPlayer currentPlayer)
        {

            // NEEDS LOTS OF ELEGANCE
            if (currentPlayer is FirstPlayer)
            {
                this.Position = new Vector2(SecondPlayer.Instance.Ship.Position.X - this.Image.Texture.Width / 2f, SecondPlayer.Instance.Ship.Position.Y - this.Image.Texture.Height);
                if (this.lightningTimer.Elapsed.Seconds > LIGHTNING_TIME)
                {
                    currentPlayer.Ship.SpecialtyAttack(SecondPlayer.Instance.Ship);
                }
            }
            else
            {
                this.Position = new Vector2(FirstPlayer.Instance.Ship.Position.X - this.Image.Texture.Width/2f , FirstPlayer.Instance.Ship.Position.Y - this.Image.Texture.Height);
                if (this.lightningTimer.Elapsed.Seconds > LIGHTNING_TIME)
                {
                    currentPlayer.Ship.SpecialtyAttack(FirstPlayer.Instance.Ship);
                }
            }

            if (this.lightningTimer.Elapsed.Seconds > LIGHTNING_TIME)
            {
                this.SpecialtyFired = false;
                this.lightningTimer.Stop();
                this.lightningTimer.Reset();
            }
        }
    }
}
