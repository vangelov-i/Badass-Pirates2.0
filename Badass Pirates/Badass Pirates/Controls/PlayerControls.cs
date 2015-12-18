namespace Badass_Pirates.Controls
{
    using System;

    using Badass_Pirates.Enums;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Models.Players;

    using Microsoft.Xna.Framework.Input;

    public static class PlayerControls
    {
        private static bool control;

        private static bool secondControler;

        static PlayerControls ()
        {
            control = true;

            secondControler = true;
        }

        public static bool Control
        {
            get
            {
                return control;
            }
            set
            {
                control = value;
            }
        }

        public static bool SecondControler
        {
            get
            {
                return secondControler;
            }
            set
            {
                secondControler = value;
            }
        }

        public static void ControlsPlayer(PlayerTypes type)
        {
            switch (type)
            {
                case PlayerTypes.FirstPlayer:
                    if (control)
                    {
                        PlayerControls.UpdateFirstPlayer();
                    }
                    break;
                case PlayerTypes.SecondPlayer:
                    if (secondControler)
                    {
                        PlayerControls.UpdateSecondPlayer();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private static void UpdateFirstPlayer()
        {
            FirstPlayer.Instance.InputManagerInstance.RotateStates();

            #region Key S

            if (FirstPlayer.Instance.InputManagerInstance.KeyDown(Keys.S))
            {
                FirstPlayer.Instance.Ship.Move(CoordsDirections.Ordinate, Direction.Positive, FirstPlayer.Instance.Ship.Speed);
                PlayerControls.ValidateShipPositionFirst();
            }

            #endregion

            #region Key W

            if (FirstPlayer.Instance.InputManagerInstance.KeyDown(Keys.W))
            {
                FirstPlayer.Instance.Ship.Move(CoordsDirections.Ordinate, Direction.Negative, FirstPlayer.Instance.Ship.Speed);
                PlayerControls.ValidateShipPositionFirst();
            }

            #endregion

            #region Key D

            if (FirstPlayer.Instance.InputManagerInstance.KeyDown(Keys.D))
            {
                FirstPlayer.Instance.Ship.Move(CoordsDirections.Abscissa, Direction.Positive, FirstPlayer.Instance.Ship.Speed);
                PlayerControls.ValidateShipPositionFirst();
            }

            #endregion

            #region Key A

            if (FirstPlayer.Instance.InputManagerInstance.KeyDown(Keys.A))
            {
                FirstPlayer.Instance.Ship.Move(CoordsDirections.Abscissa, Direction.Negative, FirstPlayer.Instance.Ship.Speed);
                PlayerControls.ValidateShipPositionFirst();
            }

            #endregion

            FirstPlayer.Instance.InputManagerInstance.Update();
        }

        private static void UpdateSecondPlayer()
        {
            SecondPlayer.Instance.InputManagerInstance.RotateStates();

            #region Key Down

            if (SecondPlayer.Instance.InputManagerInstance.KeyDown(Keys.Down))
            {
                SecondPlayer.Instance.Ship.Move(CoordsDirections.Ordinate, Direction.Positive, SecondPlayer.Instance.Ship.Speed);
                PlayerControls.ValidateShipPositionSecond();
            }

            #endregion

            #region Key Up

            if (SecondPlayer.Instance.InputManagerInstance.KeyDown(Keys.Up))
            {
                SecondPlayer.Instance.Ship.Move(CoordsDirections.Ordinate, Direction.Negative, SecondPlayer.Instance.Ship.Speed);
                PlayerControls.ValidateShipPositionSecond();
            }

            #endregion

            #region Key Right

            if (SecondPlayer.Instance.InputManagerInstance.KeyDown(Keys.Right))
            {
                SecondPlayer.Instance.Ship.Move(CoordsDirections.Abscissa, Direction.Positive, SecondPlayer.Instance.Ship.Speed);
                PlayerControls.ValidateShipPositionSecond();
            }

            #endregion

            #region Key Left

            if (SecondPlayer.Instance.InputManagerInstance.KeyDown(Keys.Left))
            {
                SecondPlayer.Instance.Ship.Move(CoordsDirections.Abscissa, Direction.Negative, SecondPlayer.Instance.Ship.Speed);
                PlayerControls.ValidateShipPositionSecond();
            }

            #endregion

            SecondPlayer.Instance.InputManagerInstance.Update();
        }

        //TODO Move validation in a single class
        private static void ValidateShipPositionFirst()
        {
            if (FirstPlayer.Instance.Ship.Position.X < 0)
            {
                FirstPlayer.Instance.Ship.SetPosition(CoordsDirections.Abscissa, 0);
            }

            if (FirstPlayer.Instance.Ship.Position.X > ScreenManager.Instance.Dimensions.X / 2 - FirstPlayer.Instance.ShipImage.Texture.Width * 1.5f)
            {
                FirstPlayer.Instance.Ship.SetPosition(CoordsDirections.Abscissa, ScreenManager.Instance.Dimensions.X / 2 - FirstPlayer.Instance.ShipImage.Texture.Width * 1.5f);
            }

            if (FirstPlayer.Instance.Ship.Position.Y < 0)
            {
                FirstPlayer.Instance.Ship.SetPosition(CoordsDirections.Ordinate, 0);
            }

            if (FirstPlayer.Instance.Ship.Position.Y > ScreenManager.Instance.Dimensions.Y - FirstPlayer.Instance.ShipImage.Texture.Height)
            {
                FirstPlayer.Instance.Ship.SetPosition(CoordsDirections.Ordinate, ScreenManager.Instance.Dimensions.Y - FirstPlayer.Instance.ShipImage.Texture.Height);
            }
        }

        private static void ValidateShipPositionSecond()
        {
            if (SecondPlayer.Instance.Ship.Position.X > ScreenManager.Instance.Dimensions.X - SecondPlayer.Instance.ShipImage.Texture.Width)
            {
                SecondPlayer.Instance.Ship.SetPosition(CoordsDirections.Abscissa, ScreenManager.Instance.Dimensions.X - SecondPlayer.Instance.ShipImage.Texture.Width);
            }

            if (SecondPlayer.Instance.Ship.Position.X < ScreenManager.Instance.Dimensions.X / 2 + SecondPlayer.Instance.ShipImage.Texture.Width / 2f)
            {
                SecondPlayer.Instance.Ship.SetPosition(CoordsDirections.Abscissa, ScreenManager.Instance.Dimensions.X / 2 + SecondPlayer.Instance.ShipImage.Texture.Width / 2f);
            }

            if (SecondPlayer.Instance.Ship.Position.Y < 0)
            {
                SecondPlayer.Instance.Ship.SetPosition(CoordsDirections.Ordinate, 0);
            }

            if (SecondPlayer.Instance.Ship.Position.Y > ScreenManager.Instance.Dimensions.Y - SecondPlayer.Instance.ShipImage.Texture.Height)
            {
                SecondPlayer.Instance.Ship.SetPosition(CoordsDirections.Ordinate, ScreenManager.Instance.Dimensions.Y - SecondPlayer.Instance.ShipImage.Texture.Height);
            }
        }
    }
}
