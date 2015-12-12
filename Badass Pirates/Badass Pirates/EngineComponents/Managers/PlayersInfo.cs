namespace Badass_Pirates.EngineComponents.Managers
{
    using System;

    using Badass_Pirates.EngineComponents.Screens;
    using Badass_Pirates.GameObjects.Players;

    public static class PlayersInfo
    {
        public static GameObjects.Players.Player GetCurrentPlayer(PlayerTypes type)
        {
            switch (type)
            {
                    case PlayerTypes.FirstPlayer:
                    return TitleScreen.FirstPlayer.CurrentPlayer;
                    case PlayerTypes.SecondPlayer:
                    return TitleScreen.SecondPlayer.CurrentPlayer;
                default:
                    throw new NotImplementedException("no such player !");
            }
        }
    }
}
