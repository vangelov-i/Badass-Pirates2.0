namespace Badass_Pirates.Managers
{
    using Badass_Pirates.Fonts;
    using Badass_Pirates.Models.Mobs.Boss;
    using Badass_Pirates.Models.Players;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public static class FontsManager
    {
        private static Font hpFont;

        private static Font shieldFont;

        private static Font energyFont;

        public static void Initialise()
        {
            FontsManager.energyFont = new Font(Color.Yellow, "Fonts", "big");
            FontsManager.hpFont = new Font(Color.Red, "Fonts", "big");
            FontsManager.shieldFont = new Font(Color.Blue, "Fonts", "big");
        }

        public static void LoadContent()
        {

        }

        public static void UnloadContent()
        {
            FontsManager.energyFont.UnloadContent();
            FontsManager.hpFont.UnloadContent();
            FontsManager.shieldFont.UnloadContent();
        }

        public static void Update(GameTime gameTime)
        {
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            #region First Player

            FontsManager.hpFont.Draw(
                spriteBatch,
                new Vector2(FirstPlayer.Instance.Ship.Position.X, FirstPlayer.Instance.Ship.Position.Y - 20),
                FirstPlayer.Instance.Ship.Health.ToString());
            FontsManager.energyFont.Draw(
                spriteBatch,
                new Vector2(FirstPlayer.Instance.Ship.Position.X + 70, FirstPlayer.Instance.Ship.Position.Y - 20),
                FirstPlayer.Instance.Ship.Energy.ToString());
            FontsManager.shieldFont.Draw(
                spriteBatch,
                new Vector2(FirstPlayer.Instance.Ship.Position.X + 40, FirstPlayer.Instance.Ship.Position.Y - 20),
                FirstPlayer.Instance.Ship.Shields.ToString());

            #endregion

            #region Second Player

            FontsManager.hpFont.Draw(
                spriteBatch,
                new Vector2(SecondPlayer.Instance.Ship.Position.X, SecondPlayer.Instance.Ship.Position.Y - 20),
                SecondPlayer.Instance.Ship.Health.ToString());
            FontsManager.energyFont.Draw(
                spriteBatch,
                new Vector2(SecondPlayer.Instance.Ship.Position.X + 70, SecondPlayer.Instance.Ship.Position.Y - 20),
                SecondPlayer.Instance.Ship.Energy.ToString());
            FontsManager.shieldFont.Draw(
                spriteBatch,
                new Vector2(SecondPlayer.Instance.Ship.Position.X + 40, SecondPlayer.Instance.Ship.Position.Y - 20),
                SecondPlayer.Instance.Ship.Shields.ToString());

            #endregion

            #region Boss.Instance.

            FontsManager.hpFont.Draw(
                spriteBatch,
                new Vector2(Boss.Instance.Position.X + Boss.Instance.image.Texture.Width/2f - 25, Boss.Instance.Position.Y + 30),
                Boss.Instance.Health.ToString());

            #endregion
        }
    }
}
