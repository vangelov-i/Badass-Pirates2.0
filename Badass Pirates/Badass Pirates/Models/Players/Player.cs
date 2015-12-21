namespace Badass_Pirates.Models.Players
{
    #region

    using Badass_Pirates.Collisions;
    using Badass_Pirates.Controls;
    using Badass_Pirates.Enums;
    using Badass_Pirates.Factory;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Models.Mobs.Boss;
    using Badass_Pirates.Objects;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public abstract class Player : IPlayer, IGet
    {
        //private IPlayer currentPlayer;

        protected readonly Vector2 SpawnFirst = new Vector2(0, 20);

        // TODO Edit the image size
        protected readonly Vector2 SpawnSecond = new Vector2(1366 - 135, 768 - 150);

        private IProjectile ball;

        protected Player(ShipType type)
        {
            this.InputManagerInstance = new InputManager();
            this.Ship = CreateShip.Create(type);
            this.CombatManager = new CombatManager();
            this.CurrentPlayerBallControls = new BallControls(this);
            this.Ball = new CannonBall(Vector2.Zero, this.PlayerType);
        }

        #region Properties
        public InputManager InputManagerInstance { get; set; }

        public IShip Ship { get; set; }

        public CombatManager CombatManager { get; set; }

        private BallControls CurrentPlayerBallControls { get; set; }

        public bool ItemColliding { get; set; }

        public PlayerTypes PlayerType
        {
            get
            {
                if (this is FirstPlayer)
                {
                    return PlayerTypes.FirstPlayer;
                }

                return PlayerTypes.SecondPlayer;
            }

            
        }

        public ShipType ShipType { get; set; }

        public Image ShipImage { get; set; }

        public IProjectile Ball
        {
            get
            {
                return this.ball;
            }
            set
            {
                this.ball = value;
            }
        }

        #endregion

        #region Methods

        public virtual void Initialise()
        {
            this.CombatManager.Initilialise(this);
            Boss.Instance.Initialise();
            this.CurrentPlayerBallControls.Initialise(this.PlayerType);

        }

        public void LoadContent()
        {
            this.ShipImage.LoadContent();
            this.CurrentPlayerBallControls.LoadContent();
            this.CombatManager.LoadContent();
            Boss.Instance.LoadContent();
        }

        public void UnloadContent()
        {
            this.ShipImage.UnloadContent();
            this.CurrentPlayerBallControls.UnloadContent();
            CombatManager.UnloadContent();
            Boss.Instance.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            #region Items

            if (this.Ship.FreezTimeOut.Elapsed.Seconds > 5)
            {
                this.Ship.DeFrost();
            }

            if (this.Ship.BonusDamageTimeOut.Elapsed.Seconds > 10)
            {
                this.Ship.UnBonusDamage();
            }

            if (this.Ship.WindTimeOut.Elapsed.Seconds > 10)
            {
                this.Ship.UnWind();
            }

            if (this.Ship.Sunk)
            {
                this.Ship.Sink(this);
            }

            #region Items Collision

            if (this.ItemColliding)
            {
                if (ShuffleItems.TypeBonus == 0)
                {
                    this.GetPotion(ShuffleItems.TypePotion);
                }
                else if (ShuffleItems.TypePotion == 0)
                {
                    this.GetBonus(ShuffleItems.TypeBonus);
                }
            }

            #endregion

            #endregion

            this.InputManagerInstance.RotateStates();
            this.ItemColliding = ItemsCollision.Collide(this.Ship);
            PlayerControls.ControlsPlayer(ControlKeys.Instance, this.PlayerType,FirstPlayer.Instance,SecondPlayer.Instance);
            this.CurrentPlayerBallControls.Update(gameTime);
            this.CombatManager.Update(gameTime);

            // ALWAYS MUST BE THE LAST LINE
            this.InputManagerInstance.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 textureOrigin = new Vector2(this.ShipImage.Texture.Width / 2f, this.ShipImage.Texture.Height / 2f);
            if (!this.Ship.Sunk)
            {
                spriteBatch.Draw(this.ShipImage.Texture, this.Ship.Position);
            }
            else
            {
                spriteBatch.Draw(
                    this.ShipImage.Texture,
                    this.Ship.Position,
                    null,
                    Color.DarkCyan,
                    0f,
                    textureOrigin,
                    1.0f,
                    SpriteEffects.FlipVertically,
                    0f);
            }

            this.CurrentPlayerBallControls.Draw(spriteBatch);
            this.CombatManager.Draw(spriteBatch);
            Boss.Instance.Draw(spriteBatch);
        }

        public void GetPotion(PotionTypes potionType)
        {
            CreatePotionEffect.ExtractEffect(this.Ship, potionType);
        }

        public void GetBonus(BonusType bonusType)
        {
            CreateBonusTypeEffect.ExtractEffect(this.Ship, bonusType);
        }

        #endregion
    }
}