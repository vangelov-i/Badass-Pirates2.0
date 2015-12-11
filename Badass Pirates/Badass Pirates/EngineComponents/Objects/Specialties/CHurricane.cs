using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badass_Pirates.EngineComponents.Objects.Specialties
{
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;

    using Microsoft.Xna.Framework;

    using Player = Badass_Pirates.EngineComponents.Objects.Player;

    public class CHurricane : Specialty
    {
        private const string PATH = "Specialties/hurricaneResized";

        private static readonly Point FRAMESIZE = new Point(250, 250);

        private const int DAMAGE = 30;

        public CHurricane()
            : base(PATH, FRAMESIZE, DAMAGE)
        {
        }

        public override void Update(GameTime gameTime, GameObjects.Players.Player currentPlayer)
        {
            if (this.SpecialtyFired)
            {
                if (currentPlayer is FirstPlayer)
                {
                    this.position.X += 5;
                }
                else
                {
                    this.position.X -= 5;
                }
            }
        }
    }
}
