namespace Badass_Pirates.EngineComponents.Objects
{
    #region

    using System;

    using Badass_Pirates.EngineComponents.Collisions;
    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.Enums;
    using Badass_Pirates.Factory;
    using Badass_Pirates.GameObjects.Items.BonusTypes;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    #endregion

    public class Player : IGet
    {
        #region Fields
        private GameObjects.Players.Player currentPlayer;

        private CannonBall ball;

        private Image shipImage;

        private Vector2 ballFiredPos;

        private Vector2 ballRangeX;

        private bool ballInitialised;

        private bool ballFired;

        private int fireFlashCounter;

        private bool colliding;

        #endregion

        #region Properties

        public GameObjects.Players.Player CurrentPlayer
        {
            get
            {
                return this.currentPlayer;
            }
        }

        public bool Colliding
        {
            get
            {
                return this.colliding;
            }
        }

        #endregion

        #region Methods

        public void Initialise(ShipType type, PlayerTypes side)
        {
            this.ball = new CannonBall();

            switch (side)
            {
                case PlayerTypes.SecondPlayer:
                    switch (type)
                    {
                        case ShipType.Destroyer:
                            this.shipImage = new Image("ShipsContents/destroyerRight");
                            this.currentPlayer = CreatePlayer.Create(
                                PlayerTypes.SecondPlayer, 
                                type, 
                                "not implemented class Ships.Player");
                            break;
                        case ShipType.Battleship:
                            this.shipImage = new Image("ShipsContents/battleshipRight");
                            this.currentPlayer = CreatePlayer.Create(
                                PlayerTypes.SecondPlayer, 
                                type, 
                                "not implemented class Ships.Player");
                            this.currentPlayer = CreatePlayer.Create(
                                PlayerTypes.SecondPlayer, 
                                type, 
                                "not implemented class Ships.Player");
                            break;
                        case ShipType.Cruiser:
                            this.shipImage = new Image("ShipsContents/cruiserRight");
                            this.currentPlayer = CreatePlayer.Create(
                                PlayerTypes.SecondPlayer, 
                                type, 
                                "not implemented class Ships.Player");
                            break;
                    }

                    break;

                case PlayerTypes.FirstPlayer:
                    switch (type)
                    {
                        case ShipType.Destroyer:
                            this.shipImage = new Image("ShipsContents/destroyerLeft");
                            this.currentPlayer = CreatePlayer.Create(
                                PlayerTypes.FirstPlayer, 
                                type, 
                                "not implemented class Ships.Player");
                            break;
                        case ShipType.Battleship:
                            this.shipImage = new Image("ShipsContents/battleshipLeft");
                            this.currentPlayer = CreatePlayer.Create(
                                PlayerTypes.FirstPlayer, 
                                type, 
                                "not implemented class Ships.Player");
                            break;
                        case ShipType.Cruiser:
                            this.shipImage = new Image("ShipsContents/cruiserLeft");
                            this.currentPlayer = CreatePlayer.Create(
                                PlayerTypes.FirstPlayer, 
                                type, 
                                "not implemented class Ships.Player");
                            break;
                    }

                    break;
            }

            this.colliding = false;
        }

        public void LoadContent()
        {
            this.shipImage.LoadContent();
            this.ball.LoadContent();
        }

        public void UnloadContent()
        {
            this.shipImage.UnloadContent();
            this.ball.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            this.colliding = ItemsCollision.Collide(this.currentPlayer.Ship);

            this.shipImage.Update(gameTime);
            InputManager.Instance.RotateStates();
            if (InputManager.Instance.KeyDown(Keys.Down))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                this.currentPlayer.Ship.Move(
                    CoordsDirections.Ordinate, 
                    Direction.Positive, 
                    this.currentPlayer.Ship.Speed);
                this.ValidateShipPosition();
            }

            if (InputManager.Instance.KeyDown(Keys.Up))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                this.currentPlayer.Ship.Move(
                    CoordsDirections.Ordinate, 
                    Direction.Negative, 
                    this.currentPlayer.Ship.Speed);
                this.ValidateShipPosition();
            }

            if (InputManager.Instance.KeyDown(Keys.Right))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                this.currentPlayer.Ship.Move(
                    CoordsDirections.Abscissa, 
                    Direction.Positive, 
                    this.currentPlayer.Ship.Speed);
                this.ValidateShipPosition();
            }

            if (InputManager.Instance.KeyDown(Keys.Left))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                this.currentPlayer.Ship.Move(
                    CoordsDirections.Abscissa, 
                    Direction.Negative, 
                    this.currentPlayer.Ship.Speed);
                this.ValidateShipPosition();
            }

            if (InputManager.Instance.KeyDown(Keys.Space))
            {
                this.ballFired = true;
                if (this.ballFired)
                {
                    if (!this.ballInitialised)
                    {
                        this.fireFlashCounter = 0;
                        this.ball.Initialise(
                            this.ballFiredPos =
                            new Vector2(
                                this.currentPlayer.Ship.Position.X + this.shipImage.Texture.Width, 
                                this.currentPlayer.Ship.Position.Y + (this.shipImage.Texture.Height / 2f)));
                        this.ballInitialised = true;
                    }
                }
            }

            if (this.ballFired)
            {
                this.ball.Update(gameTime);
            }
            
            if (this.colliding)
            {
                switch (ShuffleItems.Type)
                {
                        case ItemTypes.Damage:
                        case ItemTypes.Freeze:
                        case ItemTypes.Speed:
                        case ItemTypes.Wind:
                        this.GetBonus((BonusType)Enum.Parse(typeof(ItemTypes), ShuffleItems.Type.ToString()));
                        break;
                        case ItemTypes.EnergyPotion:
                        case ItemTypes.HPPotion:
                        case ItemTypes.ShieldPotion:
                        this.GetPotion((PotionTypes)Enum.Parse(typeof(ItemTypes), ShuffleItems.Type.ToString()));
                        break;
                }

                this.colliding = false;
            }


            // ALWAYS MUST BE THE LAST LINE
            InputManager.Instance.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.ballFired && this.fireFlashCounter < 15)
            {
                this.ball.Fire.Draw(
                    spriteBatch, 
                    new Vector2(
                        this.currentPlayer.Ship.Position.X + this.shipImage.Texture.Width,
                        this.currentPlayer.Ship.Position.Y + (this.shipImage.Texture.Height / 2f)
                        - (this.ball.Fire.Texture.Height / 2f)));
                this.fireFlashCounter++;
            }

            spriteBatch.Draw(this.shipImage.Texture, this.currentPlayer.Ship.Position);
            if (this.ballFired)
            {
                this.ballRangeX.X = this.ballFiredPos.X + (ScreenManager.Instance.Dimensions.X / 2)
                                    - this.shipImage.Texture.Width;

                if (this.ball.Position.X < this.ballRangeX.X)
                {
                    this.ball.Draw(spriteBatch);
                }
                else
                {
                    this.ballInitialised = false;
                    this.ballFired = false;
                }
            }
        }

        public void GetPotion(PotionTypes potionType)
        {
            CreatePotionEffect.ExtractEffect(this.currentPlayer.Ship, potionType);
        }

        public void GetBonus(BonusType bonusType)
        {
            CreateBonusTypeEffect.ExtractEffect(this.currentPlayer.Ship, bonusType);
        }

        private void ValidateShipPosition()
        {
            if (this.currentPlayer.Ship.Position.X < 0)
            {
                this.currentPlayer.Ship.SetPosition(CoordsDirections.Abscissa, 0);
            }

            if (this.currentPlayer.Ship.Position.Y < 0)
            {
                /* setter - а на Vector2 е недостъпен.Изисква собствена имплементация,минаваща през полето ! ! !
                            Имплементирана е в абстрактния клас Ship,чрез метода : SetPosition() */
                this.currentPlayer.Ship.SetPosition(CoordsDirections.Ordinate, 0);
            }

            if (this.currentPlayer.Ship.Position.Y > ScreenManager.Instance.Dimensions.Y - this.shipImage.Texture.Height)
            {
                /* setter - а на Vector2 е недостъпен.Изисква собствена имплементация,минаваща през полето ! ! !
                            Имплементирана е в абстрактния клас Ship,чрез метода : SetPosition() */
                this.currentPlayer.Ship.SetPosition(
                    CoordsDirections.Ordinate, 
                    ScreenManager.Instance.Dimensions.Y - this.shipImage.Texture.Height);
            }

            if (this.currentPlayer.Ship.Position.X > ScreenManager.Instance.Dimensions.X - this.shipImage.Texture.Width)
            {
                /* setter - а на Vector2 е недостъпен.Изисква собствена имплементация,минаваща през полето ! ! !
                            Имплементирана е в абстрактния клас Ship,чрез метода : SetPosition() */
                this.currentPlayer.Ship.SetPosition(
                    CoordsDirections.Abscissa, 
                    ScreenManager.Instance.Dimensions.X - this.shipImage.Texture.Width);
            }
        }

        #endregion
    }
}