namespace Badass_Pirates.EngineComponents.Player
{
    #region
    
    using Badass_Pirates.EngineComponents.Screens;
    using Badass_Pirates.Factory;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    #endregion

    public class Player
    {
        private Vector2 shipPosition;

        private Image shipImage;

        private GameObjects.Players.Player currentPlayer;

        #region Methods
       
        public void Initialise(ShipType type, PlayerTypes side)
        {

            switch (side)
            {
                case PlayerTypes.SecondPlayer:
                    switch (type)
                    {
                        case ShipType.Destroyer:
                            this.shipImage = new Image("Ships/destroyerRight");
                            this.currentPlayer = CreatePlayer.Create(
                                PlayerTypes.SecondPlayer, 
                                type, 
                                "not implemented class Ships.Player");
                            this.shipPosition = this.currentPlayer.Ship.Position;
                            break;
                        case ShipType.Battleship:
                            this.shipImage = new Image("Ships/battleshipRight");
                            this.currentPlayer = CreatePlayer.Create(
                                PlayerTypes.SecondPlayer,
                                type,
                                "not implemented class Ships.Player");
                            this.currentPlayer = CreatePlayer.Create(
                                PlayerTypes.SecondPlayer,
                                type,
                                "not implemented class Ships.Player");
                            this.shipPosition = this.currentPlayer.Ship.Position;
                            break;
                        case ShipType.Cruiser:
                            this.shipImage = new Image("Ships/cruiserRight");
                            this.currentPlayer = CreatePlayer.Create(
                                PlayerTypes.SecondPlayer,
                                type,
                                "not implemented class Ships.Player");
                            this.shipPosition = this.currentPlayer.Ship.Position;
                            break;
                    }

                    break;

                case PlayerTypes.FirstPlayer:
                    switch (type)
                    {
                        case ShipType.Destroyer:
                            this.shipImage = new Image("Ships/destroyerLeft");
                            this.currentPlayer = CreatePlayer.Create(
                                PlayerTypes.FirstPlayer,
                                type,
                                "not implemented class Ships.Player");
                            this.shipPosition = this.currentPlayer.Ship.Position;
                            break;
                        case ShipType.Battleship:
                            this.shipImage = new Image("Ships/battleshipLeft");
                            this.currentPlayer = CreatePlayer.Create(
                                PlayerTypes.FirstPlayer,
                                type,
                                "not implemented class Ships.Player");
                            this.shipPosition = this.currentPlayer.Ship.Position;
                            break;
                        case ShipType.Cruiser:
                            this.shipImage = new Image("Ships/cruiserLeft");
                            this.currentPlayer = CreatePlayer.Create(
                                PlayerTypes.FirstPlayer,
                                type,
                                "not implemented class Ships.Player");
                            this.shipPosition = this.currentPlayer.Ship.Position;
                            break;
                    }

                    break;
            }
        }

        public void LoadContent()
        {
            this.shipImage.LoadContent();
        }

        public void UnloadContent()
        {
            this.shipImage.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            this.shipImage.Update(gameTime);
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Down))
            {
                this.shipPosition.Y += this.currentPlayer.Ship.Speed;
                this.ValidateShipPosition();
            }

            if (state.IsKeyDown(Keys.Up))
            {
                this.shipPosition.Y -= this.currentPlayer.Ship.Speed;
                this.ValidateShipPosition();
            }

            if (state.IsKeyDown(Keys.Right))
            {
                this.shipPosition.X += this.currentPlayer.Ship.Speed;
                this.ValidateShipPosition();
            }

            if (state.IsKeyDown(Keys.Left))
            {
                this.shipPosition.X -= this.currentPlayer.Ship.Speed;
                this.ValidateShipPosition();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.shipImage.Texture, this.shipPosition);
        }

        private void ValidateShipPosition()
        {
            if (this.shipPosition.X < 0)
            {
                this.shipPosition.X = 0;
            }

            if (this.shipPosition.Y < 0)
            {
                this.shipPosition.Y = 0;
            }

            if (this.shipPosition.Y > ScreenManager.Instance.Dimensions.Y - this.shipImage.Texture.Height)
            {
                this.shipPosition.Y = ScreenManager.Instance.Dimensions.Y - this.shipImage.Texture.Height;
            }

            if (this.shipPosition.X > ScreenManager.Instance.Dimensions.X - this.shipImage.Texture.Width)
            {
                this.shipPosition.X = ScreenManager.Instance.Dimensions.X - this.shipImage.Texture.Width;
            }
        }

        #endregion
    }
}