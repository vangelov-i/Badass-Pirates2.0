using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badass_Pirates.EngineComponents.Objects.Specialties
{
    using Microsoft.Xna.Framework;

    public class DMine : Specialty
    {
        private const string PATH = "Specialties/seamineResized";

        private static readonly Point FRAMESIZE = new Point(64, 63);

        private const int DAMAGE = 45;


        public DMine()
            : base(PATH, FRAMESIZE, DAMAGE)
        {
        }

    }
}
