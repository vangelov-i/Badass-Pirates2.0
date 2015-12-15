namespace Badass_Pirates.Managers
{
    using System;

    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.Objects;
    using Badass_Pirates.Screens;

    // TODO ЧИСТИЧЪК И СПРЕТНАТ
    public static class PlayersInfo
    {
        public static Player GetCurrentPlayer(PlayerTypes type)
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

        public static VirtualPlayer GetCurrentVirtualPlayer(PlayerTypes type)
        {
            switch (type)
            {
                case PlayerTypes.FirstPlayer:
                    return TitleScreen.FirstPlayer;
                case PlayerTypes.SecondPlayer:
                    return TitleScreen.SecondPlayer;
                default:
                    throw new NotImplementedException("no such player !");
            }
        }
    }
}



