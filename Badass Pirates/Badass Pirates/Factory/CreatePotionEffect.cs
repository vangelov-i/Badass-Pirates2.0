namespace Badass_Pirates.Factory
{
    #region

    using System;

    using Badass_Pirates.Enums;
    using Badass_Pirates.Interfaces;

    #endregion

    public static class CreatePotionEffect
    {
        public static void ExtractEffect(IShip targetShip, PotionTypes type)
        {
            switch (type)
            {
                case PotionTypes.Energy:
                    targetShip.Energy += (int)type;
                    break;
                case PotionTypes.Health:
                    targetShip.Health += (int)type;
                    break;
                case PotionTypes.Shields:
                    targetShip.Shields += (int)type;
                    break;
                case PotionTypes.Null:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}