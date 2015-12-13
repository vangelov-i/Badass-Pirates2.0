namespace Badass_Pirates.Controls
{
    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.Managers;

    using Microsoft.Xna.Framework.Input;

    using Player = Badass_Pirates.GameObjects.Players.Player;

    public static class PlayerControls
    {
        public static bool control = true;

        public static void ControlsPlayer(PlayerTypes type, Player currentPlayer, Image shipImage)
        {
            if (control)
            {
                switch (type)
                {
                    case PlayerTypes.FirstPlayer:
                        PlayerControls.UpdateFirstPlayer(currentPlayer, shipImage);
                        break;
                    case PlayerTypes.SecondPlayer:
                        PlayerControls.UpdateSecondPlayer(currentPlayer, shipImage);
                        break;
                }
        }
    }

        private static void UpdateFirstPlayer(Player currentPlayer, Image shipImage)
        {
            currentPlayer.InputManagerInstance.RotateStates();

            #region Key S
            if (currentPlayer.InputManagerInstance.KeyDown(Keys.S))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Ordinate,
                    Direction.Positive,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer, shipImage);
            }
            #endregion
            #region Key W
            if (currentPlayer.InputManagerInstance.KeyDown(Keys.W))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Ordinate,
                    Direction.Negative,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer, shipImage);
            }
            #endregion
            #region Key D
            if (currentPlayer.InputManagerInstance.KeyDown(Keys.D))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Abscissa,
                    Direction.Positive,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer, shipImage);
            }
            #endregion
            #region Key A
            if (currentPlayer.InputManagerInstance.KeyDown(Keys.A))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Abscissa,
                    Direction.Negative,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer, shipImage);
            }
            #endregion
            
            currentPlayer.InputManagerInstance.Update();
        }

        private static void UpdateSecondPlayer(Player currentPlayer, Image shipImage)
        {
            currentPlayer.InputManagerInstance.RotateStates();

            #region Key Down
            if (currentPlayer.InputManagerInstance.KeyDown(Keys.Down))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Ordinate,
                    Direction.Positive,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer, shipImage);
            }
            #endregion
            #region Key Up
            if (currentPlayer.InputManagerInstance.KeyDown(Keys.Up))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Ordinate,
                    Direction.Negative,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer, shipImage);
            }
            #endregion
            #region Key Right
            if (currentPlayer.InputManagerInstance.KeyDown(Keys.Right))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Abscissa,
                    Direction.Positive,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer, shipImage);
            }
            #endregion
            #region Key Left
            if (currentPlayer.InputManagerInstance.KeyDown(Keys.Left))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Abscissa,
                    Direction.Negative,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer, shipImage);
            }
            #endregion

            currentPlayer.InputManagerInstance.Update();
        }

        private static void ValidateShipPosition(Player currentPlayer, Image shipImage)
        {
            if (currentPlayer is FirstPlayer)
            {
                if (currentPlayer.Ship.Position.X < 0)
                {
                    currentPlayer.Ship.SetPosition(CoordsDirections.Abscissa, 0);
                }

                if (currentPlayer.Ship.Position.X > ScreenManager.Instance.Dimensions.X / 2 - shipImage.Texture.Width * 1.5f)
                {
                    currentPlayer.Ship.SetPosition(
                        CoordsDirections.Abscissa,
                        ScreenManager.Instance.Dimensions.X / 2 - shipImage.Texture.Width * 1.5f);
                }
            }
            else
            {
                if (currentPlayer.Ship.Position.X > ScreenManager.Instance.Dimensions.X - shipImage.Texture.Width)
                {
                    currentPlayer.Ship.SetPosition(CoordsDirections.Abscissa, ScreenManager.Instance.Dimensions.X - shipImage.Texture.Width);
                }

                if (currentPlayer.Ship.Position.X < ScreenManager.Instance.Dimensions.X / 2 + shipImage.Texture.Width / 2f)
                {
                    currentPlayer.Ship.SetPosition(
                        CoordsDirections.Abscissa,
                        ScreenManager.Instance.Dimensions.X / 2 + shipImage.Texture.Width / 2f);
                }
            }

            if (currentPlayer.Ship.Position.Y < 0)
            {
                currentPlayer.Ship.SetPosition(CoordsDirections.Ordinate, 0);
            }

            if (currentPlayer.Ship.Position.Y > ScreenManager.Instance.Dimensions.Y - shipImage.Texture.Height)
            {
                currentPlayer.Ship.SetPosition(
                    CoordsDirections.Ordinate,
                    ScreenManager.Instance.Dimensions.Y - shipImage.Texture.Height);
            }

        }
    }
}
