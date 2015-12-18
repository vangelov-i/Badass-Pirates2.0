namespace Badass_Pirates.Interfaces
{
    using Badass_Pirates.Enums;
    using Badass_Pirates.Managers;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IPlayer
    {
        InputManager InputManagerInstance { get; set; }

        IShip Ship { get; set; }

        bool ItemColliding { get; set; }

        PlayerTypes PlayerType { get; set; }

        Image ShipImage { get; set; }

        void Initialise();

        void LoadContent();

        void UnloadContent();

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);

        void GetPotion(PotionTypes potionType);

        void GetBonus(BonusType bonusType);
    }
}
