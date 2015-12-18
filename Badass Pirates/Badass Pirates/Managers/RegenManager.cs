namespace Badass_Pirates.Managers
{
    using System.Diagnostics;

    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Models.Players;

    // TODO ЧИСТИЧЪК И СПРЕТНАТ
    public static class RegenManager
    {
        private static int regenTimeSeconds = 1;

        private static int regenValue = 2;

        private static readonly Stopwatch stopWatch;

        private static int elapsedTimeValidation = 1;

        static RegenManager()
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
        }

        public static void EnergyRegenUpdate()
        {
            if ((int)RegenManager.stopWatch.Elapsed.TotalSeconds == RegenManager.elapsedTimeValidation)
            {
                FirstPlayer.Instance.Ship.Energy += regenValue;
                SecondPlayer.Instance.Ship.Energy += regenValue;
                RegenManager.elapsedTimeValidation = (int)RegenManager.stopWatch.Elapsed.TotalSeconds + regenTimeSeconds;
            }
        }

        public static void ChangeRegenTime(int timeSeconds)
        {
            RegenManager.regenTimeSeconds = timeSeconds;
        }

        public static void ChangeRegenValue(int value)
        {
            RegenManager.regenValue = value;
        }

    }
}
