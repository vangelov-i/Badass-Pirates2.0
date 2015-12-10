﻿using Badass_Pirates.EngineComponents.Screens;

namespace Badass_Pirates.EngineComponents.Objects
{
    #region

    using System;
    using System.Diagnostics;

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
    using Microsoft.Xna.Framework.Input;

    #endregion

    public class Player : IGet
    {
        #region Fields
        private GameObjects.Players.Player currentPlayer;

        private Image shipImage;

        private Font currentFont;

        private PlayerTypes playerType;
        
        private bool colliding;

        private bool ballColliding;

        private int? firstPlayerHitCounter;

        private int? secondPlayerHitCounter;
        
        #endregion

       
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
            this.currentFont = new Font(Color.Red,"Fonts", "big");
            this.ballColliding = false;
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
            this.currentFont.LoadContent();
        }

        public void UnloadContent()
        {
            this.shipImage.UnloadContent();
            BallControls.CannonBallUnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            if (this.currentPlayer.Ship.FreezTimeOut.Elapsed.Seconds > 5)
            {
                this.currentPlayer.Ship.DeFrost();
            }

            if (this.currentPlayer.Ship.BonusDamageTimeOut.Elapsed.Seconds > 10)
            {
                this.currentPlayer.Ship.UnBonusDamage();
            }

            if (this.currentPlayer.Ship.WindTimeOut.Elapsed.Seconds > 10)
            {
                this.currentPlayer.Ship.UnWind();
            }

            this.shipImage.Update(gameTime);
            this.currentPlayer.InputManagerInstance.RotateStates();
            PlayerControls.ControlsPlayer(this.playerType, gameTime,this.currentPlayer,this.shipImage);
            BallControls.CannonBallControls(this.playerType,this.currentPlayer,this.shipImage,gameTime);
            this.colliding = ItemsCollision.Collide(this.currentPlayer.Ship);

            if (true)    //BallControls.ballFirst == null
            {
                // KOGATO TEPAT PURVIQ
                this.ballColliding = BallCollision.Collide(TitleScreen.FirstPlayer.CurrentPlayer.Ship, BallControls.ballSecond);
                if (this.ballColliding)
                {
                    this.firstPlayerHitCounter = 0;
                    TitleScreen.SecondPlayer.CurrentPlayer.Ship.Attack(TitleScreen.FirstPlayer.CurrentPlayer.Ship);

                }
                if (TitleScreen.FirstPlayer.CurrentPlayer.Ship.Health < 0)
                {
                    throw new OutOfHealthException();
                }
            }
            if (true)    // BallControls.ballSecond == null
            {
                this.ballColliding = BallCollision.Collide(TitleScreen.SecondPlayer.CurrentPlayer.Ship, BallControls.ballFirst);
                if (this.ballColliding)
                {
                    this.secondPlayerHitCounter = 0;
                    TitleScreen.FirstPlayer.CurrentPlayer.Ship.Attack(TitleScreen.SecondPlayer.CurrentPlayer.Ship);
                    if (TitleScreen.SecondPlayer.CurrentPlayer.Ship.Health < 0)
                    {
                        throw new OutOfHealthException();
                    }
                }
            }

            #region Items Collision
            if (this.colliding)
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
            this.currentPlayer.InputManagerInstance.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.shipImage.Texture, this.currentPlayer.Ship.Position);
            BallControls.CannonBallDraw(this.playerType,spriteBatch,this.currentPlayer,this.shipImage);
            if (this.firstPlayerHitCounter < 15 && this.firstPlayerHitCounter != null) // this.ballColliding && 
            {
                this.currentFont.Draw(spriteBatch,
                    new Vector2(TitleScreen.FirstPlayer.CurrentPlayer.Ship.Position.X + 120f, TitleScreen.FirstPlayer.CurrentPlayer.Ship.Position.Y),  
                    string.Format("-" + TitleScreen.SecondPlayer.CurrentPlayer.Ship.Damage)); // moje i po elegantno :D
                this.firstPlayerHitCounter++;
            }
            if (this.secondPlayerHitCounter < 15 && this.secondPlayerHitCounter != null)
            {
                this.currentFont.Draw(spriteBatch, 
                    TitleScreen.SecondPlayer.CurrentPlayer.Ship.Position, 
                    string.Format("-" + TitleScreen.FirstPlayer.CurrentPlayer.Ship.Damage)); // moje i po elegantno :D
                this.secondPlayerHitCounter++;
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
        #endregion
    }
}