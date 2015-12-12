﻿namespace Badass_Pirates.EngineComponents.Objects
{
    #region

    using Badass_Pirates.EngineComponents.Collisions;
    using Badass_Pirates.EngineComponents.Controls;
    using Badass_Pirates.EngineComponents.Fonts;
    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.Enums;
    using Badass_Pirates.Exceptions;
    using Badass_Pirates.Factory;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    #endregion

    public class Player : IGet
    {
        #region Fields

        private Image shipImage;

        private Font damageFont;

        private PlayerTypes playerType;

        private bool ballColliding;

        private int? firstPlayerHitCounter;

        private int? secondPlayerHitCounter;

        private Font hpFont;

        private Font shieldFont;

        private Font energyFont;

        private GameObjects.Players.Player firstPlayer;
                                           
        private GameObjects.Players.Player secondPlayer;


        #endregion

        #region Properties

        public GameObjects.Players.Player CurrentPlayer { get; set; }

        public bool Colliding { get; private set; }

        public PlayerTypes PlayerType
        {
            get
            {
                return this.playerType;
            }
        
        }

        #endregion

        #region Methods

        public void Initialise(ShipType type, PlayerTypes side)
        {
            this.energyFont = new Font(Color.Yellow, "Fonts", "big");
            this.hpFont = new Font(Color.Green, "Fonts", "big");
            this.shieldFont = new Font(Color.Black, "Fonts", "big");
            this.damageFont = new Font(Color.Red, "Fonts", "big");
            this.ballColliding = false;
            BallControls.CannonBallInitialise();
            switch (side)
            {
                case PlayerTypes.SecondPlayer:
                    switch (type)
                    {
                        case ShipType.Destroyer:
                            this.shipImage = new Image("ShipsContents/destroyerRight");
                            this.CurrentPlayer = CreatePlayer.Create(
                                PlayerTypes.SecondPlayer,
                                type,
                                "not implemented class Ships.Player");
                            this.playerType = PlayerTypes.SecondPlayer;
                            break;
                        case ShipType.Battleship:
                            this.shipImage = new Image("ShipsContents/battleshipRight");
                            this.CurrentPlayer = CreatePlayer.Create(
                                PlayerTypes.SecondPlayer,
                                type,
                                "not implemented class Ships.Player");
                            this.playerType = PlayerTypes.SecondPlayer;
                            break;
                        case ShipType.Cruiser:
                            this.shipImage = new Image("ShipsContents/cruiserRight");
                            this.CurrentPlayer = CreatePlayer.Create(
                                PlayerTypes.SecondPlayer,
                                type,
                                "not implemented class Ships.Player");
                            this.playerType = PlayerTypes.SecondPlayer;
                            break;
                    }

                    break;

                case PlayerTypes.FirstPlayer:
                    switch (type)
                    {
                        case ShipType.Destroyer:
                            this.shipImage = new Image("ShipsContents/destroyerLeft");
                            this.CurrentPlayer = CreatePlayer.Create(
                                PlayerTypes.FirstPlayer,
                                type,
                                "not implemented class Ships.Player");
                            this.playerType = PlayerTypes.FirstPlayer;
                            break;
                        case ShipType.Battleship:
                            this.shipImage = new Image("ShipsContents/battleshipLeft");
                            this.CurrentPlayer = CreatePlayer.Create(
                                PlayerTypes.FirstPlayer,
                                type,
                                "not implemented class Ships.Player");
                            this.playerType = PlayerTypes.FirstPlayer;
                            break;
                        case ShipType.Cruiser:
                            this.shipImage = new Image("ShipsContents/cruiserLeft");
                            this.CurrentPlayer = CreatePlayer.Create(
                                PlayerTypes.FirstPlayer,
                                type,
                                "not implemented class Ships.Player");
                            this.playerType = PlayerTypes.FirstPlayer;
                            break;
                    }

                    break;
            }
            
        }
        


        public void LoadContent()
        {
            this.shipImage.LoadContent();
            BallControls.CannonBallLoadContent();
            this.damageFont.LoadContent();
            this.energyFont.LoadContent();
            this.hpFont.LoadContent();
            this.shieldFont.LoadContent();
            this.firstPlayer = PlayersInfo.GetCurrentPlayer(PlayerTypes.FirstPlayer);
            this.secondPlayer = PlayersInfo.GetCurrentPlayer(PlayerTypes.SecondPlayer);
            this.firstPlayer.Ship.Specialty.LoadContent();
            this.secondPlayer.Ship.Specialty.LoadContent();
        }

        public void UnloadContent()
        {
            this.shipImage.UnloadContent();
            BallControls.CannonBallUnloadContent();
            this.energyFont.UnloadContent();
            this.hpFont.UnloadContent();
            this.shieldFont.UnloadContent();
            this.damageFont.UnloadContent();
            this.CurrentPlayer.Ship.Specialty.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            this.CurrentPlayer.Ship.Specialty.Update(gameTime, this.CurrentPlayer);
            
            if (this.CurrentPlayer.Ship.FreezTimeOut.Elapsed.Seconds > 5)
            {
                this.CurrentPlayer.Ship.DeFrost();
            }

            if (this.CurrentPlayer.Ship.BonusDamageTimeOut.Elapsed.Seconds > 10)
            {
                this.CurrentPlayer.Ship.UnBonusDamage();
            }

            if (this.CurrentPlayer.Ship.WindTimeOut.Elapsed.Seconds > 10)
            {
                this.CurrentPlayer.Ship.UnWind();
            }
            
            this.shipImage.Update(gameTime);
            this.CurrentPlayer.InputManagerInstance.RotateStates();
            PlayerControls.ControlsPlayer(this.playerType, gameTime, this.CurrentPlayer, this.shipImage);
            BallControls.CannonBallControls(this.playerType, this.CurrentPlayer, this.shipImage, gameTime);
            this.Colliding = ItemsCollision.Collide(this.CurrentPlayer.Ship);

            if (true) //BallControls.ballFirst == null
            {
                // KOGATO TEPAT PURVIQ
                this.ballColliding = BallCollision.Collide(
                    this.firstPlayer.Ship,
                    BallControls.ballSecond);
                if (this.ballColliding)
                {
                    this.firstPlayerHitCounter = 0;
                    this.secondPlayer.Ship.Attack(this.firstPlayer.Ship);
                }
                if (this.firstPlayer.Ship.Health <= 0)
                {
                    throw new OutOfHealthException();
                }
            }
            if (true) // BallControls.ballSecond == null
            {
                this.ballColliding = BallCollision.Collide(
                    this.secondPlayer.Ship,
                    BallControls.ballFirst);
                if (this.ballColliding)
                {
                    this.secondPlayerHitCounter = 0;
                    this.firstPlayer.Ship.Attack(this.secondPlayer.Ship);
                    if (this.secondPlayer.Ship.Health <= 0)
                    {
                        throw new OutOfHealthException();
                    }
                }
            }

            #region Items Collision

            if (this.Colliding)
            {
                if (ShuffleItems.typeBonus == 0)
                {
                    this.GetPotion(ShuffleItems.typePotion);
                }
                else if (ShuffleItems.typePotion == 0)
                {
                    this.GetBonus(ShuffleItems.typeBonus);
                }
            }

            #endregion

            // ALWAYS MUST BE THE LAST LINE
            this.CurrentPlayer.InputManagerInstance.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            #region Fonts
            this.hpFont.Draw(
                spriteBatch,
                new Vector2(this.CurrentPlayer.Ship.Position.X, this.CurrentPlayer.Ship.Position.Y - 20),
                this.CurrentPlayer.Ship.Health.ToString());
            this.energyFont.Draw(
                spriteBatch,
                new Vector2(this.CurrentPlayer.Ship.Position.X + 40, this.CurrentPlayer.Ship.Position.Y - 20),
                this.CurrentPlayer.Ship.Energy.ToString());
            this.shieldFont.Draw(
                spriteBatch,
                new Vector2(this.CurrentPlayer.Ship.Position.X + 70, this.CurrentPlayer.Ship.Position.Y - 20),
                this.CurrentPlayer.Ship.Shields.ToString());
            #endregion

            spriteBatch.Draw(this.shipImage.Texture, this.CurrentPlayer.Ship.Position);
            BallControls.CannonBallDraw(this.playerType, spriteBatch, this.CurrentPlayer, this.shipImage);

            if (this.firstPlayerHitCounter < 15 && this.firstPlayerHitCounter != null) // this.ballColliding && 
            {
                this.damageFont.Draw(
                    spriteBatch,
                    new Vector2(
                        this.firstPlayer.Ship.Position.X,
                        this.firstPlayer.Ship.Position.Y -40),
                    string.Format("-" + this.secondPlayer.Ship.Damage)); // moje i po elegantno :D
                this.firstPlayerHitCounter++;
            }
            if (this.secondPlayerHitCounter < 15 && this.secondPlayerHitCounter != null)
            {
                this.damageFont.Draw(
                    spriteBatch,
                    new Vector2(
                        this.secondPlayer.Ship.Position.X,
                        this.secondPlayer.Ship.Position.Y -40),
                    string.Format("-" + this.firstPlayer.Ship.Damage)); // moje i po elegantno :D
                this.secondPlayerHitCounter++;
            }

            // SPECIALTY DRAW
            //this.CurrentPlayer.Ship.Specialty.Draw(spriteBatch,new Vector2(this.CurrentPlayer.Ship.Position.X + 100, this.CurrentPlayer.Ship.Position.Y));
            this.firstPlayer.Ship.Specialty.Draw(spriteBatch, this.firstPlayer.Ship.Specialty.Position);
            this.secondPlayer.Ship.Specialty.Draw(spriteBatch, this.secondPlayer.Ship.Specialty.Position);

        }

        public void GetPotion(PotionTypes potionType)
        {
            CreatePotionEffect.ExtractEffect(this.CurrentPlayer.Ship, potionType);
        }

        public void GetBonus(BonusType bonusType)
        {
            CreateBonusTypeEffect.ExtractEffect(this.CurrentPlayer.Ship, bonusType);
        }

        #endregion
    }
}