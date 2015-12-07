namespace Badass_Pirates.EngineComponents.Objects
{
    #region

    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.Enums;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public class Item
    {
        #region Fields

        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore",
            Justification = "Reviewed. Suppression is OK here.")]
        private const int TIME_SHOWN = 4;

        private static Random random;

        private static Item instance;

        private static Image itemImage;

        private static Vector2 position;

        private static Stopwatch stopWatch;

        private static ItemTypes itemType;

        private static int timeInterval;

        private static bool draw;

        private static float screenHeight;

        private static float screenWidth;

        private static int timeCounter;

        private static float timer;

        #endregion

        #region Properties

        public static Vector2 Position //=> Item.position;
        {
            get
            {
                return Item.position;
            }
        }

        public static Item Instance // => instance ?? (instance = new Item());
        {
            get
            {
                if (instance == null)
                {
                    instance = new Item();
                }
                return instance;
            }
        }

        public static Point FrameSize = new Point(110, 70);

        #endregion

        private Item()
        {
            Item.draw = false;
            Item.position = new Vector2();
            Item.screenHeight = 0f;
            Item.screenWidth = 0f;
            Item.stopWatch = null;
            Item.timeCounter = 0;
            Item.timer = 0;
            Item.timeInterval = 0;
            Item.itemType = 0;
        }

        public static void Initialise(int intervalShown)
        {
            Item.draw = false;
            Item.timeInterval = intervalShown;
            Item.random = new Random();
            Item.screenHeight = ScreenManager.Instance.Dimensions.X;
            Item.screenWidth = ScreenManager.Instance.Dimensions.Y;
            Item.stopWatch = new Stopwatch();
            Item.itemImage = ShuffleItems.Shuffle(Item.random);
        }

        public static void LoadContent()
        {
            Item.itemImage.LoadContent();
        }

        public static void UnloadContent()
        {
            Item.itemImage.UnloadContent();
        }

        public static void Update(GameTime gameTime)
        {
            Item.timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            Item.timeCounter += (int)Item.timer;
            if (Item.timer >= 1.0F)
            {
                Item.timer = 0F;
            }

            if (Math.Abs(Item.timeCounter % TIME_SHOWN) < 0.0000001)
            {
                Item.stopWatch.Start();
                Item.draw = true;
            }

            if (Item.stopWatch.Elapsed.Seconds >= Item.timeInterval
                && Math.Abs(Item.timeCounter % TIME_SHOWN) > 0.0000001)
            {
                Item.stopWatch.Stop();
                Item.stopWatch.Reset();
                Item.SetRandoms();
                itemImage = ShuffleItems.Shuffle(random);
                itemImage.LoadContent();
                Item.draw = false;
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if (Item.draw && Item.stopWatch.Elapsed.Seconds <= TIME_SHOWN)
            {
                spriteBatch.Draw(Item.itemImage.Texture, Item.position);
            }
        }

        private static void SetRandoms()
        {
            Item.position = new Vector2(
                random.Next(0, (int)Item.screenWidth - Item.itemImage.Texture.Width),
                random.Next(0, (int)Item.screenHeight - Item.itemImage.Texture.Height));
        }
    }
}