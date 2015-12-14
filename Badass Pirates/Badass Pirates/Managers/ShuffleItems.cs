﻿namespace Badass_Pirates.Managers
{
    #region

    using System;

    using Badass_Pirates.Enums;

    #endregion

    public static class ShuffleItems
    {
        public static BonusType typeBonus = 0;

        public static PotionTypes typePotion = 0;

        private static Random random;

        static ShuffleItems()
        {
            random = new Random();
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