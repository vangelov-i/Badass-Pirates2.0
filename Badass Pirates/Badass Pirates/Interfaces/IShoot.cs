namespace Badass_Pirates.Interfaces
{
    #region

    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Players;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public interface IShoot : IPositionable
    {
        Point FrameSize { get; set; }

        bool MineFired { get; set; }
        
        bool MineInitialised { get; set; }

        Vector2 MineFiredPos { get; set; }

        Vector2 MineRangeX { get; set; }

        Vector2 PositionMine { get; set; }

        float HeightMax { get; set; }

        bool Flipper { get; set; }

        int Counter { get; set; }

        void Initialise(Vector2 pos, PlayerTypes type);

        void LoadContent();

        void UnloadContent();

        void UpdateFirst(GameTime gameTime);

        void UpdateSecond(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
        
        void SetPositionRangeX(float value);
    }
}