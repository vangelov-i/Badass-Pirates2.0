namespace Badass_Pirates.Controls
{
    using System;
    using System.Collections.Generic;

    using Badass_Pirates.Enums;
    using Badass_Pirates.Interfaces;

    using Microsoft.Xna.Framework.Input;

    //TODO needs some cleanup ; strings could be made of local variables
    public static class PlayerControls
    {
        private static bool firstControler;

        private static bool secondControler;

        static PlayerControls ()
        {
            firstControler = true;

            secondControler = true;
        }

        public static bool FirstControler
        {
            get
            {
                return firstControler;
            }
            set
            {
                firstControler = value;
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

        public static void ControlsPlayer(IKeysLibrary library, PlayerTypes type,IPlayer first, IPlayer second)
        { 
            switch (type)
            {
                case PlayerTypes.FirstPlayer:
                    if (firstControler)
                    {
                        PlayerControls.UpdatePlayer(library,type, first);
                    }
                    break;
                case PlayerTypes.SecondPlayer:
                    if (secondControler)
                    {
                        PlayerControls.UpdatePlayer(library,type, second);
                    }
                    break;
                //default:
                //    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private static void UpdatePlayer(IKeysLibrary library, PlayerTypes type, IPlayer player)
        {

            player.InputManagerInstance.RotateStates();

            #region Down Direction
            
            if (player.InputManagerInstance.KeyDown(library.GetKey(type,"Down")))
            {
                player.Ship.Move(CoordsDirections.Ordinate, Direction.Positive, player.Ship.Speed);
                if (type == PlayerTypes.FirstPlayer)
                {
                    PositionValidation.FirstShipValidation();
                }
                else
                {
                    PositionValidation.SecondShipValidation();
                }
               
            }
            
            #endregion

            #region Up Direction

            if (player.InputManagerInstance.KeyDown(library.GetKey(type, "Up")))
            {
                player.Ship.Move(CoordsDirections.Ordinate, Direction.Negative, player.Ship.Speed);
                if (type == PlayerTypes.FirstPlayer)
                {
                    PositionValidation.FirstShipValidation();
                }
                else
                {
                    PositionValidation.SecondShipValidation();
                }
            }

            #endregion

            #region Right  Direction
            if (player.InputManagerInstance.KeyDown(library.GetKey(type, "Right")))
            {
                player.Ship.Move(CoordsDirections.Abscissa, Direction.Positive, player.Ship.Speed);
                PositionValidation.FirstShipValidation();
                if (type == PlayerTypes.FirstPlayer)
                {
                    PositionValidation.FirstShipValidation();
                }
                else
                {
                    PositionValidation.SecondShipValidation();
                }
            }

            #endregion

            #region Left Direction
            if (player.InputManagerInstance.KeyDown(library.GetKey(type, "Left")))
            {
                player.Ship.Move(CoordsDirections.Abscissa, Direction.Negative, player.Ship.Speed);
                PositionValidation.FirstShipValidation();
                if (type == PlayerTypes.FirstPlayer)
                {
                    PositionValidation.FirstShipValidation();
                }
                else
                {
                    PositionValidation.SecondShipValidation();
                }
            }

            #endregion

            player.InputManagerInstance.Update();
        }
    }
}
