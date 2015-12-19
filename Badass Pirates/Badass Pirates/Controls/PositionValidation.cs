using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badass_Pirates.Controls
{
    using Badass_Pirates.Enums;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Models.Players;

    public static class PositionValidation
    {
        public static void FirstShipValidation()
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

        public static void SecondShipValidation()
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
