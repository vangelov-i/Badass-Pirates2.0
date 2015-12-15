namespace Badass_Pirates.Objects.Specialties
{
    using System.Diagnostics;

    using Badass_Pirates.GameObjects.Players;

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

        public override void ActivateSpecialty(Player currentPlayer) // currentPlayer is the enemy 
        {
            // this Position might have bugs when applied to the FirstPlayer
            this.Position = new Vector2(currentPlayer.Ship.Position.X - this.Image.Texture.Width/2f, currentPlayer.Ship.Position.Y - this.Image.Texture.Height);
            this.SpecialtyFired = true;
            this.lightningTimer.Start();
        }

        public override void Update(GameTime gameTime, Player currentPlayer)
        {

            // NEEDS LOTS OF ELEGANCE
            if (currentPlayer is FirstPlayer)
            {
                this.Position = new Vector2(this.SecondPlayer.Ship.Position.X - this.Image.Texture.Width / 2f, this.SecondPlayer.Ship.Position.Y - this.Image.Texture.Height);
                if (this.lightningTimer.Elapsed.Seconds > LIGHTNING_TIME)
                {
                    currentPlayer.Ship.SpecialtyAttack(this.SecondPlayer.Ship);
                }
            }
            else
            {
                this.Position = new Vector2(this.FirstPlayer.Ship.Position.X - this.Image.Texture.Width/2f , this.FirstPlayer.Ship.Position.Y - this.Image.Texture.Height);
                if (this.lightningTimer.Elapsed.Seconds > LIGHTNING_TIME)
                {
                    currentPlayer.Ship.SpecialtyAttack(this.FirstPlayer.Ship);
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
