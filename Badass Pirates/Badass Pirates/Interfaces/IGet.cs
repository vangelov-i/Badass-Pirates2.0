namespace Badass_Pirates.Interfaces
{
    using Badass_Pirates.EngineComponents.Objects;
    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Items;
    using Badass_Pirates.GameObjects.Items.BonusTypes;

    internal interface IGet
    {
        void GetPotion(PotionTypes potionType);

        void GetBonus(BonusType bonusType);
    }
}