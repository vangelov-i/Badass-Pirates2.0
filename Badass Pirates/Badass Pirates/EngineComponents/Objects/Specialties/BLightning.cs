using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badass_Pirates.EngineComponents.Objects.Specialties
{
    using Badass_Pirates.EngineComponents.Managers;

    using Microsoft.Xna.Framework;

    public class BLightning : Specialty
    {
        private const string PATH = "Specialties/lightningResized";

        private static readonly Point FRAMESIZE = new Point(250,245);

        private const int DAMAGE = 35;


        public BLightning()
            : base(PATH, FRAMESIZE, DAMAGE)
        {
        }
    }
}
