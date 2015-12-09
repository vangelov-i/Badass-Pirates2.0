namespace Badass_Pirates.EngineComponents.Objects
{
    #region

    using System;
    using System.Diagnostics;

    using Badass_Pirates.EngineComponents.Collisions;
    using Badass_Pirates.EngineComponents.Controls;
    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.Enums;
    using Badass_Pirates.Factory;
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

        private Image shipImage;

        private PlayerTypes playerType;
        
        private bool colliding;

        #endregion

        //public Player (PlayerTypes type)
        //{
        //    switch (type)
        //    {
        //            case PlayerTypes.FirstPlayer:
        //    }
        //}
       
        #region Properties

        public GameObjects.Players.Player CurrentPlayer
        {
            get
            {
                return this.currentPlayer;
            }

            set
            {
                this.currentPlayer = value;
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
            BallControls.CannonBallInitialise();
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
                            this.playerType = PlayerTypes.SecondPlayer;
                            break;
                        case ShipType.Battleship:
                            this.shipImage = new Image("ShipsContents/battleshipRight");
                            this.currentPlayer = CreatePlayer.Create(
                                PlayerTypes.SecondPlayer, 
                                type, 
                                "not implemented class Ships.Player");
                            this.playerType = PlayerTypes.SecondPlayer;
                            break;
                        case ShipType.Cruiser:
                            this.shipImage = new Image("ShipsContents/cruiserRight");
                            this.currentPlayer = CreatePlayer.Create(
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
                            this.currentPlayer = CreatePlayer.Create(
                                PlayerTypes.FirstPlayer, 
                                type, 
                                "not implemented class Ships.Player");
                            this.playerType = PlayerTypes.FirstPlayer;
                            break;
                        case ShipType.Battleship:
                            this.shipImage = new Image("ShipsContents/battleshipLeft");
                            this.currentPlayer = CreatePlayer.Create(
                                PlayerTypes.FirstPlayer, 
                                type, 
                                "not implemented class Ships.Player");
                            this.playerType = PlayerTypes.FirstPlayer;
                            break;
                        case ShipType.Cruiser:
                            this.shipImage = new Image("ShipsContents/cruiserLeft");
                            this.currentPlayer = CreatePlayer.Create(
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
        }

        public void UnloadContent()
        {
            this.shipImage.UnloadContent();
            BallControls.CannonBallUnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            this.shipImage.Update(gameTime);
            this.currentPlayer.InputManagerInstance.RotateStates();
            PlayerControls.ControlsPlayer(this.playerType, gameTime,this.currentPlayer,this.shipImage);
            BallControls.CannonBallControls(this.playerType,this.currentPlayer,this.shipImage,gameTime);
            this.colliding = ItemsCollision.Collide(this.currentPlayer.Ship);

            if (this.colliding)
            {
                switch (ShuffleItems.typeBonus)
                {
                        default:
                        this.GetBonus(ShuffleItems.typeBonus);
                        break;
                }
                switch (ShuffleItems.typePotion)
                {
                        default:
                        this.GetPotion(ShuffleItems.typePotion);
                        break;
                }
                
            }
            // ALWAYS MUST BE THE LAST LINE
            this.currentPlayer.InputManagerInstance.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.shipImage.Texture, this.currentPlayer.Ship.Position);
            BallControls.CannonBallDraw(this.playerType,spriteBatch,this.currentPlayer,this.shipImage);
        }

        public void GetPotion(PotionTypes potionType)
        {
            CreatePotionEffect.ExtractEffect(this.currentPlayer.Ship, potionType);
        }

        public void GetBonus(BonusType bonusType)
        {
            CreateBonusTypeEffect.ExtractEffect(this.currentPlayer.Ship, bonusType);
        }
        #endregion
    }
}