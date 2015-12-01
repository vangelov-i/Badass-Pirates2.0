using Badass_Pirates.GameObjects.Items.Types;
using Badass_Pirates.GameObjects.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badass_Pirates.Factory
{
    public static class CreateBonusTypeEffect
    {
        public static void ExtractEffect(Ship targetShip, BonusType type)
        {
            // TODO : % stats
            switch (type)
            {
                case BonusType.Wind:
                    targetShip.Speed -= (int)BonusType.Wind; // should get back speed to normal later...
                    break;
                case BonusType.Freeze:
                    targetShip.Speed = (int)BonusType.Freeze; // should get back speed to normal later...
                    break;
                     
            }
        }

    }
}
