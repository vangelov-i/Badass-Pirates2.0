namespace Badass_Pirates.Fonts
{
    using Badass_Pirates.GameObjects.Mobs.Boss;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.Managers;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public static class FontsManager
    {
        private static Font hpFont;

        private static Font shieldFont;

        private static Font energyFont;

        //private static Font gameOver;

        private static Player firstPlayer;

        private static Player secondPlayer;

        private static bool end;

        public static void Initialise()
        {
            FontsManager.energyFont = new Font(Color.Yellow, "Fonts", "big");
            FontsManager.hpFont = new Font(Color.Red, "Fonts", "big");
            FontsManager.shieldFont = new Font(Color.Blue, "Fonts", "big");
            //FontsManager.gameOver = new Font(Color.DarkRed, "Fonts", "big");
            FontsManager.end = false;
            firstPlayer = PlayersInfo.GetCurrentPlayerAsGameObj(PlayerTypes.FirstPlayer);
            secondPlayer = PlayersInfo.GetCurrentPlayerAsGameObj(PlayerTypes.SecondPlayer);
        }

        public static void LoadContent()
        {
            FontsManager.energyFont.LoadContent();
            FontsManager.hpFont.LoadContent();
            FontsManager.shieldFont.LoadContent();
            //FontsManager.gameOver.LoadContent();
        }

        public static void UnloadContent()
        {
            FontsManager.energyFont.UnloadContent();
            FontsManager.hpFont.UnloadContent();
            FontsManager.shieldFont.UnloadContent();
            //FontsManager.gameOver.UnloadContent();
        }

        public static void Update(GameTime gameTime,bool endDraw)
        {
            //FontsManager.end = endDraw;
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            #region First Player
            FontsManager.hpFont.Draw(
                spriteBatch,
                new Vector2(firstPlayer.Ship.Position.X, firstPlayer.Ship.Position.Y - 20),
                firstPlayer.Ship.Health.ToString());
            FontsManager.energyFont.Draw(
                spriteBatch,
                new Vector2(firstPlayer.Ship.Position.X + 70, firstPlayer.Ship.Position.Y - 20),
                firstPlayer.Ship.Energy.ToString());
            FontsManager.shieldFont.Draw(
                spriteBatch,
                new Vector2(firstPlayer.Ship.Position.X + 40, firstPlayer.Ship.Position.Y - 20),
                firstPlayer.Ship.Shields.ToString());
            #endregion

            #region Second Player

            FontsManager.hpFont.Draw(
                spriteBatch,
                new Vector2(secondPlayer.Ship.Position.X, secondPlayer.Ship.Position.Y - 20),
                secondPlayer.Ship.Health.ToString());
            FontsManager.energyFont.Draw(
                spriteBatch,
                new Vector2(secondPlayer.Ship.Position.X + 70, secondPlayer.Ship.Position.Y - 20),
                secondPlayer.Ship.Energy.ToString());
            FontsManager.shieldFont.Draw(
                spriteBatch,
                new Vector2(secondPlayer.Ship.Position.X + 40, secondPlayer.Ship.Position.Y - 20),
                secondPlayer.Ship.Shields.ToString());

            #endregion

            #region Boss
            FontsManager.hpFont.Draw(
                spriteBatch,
                new Vector2(Boss.Position.X + Boss.image.Texture.Width/2f - 25, Boss.Position.Y + 30),
                Boss.Health.ToString());
            #endregion

            #region GameOver

            //if (FontsManager.end)
            //{
            //    FontsManager.gameOver.Draw(
            //        spriteBatch,
            //        new Vector2(400, 140),
            //        $"SHIP {(firstPlayer.Ship.Health <= 0 ? " Second" : $" {(secondPlayer.Ship.Health <= 0 ? "First" : null)} VICTORY")}");
            //}

            #endregion

        }
    }
}
