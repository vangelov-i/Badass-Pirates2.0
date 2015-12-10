namespace Badass_Pirates.Interfaces.Bonuses
{
    using System.Diagnostics;

    using Badass_Pirates.GameObjects.Ships;

    public interface IDamage
    {
        Stopwatch BonusDamageTimeOut { get; set; }

        void BonusDamage();

        void UnBonusDamage();
    }
}
