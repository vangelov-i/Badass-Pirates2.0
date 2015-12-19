namespace Badass_Pirates.Factory
{
    using System;

    using Badass_Pirates.Enums;
    using Badass_Pirates.Interfaces;

    public static class CreateBonusTypeEffect
    {
        public static void ExtractEffect(IShip targetShip, BonusType type)
        {
            switch (type)
            {
                case BonusType.Freeze:
                    targetShip.Freeze();
                    break;
                case BonusType.Damage:
                    targetShip.BonusDamage();
                    break;
                case BonusType.Wind:
                    targetShip.Wind();
                    break;
                case BonusType.Null:
                    break;
                //default:
                //    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
