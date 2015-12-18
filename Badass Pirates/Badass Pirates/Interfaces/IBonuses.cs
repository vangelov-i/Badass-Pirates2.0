namespace Badass_Pirates.Interfaces
{
    using System.Diagnostics;
    
    public interface IBonuses
    {
        Stopwatch WindTimeOut { get; set; }

        void Wind();

        void UnWind();

        Stopwatch FreezTimeOut { get; set; }

        void Freeze();

        void DeFrost();

        Stopwatch BonusDamageTimeOut { get; set; }

        void BonusDamage();

        void UnBonusDamage();
    }
}
