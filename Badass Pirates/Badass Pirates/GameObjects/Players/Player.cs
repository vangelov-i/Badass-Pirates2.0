namespace Badass_Pirates.GameObjects.Players
{
    #region

    using Badass_Pirates.Factory;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Managers;

    using Microsoft.Xna.Framework;

    #endregion

    public abstract class Player
    {
        protected readonly Vector2 SpawnFirst = Vector2.Zero;

        // TODO Edit the image size
        protected readonly Vector2 SpawnSecond = new Vector2(1366 - 135, 768 - 150);
        
        protected Player(ShipType type, string name)
        {
            this.Name = name;
            this.InputManagerInstance = new InputManager();
            this.Ship = CreateShip.Create(type);
        }

        public InputManager InputManagerInstance { get; private set; }

        public PlayerTypes TypeOfPlayer
        {
            get
            {
                if(this is FirstPlayer)
                {
                    return PlayerTypes.FirstPlayer;
                }
                else
                {
                    return PlayerTypes.SecondPlayer;
                }
            }

        }

        public string Name { get; set; }

        public Ship Ship { get; set; }
    }
}