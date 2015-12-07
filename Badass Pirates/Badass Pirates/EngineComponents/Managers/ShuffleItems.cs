namespace Badass_Pirates.EngineComponents.Managers
{
    #region

    using System;

    using Badass_Pirates.Enums;

    #endregion

    public static class ShuffleItems
    {
        public static ItemTypes type;

        public static ItemTypes Type { get { return type; } }

        public static Image Shuffle(Random random)
        {
            switch (ReturnItem(random))
            {
                case ItemTypes.EnergyPotion:
                    return new Image("PotionsContents/energyPotion");
                case ItemTypes.Damage:
                    return new Image("BonusContents/laser");
                case ItemTypes.Speed:
                    return new Image("BonusContents/penetration");
                case ItemTypes.Freeze:
                    return new Image("BonusContents/freezBonus");
                case ItemTypes.HPPotion:
                    return new Image("PotionsContents/hpPotion");
                case ItemTypes.ShieldPotion:
                    return new Image("PotionsContents/shieldPotion");
                case ItemTypes.Wind:
                    return new Image("BonusContents/windBonus");
                default:
                    throw new NotImplementedException("inccorect shuffle case !");
            }
        }

        private static ItemTypes ReturnItem(Random random)
        {
            var current = (ItemTypes)random.Next(1, 8);
            type = current;
            return current;
        }
    }
}