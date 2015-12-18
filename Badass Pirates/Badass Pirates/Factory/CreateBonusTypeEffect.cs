namespace Badass_Pirates.Factory
{
    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Models.Ships;

    public static class CreateBonusTypeEffect
    {
        public static void ExtractEffect(IShip targetShip, BonusType type)
        {
            // TODO : % stats
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
            }
        }
    }
}
