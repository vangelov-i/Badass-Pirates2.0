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

    public struct Player
    {
        private GameObjects.Players.Player currentPlayer;

        private Image shipImage;

        private Vector2 shipPosition;

        private bool ballInitialised;

        private bool ballFired;

        #region Methods

        public void Initialise(ShipType type, PlayerTypes side)
        {
            //CannonBall.posCannon = shipPosition
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
            CannonBall.LoadContent();
        }

        public void UnloadContent()
        {
            this.shipImage.UnloadContent();
            CannonBall.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            this.shipImage.Update(gameTime); // ne, ne, shte t
            InputManager.Instance.RotateStates();
            if (InputManager.Instance.KeyDown(Keys.Down))
            {
                this.shipPosition.Y += this.currentPlayer.Ship.Speed;
                this.ValidateShipPosition();
            }

            if (InputManager.Instance.KeyDown(Keys.Up))
            {
                this.shipPosition.Y -= this.currentPlayer.Ship.Speed;
                this.ValidateShipPosition();
            }

            if (InputManager.Instance.KeyDown(Keys.Right))
            {
                this.shipPosition.X += this.currentPlayer.Ship.Speed;
                this.ValidateShipPosition();
            }

            if (InputManager.Instance.KeyDown(Keys.Left))
            {
                this.shipPosition.X -= this.currentPlayer.Ship.Speed;
                this.ValidateShipPosition();
            }

            if (InputManager.Instance.KeyDown(Keys.Space))
            {
                this.ballFired = true;
                if (this.ballFired)
                {
                    if (!this.ballInitialised)
                    {
                        CannonBall.Initialise();
                        this.ballInitialised = true;
                    }
                }
            }

            if (this.ballFired)
            {
                CannonBall.Update(gameTime);
            }

            // ALWAYS MUST BE THE LAST LINE
            InputManager.Instance.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.shipImage.Texture, this.shipPosition);
            if (this.ballFired)
            {
                if (CannonBall.posCannon.X < ScreenManager.Instance.Dimensions.X)
                {
                    CannonBall.Draw(spriteBatch);
                }
                else
                {
                    this.ballInitialised = false;
                    this.ballFired = false;
                }
            }
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