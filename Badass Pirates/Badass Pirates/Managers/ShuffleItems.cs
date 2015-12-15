namespace Badass_Pirates.Managers
{
    #region

    using System;

    using Badass_Pirates.Enums;

    #endregion

    // TODO ЧИСТИЧЪК И СПРЕТНАТ
    public static class ShuffleItems
    {
        private static BonusType typeBonus;

        private static PotionTypes typePotion;

        private static readonly Random random;

        static ShuffleItems()
        {
            random = new Random();
            typeBonus = 0;
            typePotion = 0;
        }

        public static BonusType TypeBonus
        {
            get
            {
                return typeBonus;
            }
            set
            {
                typeBonus = value;
            }
        }

        public static PotionTypes TypePotion
        {
            get
            {
                return typePotion;
            }
            set
            {
                typePotion = value;
            }
        }

        public static Image Shuffle()
        {
            switch (ReturnItem())
            {
                case ItemTypes.EnergyPotion:
                    typePotion = PotionTypes.Energy;
                    typeBonus = 0;
                    return new Image("PotionsContents/energyPotion");
                case ItemTypes.Damage:
                    typeBonus = BonusType.Damage;
                    typePotion = 0;
                    return new Image("BonusContents/boltBonus");
                case ItemTypes.Freeze:
                    typeBonus = BonusType.Freeze;
                    typePotion = 0;
                    return new Image("BonusContents/freezBonus");
                case ItemTypes.HPPotion:
                    typePotion = PotionTypes.Health;
                    typeBonus = 0;
                    return new Image("PotionsContents/hpPotion");
                case ItemTypes.ShieldPotion:
                    typePotion = PotionTypes.Shields;
                    typeBonus = 0;
                    return new Image("PotionsContents/shieldPotion");
                case ItemTypes.Wind:
                    typeBonus = BonusType.Wind;
                    typePotion = 0;
                    return new Image("BonusContents/windBonus");
                default:
                    // TODO NOT WORKING PROPERLY
                    throw new NotImplementedException("inccorect shuffle case !");
            }
        }

        private static ItemTypes ReturnItem()
        {
            var current = (ItemTypes)random.Next(1, 7);
            return current;
        }
    }
}