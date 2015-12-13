namespace Badass_Pirates.Objects
{
    #region

    using Badass_Pirates.Collisions;
    using Badass_Pirates.Controls;
    using Badass_Pirates.Enums;
    using Badass_Pirates.Factory;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Handler;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Managers;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public class Player : IGet
    {
        #region Fields

        private Image shipImage;

        private PlayerTypes playerType;
       
        #endregion

        #region Properties

        public GameObjects.Players.Player CurrentPlayer { get; set; }

        public bool itemColliding { get; private set; }

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

            CombatManager.Initilialise(this.CurrentPlayer);

        }

        public void LoadContent()
        {
            this.shipImage.LoadContent();
            BallControls.CannonBallLoadContent();
            CombatManager.LoadContent();
        }

        public void UnloadContent()
        {
            this.shipImage.UnloadContent();
            BallControls.CannonBallUnloadContent();
            CombatManager.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            #region Items
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

            #region Items Collision

            if (this.itemColliding)
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

            #endregion

            this.shipImage.Update(gameTime);
            this.CurrentPlayer.InputManagerInstance.RotateStates();

            PlayerControls.ControlsPlayer(this.playerType, this.CurrentPlayer, this.shipImage);
            BallControls.CannonBallControls(this.playerType, this.CurrentPlayer, this.shipImage, gameTime);
            this.itemColliding = ItemsCollision.Collide(this.CurrentPlayer.Ship);
            CombatManager.Update(gameTime, this.playerType, this.CurrentPlayer);

            // ALWAYS MUST BE THE LAST LINE
            this.CurrentPlayer.InputManagerInstance.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.shipImage.Texture, this.CurrentPlayer.Ship.Position);
            BallControls.CannonBallDraw(this.playerType, spriteBatch, this.CurrentPlayer, this.shipImage);
            CombatManager.Draw(spriteBatch);
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