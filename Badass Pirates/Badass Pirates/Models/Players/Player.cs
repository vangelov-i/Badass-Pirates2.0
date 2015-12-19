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

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public abstract class Player : IPlayer, IGet
    {
        //private IPlayer currentPlayer;

        protected readonly Vector2 SpawnFirst = new Vector2(0, 20);

        // TODO Edit the image size
        protected readonly Vector2 SpawnSecond = new Vector2(1366 - 135, 768 - 150);

        protected Player(ShipType type)
        {
            this.InputManagerInstance = new InputManager();
            this.Ship = CreateShip.Create(type);
        }

        #region Properties
        public InputManager InputManagerInstance { get; set; }

        public IShip Ship { get; set; }

        public bool ItemColliding { get; set; }

        public PlayerTypes PlayerType { get; set; }

        public ShipType ShipType { get; set; }

        public Image ShipImage { get; set; }

        #endregion

        #region Methods

        public virtual void Initialise()
        {
            CombatManager.Initilialise(this);
            Boss.Instance.Initialise();
        }

        public void LoadContent()
        {
            this.ShipImage.LoadContent();
            BallControls.CannonBallLoadContent();
            CombatManager.LoadContent();
            Boss.Instance.LoadContent();
        }

        public void UnloadContent()
        {
            this.ShipImage.UnloadContent();
            BallControls.CannonBallUnloadContent();
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
            BallControls.CannonBallControls(this.PlayerType, gameTime);
            CombatManager.Update(gameTime, this.PlayerType, this);

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

            BallControls.CannonBallDraw(this.PlayerType, spriteBatch);
            CombatManager.Draw(spriteBatch);
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