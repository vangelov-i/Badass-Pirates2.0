namespace Badass_Pirates.EngineComponents.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    using Badass_Pirates.EngineComponents.Managers;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public struct Bonus
    {
        private static Image bonusImage;

        private static Vector2 position;

        private static float randPosX;

        private static float randPosY;

        private static Stopwatch globalTimer;

        private static float screenHeight;

        private static float screenWidth;

        private static Random random;

        private static bool draw;

        static Bonus()
        {
            Bonus.bonusImage = new Image("BonusItems/imag2");
        }
        
        public static void Initialise()
        {
            Bonus.draw = false;
            Bonus.random = new Random();
            Bonus.screenHeight = ScreenManager.Instance.Dimensions.X;
            Bonus.screenWidth = ScreenManager.Instance.Dimensions.Y;
            Bonus.globalTimer = new Stopwatch();
        }

        public static void LoadContent()
        {
            Bonus.bonusImage.LoadContent();
        }

        public static void UnloadContent()
        {
            Bonus.bonusImage.UnloadContent();
        }

        public static void Update(GameTime gameTime)
        {
            Bonus.GetRandoms();

        }

        public static void Draw(SpriteBatch spriteBatch)
        {
        }

        private static void GetRandoms()
        {
            Bonus.randPosX = Bonus.random.Next(0, (int)Bonus.screenWidth - Bonus.bonusImage.Texture.Width);
            Bonus.randPosY = Bonus.random.Next(0, (int)Bonus.screenHeight - Bonus.bonusImage.Texture.Height);
        }
    }
}
