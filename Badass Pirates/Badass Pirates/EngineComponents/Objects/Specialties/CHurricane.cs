using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badass_Pirates.EngineComponents.Objects.Specialties
{
    using Microsoft.Xna.Framework;

    public class CHurricane : Specialty
    {
        private const string PATH = "Specialties/hurricaneResized";

        private static readonly Point FRAMESIZE = new Point(250, 250);

        private const int DAMAGE = 30;

        public CHurricane()
            : base(PATH, FRAMESIZE, DAMAGE)
        {
        }
    }
}
