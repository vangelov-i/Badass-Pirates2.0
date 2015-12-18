namespace Badass_Pirates.Models.Players
{
    using System;
    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Screens;

    public class SecondPlayer : Player
    {
        private static IPlayer instance;

        private readonly ShipType typeShip;

        private SecondPlayer(ShipType type)
            : base(type)
        {
            this.Ship.Position = this.SpawnSecond;
            this.typeShip = type;
            this.PlayerType = PlayerTypes.SecondPlayer;
        }

        public static IPlayer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SecondPlayer(MenuScreen.SecondShip);
                }

                return instance;
            }
        }

        public override void Initialise()
        {
            base.Initialise();

            switch (this.typeShip)
            {
                case ShipType.Destroyer:
                    this.ShipImage = new Image("ShipsContents/destroyerRight");
                    break;
                case ShipType.Battleship:
                    this.ShipImage = new Image("ShipsContents/battleshipRight");
                    break;
                case ShipType.Cruiser:
                    this.ShipImage = new Image("ShipsContents/cruiserRight");
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Not correct !");
            }
        }

    }
}
