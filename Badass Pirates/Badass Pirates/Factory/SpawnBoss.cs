namespace Badass_Pirates.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Badass_Pirates.GameObjects.Mobs.Boss;

    using Microsoft.Xna.Framework;

    public static class SpawnBoss
    {
        public static Boss Spawn()
        {
            return new Boss();
        }
    }
}
