namespace Badass_Pirates.EngineComponents.Managers
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using Badass_Pirates.EngineComponents.Objects;

    using Microsoft.Xna.Framework;

    using Player = Badass_Pirates.GameObjects.Players.Player;

    public static class RegenManager
    {
        private static int regenTimeSeconds = 2;

        private static double regenValue = 1 / 132.0;

        private static readonly Stopwatch stopWatch;

        private static int timeCounter;

        private static float timer;

        private static int previousSeconds = 0;

        static RegenManager()
        {
            stopWatch = new Stopwatch();
            //previousSeconds = 1;
        }

        public static void EnergyRegenUpdate(GameTime gameTime, Player firstPlayer,Player secondPlayer)
        {
            //if (gameTime.ElapsedGameTime.Seconds != RegenManager.previousSeconds)
            //{
            //    firstPlayer.Ship.Energy += regenValue;
            //    secondPlayer.Ship.Energy += regenValue;
            //    RegenManager.previousSeconds = gameTime.ElapsedGameTime.Seconds;
            //}

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeCounter += (int)timer;
            if (timer >= 1.0F)
            {
                timer = 0F;
            }

            if (Math.Abs(timeCounter % regenTimeSeconds) < 0.0000001)
            {
                stopWatch.Start();
            }

            if (stopWatch.Elapsed.Seconds % regenTimeSeconds == 0)
            {
                firstPlayer.Ship.Energy += (int)regenValue;
                secondPlayer.Ship.Energy += (int)regenValue;
            }
        }

        public static void ChangeRegenTime(int timeSeconds = 1)
        {
            RegenManager.regenTimeSeconds = timeSeconds;
        }

        public static void ChangeRegenValue(int value = 2)
        {
            RegenManager.regenValue = value;
        }

    }
}
