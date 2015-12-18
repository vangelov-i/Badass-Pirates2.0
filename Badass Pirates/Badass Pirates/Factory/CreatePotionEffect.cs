namespace Badass_Pirates.Factory
{
    #region

    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Models.Ships;

    #endregion

    public static class CreatePotionEffect
    {
        public static void ExtractEffect(IShip targetShip, PotionTypes type)
        {
            // TODO : % stats
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
            }
        }
    }
}