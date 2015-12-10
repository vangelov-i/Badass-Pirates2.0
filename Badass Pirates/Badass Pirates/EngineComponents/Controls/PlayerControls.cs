namespace Badass_Pirates.EngineComponents.Controls
{
    using System.Linq.Expressions;

    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.EngineComponents.Objects;
    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Players;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using Player = Badass_Pirates.GameObjects.Players.Player;

    public class PlayerControls
    {
        public static void ControlsPlayer(PlayerTypes type,GameTime gameTime,Player currentPlayer,Image shipImage)
        {
            switch (type)
            {
                    case PlayerTypes.FirstPlayer:
                    PlayerControls.UpdateFirstPlayer(gameTime,currentPlayer,shipImage);
                    break;
                    case PlayerTypes.SecondPlayer:
                    PlayerControls.UpdateSecondPlayer(gameTime,currentPlayer,shipImage);
                    break;
            }
        }
        
        private static void UpdateFirstPlayer(GameTime gameTime, Player currentPlayer,Image shipImage)
        {
            currentPlayer.InputManagerInstance.RotateStates();
            if (currentPlayer.InputManagerInstance.KeyDown(Keys.S))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Ordinate,
                    Direction.Positive,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer,shipImage);
            }

            if (currentPlayer.InputManagerInstance.KeyDown(Keys.W))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Ordinate,
                    Direction.Negative,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer,shipImage);
            }

            if (currentPlayer.InputManagerInstance.KeyDown(Keys.D))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Abscissa,
                    Direction.Positive,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer,shipImage);
            }

            if (currentPlayer.InputManagerInstance.KeyDown(Keys.A))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Abscissa,
                    Direction.Negative,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer,shipImage);
            }

            currentPlayer.InputManagerInstance.Update();
        }

        private static void UpdateSecondPlayer(GameTime gameTime, Player currentPlayer, Image shipImage)
        {
            currentPlayer.InputManagerInstance.RotateStates();
            if (currentPlayer.InputManagerInstance.KeyDown(Keys.Down))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Ordinate,
                    Direction.Positive,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer, shipImage);
            }

            if (currentPlayer.InputManagerInstance.KeyDown(Keys.Up))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Ordinate,
                    Direction.Negative,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer, shipImage);
            }

            if (currentPlayer.InputManagerInstance.KeyDown(Keys.Right))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Abscissa,
                    Direction.Positive,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer, shipImage);
            }

            if (currentPlayer.InputManagerInstance.KeyDown(Keys.Left))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Abscissa,
                    Direction.Negative,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer, shipImage);
            }

            currentPlayer.InputManagerInstance.Update();
        }
        
        private static void ValidateShipPosition(Player currentPlayer,Image shipImage)
        {
            if (currentPlayer is FirstPlayer)
            {
                if (currentPlayer.Ship.Position.X < 0)
                {
                    currentPlayer.Ship.SetPosition(CoordsDirections.Abscissa, 0);
                }

                if (currentPlayer.Ship.Position.X > ScreenManager.Instance.Dimensions.X/2 - shipImage.Texture.Width*1.5f)
                {
                    /* setter - а на Vector2 е недостъпен.Изисква собствена имплементация,минаваща през полето ! ! !
                                Имплементирана е в абстрактния клас Ship,чрез метода : SetPosition() */
                    currentPlayer.Ship.SetPosition(
                        CoordsDirections.Abscissa,
                        ScreenManager.Instance.Dimensions.X/2 - shipImage.Texture.Width*1.5f);
                }
            }
            else
            {
                if (currentPlayer.Ship.Position.X > ScreenManager.Instance.Dimensions.X - shipImage.Texture.Width)
                {
                    currentPlayer.Ship.SetPosition(CoordsDirections.Abscissa, ScreenManager.Instance.Dimensions.X - shipImage.Texture.Width);
                }

                if (currentPlayer.Ship.Position.X < ScreenManager.Instance.Dimensions.X/2 + shipImage.Texture.Width/2f)
                {
                    /* setter - а на Vector2 е недостъпен.Изисква собствена имплементация,минаваща през полето ! ! !
                                Имплементирана е в абстрактния клас Ship,чрез метода : SetPosition() */
                    currentPlayer.Ship.SetPosition(
                        CoordsDirections.Abscissa,
                        ScreenManager.Instance.Dimensions.X/2 + shipImage.Texture.Width/2f);
                }
            }

            if (currentPlayer.Ship.Position.Y < 0)
            {
                /* setter - а на Vector2 е недостъпен.Изисква собствена имплементация,минаваща през полето ! ! !
                            Имплементирана е в абстрактния клас Ship,чрез метода : SetPosition() */
                currentPlayer.Ship.SetPosition(CoordsDirections.Ordinate, 0);
            }

            if (currentPlayer.Ship.Position.Y > ScreenManager.Instance.Dimensions.Y - shipImage.Texture.Height)
            {
                /* setter - а на Vector2 е недостъпен.Изисква собствена имплементация,минаваща през полето ! ! !
                            Имплементирана е в абстрактния клас Ship,чрез метода : SetPosition() */
                currentPlayer.Ship.SetPosition(
                    CoordsDirections.Ordinate,
                    ScreenManager.Instance.Dimensions.Y - shipImage.Texture.Height);
            }

        }
    }
}
