namespace Badass_Pirates.Models.Players
{
    using System;

    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Screens;

    public class FirstPlayer : Player
    {
        private FirstPlayer(ShipType type)
            : base(type)
        {
            this.Ship.Position = this.SpawnFirst;
            this.ShipType = type;
            //this.PlayerType = PlayerTypes.FirstPlayer;
        }

        private static IPlayer instance;

        public static IPlayer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FirstPlayer(MenuScreen.FirstShip);
                }

                return instance;
            }
        }

        public override void Initialise()
        {
            base.Initialise();

            switch (this.ShipType)
            {
                case ShipType.Destroyer:
                    this.ShipImage = new Image("ShipsContents/destroyerLeft");
                    break;
                case ShipType.Battleship:
                    this.ShipImage = new Image("ShipsContents/battleshipLeft");
                    break;
                case ShipType.Cruiser:
                    this.ShipImage = new Image("ShipsContents/cruiserLeft");
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Not correct !");
            }

        }
    }
}
