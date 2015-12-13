namespace Badass_Pirates.Objects
{
    #region

    using Badass_Pirates.Collisions;
    using Badass_Pirates.Controls;
    using Badass_Pirates.Enums;
    using Badass_Pirates.Factory;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Managers;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public class Player : IGet
    {
        #region Fields

        #endregion

        #region Properties

        public GameObjects.Players.Player CurrentPlayer { get; set; }

        public bool itemColliding { get; private set; }

        public PlayerTypes PlayerType { get; private set; }

        public Image ShipImage { get; set; }

        public bool Sinked { get; set; }

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
                            this.ShipImage = new Image("ShipsContents/destroyerRight");
                            this.CurrentPlayer = CreatePlayer.Create(
                                PlayerTypes.SecondPlayer,
                                type,
                                "not implemented class Ships.Player");
                            this.PlayerType = PlayerTypes.SecondPlayer;
                            break;
                        case ShipType.Battleship:
                            this.ShipImage = new Image("ShipsContents/battleshipRight");
                            this.CurrentPlayer = CreatePlayer.Create(
                                PlayerTypes.SecondPlayer,
                                type,
                                "not implemented class Ships.Player");
                            this.PlayerType = PlayerTypes.SecondPlayer;
                            break;
                        case ShipType.Cruiser:
                            this.ShipImage = new Image("ShipsContents/cruiserRight");
                            this.CurrentPlayer = CreatePlayer.Create(
                                PlayerTypes.SecondPlayer,
                                type,
                                "not implemented class Ships.Player");
                            this.PlayerType = PlayerTypes.SecondPlayer;
                            break;
                    }

                    break;

                case PlayerTypes.FirstPlayer:
                    switch (type)
                    {
                        case ShipType.Destroyer:
                            this.ShipImage = new Image("ShipsContents/destroyerLeft");
                            this.CurrentPlayer = CreatePlayer.Create(
                                PlayerTypes.FirstPlayer,
                                type,
                                "not implemented class Ships.Player");
                            this.PlayerType = PlayerTypes.FirstPlayer;
                            break;
                        case ShipType.Battleship:
                            this.ShipImage = new Image("ShipsContents/battleshipLeft");
                            this.CurrentPlayer = CreatePlayer.Create(
                                PlayerTypes.FirstPlayer,
                                type,
                                "not implemented class Ships.Player");
                            this.PlayerType = PlayerTypes.FirstPlayer;
                            break;
                        case ShipType.Cruiser:
                            this.ShipImage = new Image("ShipsContents/cruiserLeft");
                            this.CurrentPlayer = CreatePlayer.Create(
                                PlayerTypes.FirstPlayer,
                                type,
                                "not implemented class Ships.Player");
                            this.PlayerType = PlayerTypes.FirstPlayer;
                            break;
                    }

                    break;
            }

            this.Sinked = false;
            CombatManager.Initilialise(this.CurrentPlayer);
        }

        public void LoadContent()
        {
            this.ShipImage.LoadContent();
            BallControls.CannonBallLoadContent();
            CombatManager.LoadContent();
        }

        public void UnloadContent()
        {
            this.ShipImage.UnloadContent();
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

            if (this.Sinked)
            {
                Player player;
                if (this.CurrentPlayer is FirstPlayer)
                {
                    player = PlayersInfo.GetCurrentPlayerAsObj(PlayerTypes.FirstPlayer);
                }
                else
                {
                    player = PlayersInfo.GetCurrentPlayerAsObj(PlayerTypes.SecondPlayer);
                }

                this.CurrentPlayer.Ship.Sink(player);
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

            this.ShipImage.Update(gameTime);
            this.CurrentPlayer.InputManagerInstance.RotateStates();

            PlayerControls.ControlsPlayer(this.PlayerType, this.CurrentPlayer, this.ShipImage);
            BallControls.CannonBallControls(this.PlayerType, this.CurrentPlayer, this.ShipImage, gameTime);
            this.itemColliding = ItemsCollision.Collide(this.CurrentPlayer.Ship);
            CombatManager.Update(gameTime, this.PlayerType, this.CurrentPlayer);

            // ALWAYS MUST BE THE LAST LINE
            this.CurrentPlayer.InputManagerInstance.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 textureOrigin = new Vector2(this.ShipImage.Texture.Width / 2f, this.ShipImage.Texture.Height / 2f);
            if (!this.Sinked)
            {
                spriteBatch.Draw(this.ShipImage.Texture, this.CurrentPlayer.Ship.Position);
            }
            else
            {
                spriteBatch.Draw(
                    this.ShipImage.Texture,
                    this.CurrentPlayer.Ship.Position,
                    null,
                    Color.DarkCyan,
                    0f,
                    textureOrigin,
                    1.0f,
                    SpriteEffects.FlipVertically,
                    0f);
                }

            BallControls.CannonBallDraw(this.PlayerType, spriteBatch, this.CurrentPlayer, this.ShipImage);
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