namespace Badass_Pirates.Interfaces
{
    using Badass_Pirates.EngineComponents.Objects;
    using Badass_Pirates.Enums;

    internal interface IGet
    {
        void GetPotion(PotionTypes potionType);

        void GetBonus(BonusType bonusType);
    }
}