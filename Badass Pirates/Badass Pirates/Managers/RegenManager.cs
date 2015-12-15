namespace Badass_Pirates.Managers
{
    using System.Diagnostics;

    using Badass_Pirates.GameObjects.Players;

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

        public static void EnergyRegenUpdate(Player firstPlayer,Player secondPlayer)
        {
            if ((int)RegenManager.stopWatch.Elapsed.TotalSeconds == RegenManager.elapsedTimeValidation)
            {
                firstPlayer.Ship.Energy += regenValue;
                secondPlayer.Ship.Energy += regenValue;
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
