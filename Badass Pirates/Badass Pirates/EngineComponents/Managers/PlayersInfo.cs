namespace Badass_Pirates.EngineComponents.Managers
{
    using System;

    using Badass_Pirates.EngineComponents.Screens;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;

    using Player = Badass_Pirates.EngineComponents.Objects.Player;

    public static class PlayersInfo
    {
        private static readonly GameObjects.Players.Player firstPlayer = TitleScreen.FirstPlayer.CurrentPlayer;

        private static readonly GameObjects.Players.Player secondPlayer = TitleScreen.SecondPlayer.CurrentPlayer;

        public static GameObjects.Players.Player GetCurrentPlayer(PlayerTypes type)
        {
            switch (type)
            {
                    case PlayerTypes.FirstPlayer:
                    return PlayersInfo.firstPlayer;
                    case PlayerTypes.SecondPlayer:
                    return PlayersInfo.secondPlayer;
                default:
                    throw new NotImplementedException("no such player !");
            }
        }
    }
}
