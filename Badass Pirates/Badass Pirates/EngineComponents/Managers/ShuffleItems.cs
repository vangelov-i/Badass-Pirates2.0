namespace Badass_Pirates.EngineComponents.Managers
{
    #region

    using System;

    using Badass_Pirates.Enums;

    #endregion

    public static class ShuffleItems
    {
        public static BonusType typeBonus;

        public static PotionTypes typePotion;

        public static Image Shuffle(Random random)
        {
            switch (ReturnItem(random))
            {
                case ItemTypes.EnergyPotion:
                    typePotion = PotionTypes.Energy;
                    return new Image("PotionsContents/energyPotion");
                case ItemTypes.Damage:
                    typeBonus = BonusType.Damage;
                    return new Image("BonusContents/laser");
                case ItemTypes.Speed:
                    typeBonus = BonusType.Speed;
                    return new Image("BonusContents/penetration");
                case ItemTypes.Freeze:
                    typeBonus = BonusType.Freeze;
                    return new Image("BonusContents/freezBonus");
                case ItemTypes.HPPotion:
                    typePotion = PotionTypes.Health;
                    return new Image("PotionsContents/hpPotion");
                case ItemTypes.ShieldPotion:
                    typePotion = PotionTypes.Shields;
                    return new Image("PotionsContents/shieldPotion");
                case ItemTypes.Wind:
                    typeBonus = BonusType.Wind;
                    return new Image("BonusContents/windBonus");
                default:
                    throw new NotImplementedException("inccorect shuffle case !");
            }
        }

        private static ItemTypes ReturnItem(Random random)
        {
            var current = (ItemTypes)random.Next(1, 8);
            return current;
        }
    }
}