namespace Badass_Pirates.Controls
{
    #region

    using System.Diagnostics;

    using Badass_Pirates.Enums;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Models.Players;
    using Badass_Pirates.Objects;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    #endregion

    public static class BallControls
    {
        //TODO Ball should not have methods draw,load etc.
        private const int DefaultBallTimer = 2;

        private static CannonBall ballFirst;

        private static CannonBall ballSecond;

        private static bool firstController;

        private static bool secondController;

        private static readonly Stopwatch firstBallTimer = new Stopwatch();

        private static readonly Stopwatch secondBallTimer = new Stopwatch();

        static BallControls ()
        {
            firstController = true;

            secondController = true;
        }

        public static bool FirstController
        {
            get
            {
                return firstController;
            }
            set
            {
                firstController = value;
            }
        }

        public static bool SecondController
        {
            get
            {
                return secondController;
            }
            set
            {
                secondController = value;
            }
        }

        public static CannonBall BallFirst
        {
            get
            {
                return ballFirst;
            }
            set
            {
                ballFirst = value;
            }
        }

        public static CannonBall BallSecond
        {
            get
            {
                return ballSecond;
            }
            set
            {
                ballSecond = value;
            }
        }

        public static void CannonBallInitialise()
        {
            ballFirst = new CannonBall();
            ballSecond = new CannonBall();
        }

        public static void CannonBallLoadContent()
        {
            ballFirst.LoadContent();
            ballSecond.LoadContent();
        }

        public static void CannonBallUnloadContent()
        {
            ballFirst.UnloadContent();
            ballSecond.UnloadContent();
        }

        public static void CannonBallControls(PlayerTypes type, GameTime gameTime)
        {
            switch (type)
            {
                case PlayerTypes.FirstPlayer:
                    if (firstController)
                    {
                        FirstPlayerBallControls(gameTime);
                    }
                    break;
                case PlayerTypes.SecondPlayer:
                    if (secondController)
                    {
                        SecondPlayerBallControls(gameTime);
                    }
                    break;
            }
        }

        public static void CannonBallDraw(PlayerTypes type, SpriteBatch spriteBatch)
        {
            switch (type)
            {
                case PlayerTypes.FirstPlayer:
                    FirstPlayerBallDraw(spriteBatch);
                    break;
                case PlayerTypes.SecondPlayer:
                    SecondPlayerBallDraw(spriteBatch);
                    break;
            }
        }

        private static void FirstPlayerBallControls(GameTime gameTime)
        {
            if (FirstPlayer.Instance.InputManagerInstance.KeyDown(Keys.LeftControl))
            {
                ballFirst.BallFired = true;
                firstBallTimer.Start();

                if (!ballFirst.BallInitialised)
                {
                    ballFirst.FireFlashCounter = 0;
                    ballFirst.Initialise(
                        ballFirst.BallFiredPos =
                        new Vector2(
                            FirstPlayer.Instance.Ship.Position.X + FirstPlayer.Instance.ShipImage.Texture.Width,
                            FirstPlayer.Instance.Ship.Position.Y + (FirstPlayer.Instance.ShipImage.Texture.Height / 2f)),
                        FirstPlayer.Instance.PlayerType);
                    ballFirst.BallInitialised = true;
                }
            }

            if (ballFirst.BallFired)
            {
                ballFirst.UpdateFirst(gameTime);
            }
        }

        private static void SecondPlayerBallControls(GameTime gameTime)
        {
            if (SecondPlayer.Instance.InputManagerInstance.KeyDown(Keys.RightControl))
            {
                ballSecond.BallFired = true;
                secondBallTimer.Start();

                if (!ballSecond.BallInitialised)
                {
                    ballSecond.FireFlashCounter = 0;
                    ballSecond.Initialise(
                        ballSecond.BallFiredPos =
                        new Vector2(
                            SecondPlayer.Instance.Ship.Position.X - SecondPlayer.Instance.ShipImage.Texture.Width / 2f,
                            SecondPlayer.Instance.Ship.Position.Y
                            + (SecondPlayer.Instance.ShipImage.Texture.Height / 2f)),
                        SecondPlayer.Instance.PlayerType);
                    ballSecond.BallInitialised = true;
                }
            }

            if (ballSecond.BallFired)
            {
                ballSecond.UpdateSecond(gameTime);
            }
        }

        private static void FirstPlayerBallDraw(SpriteBatch spriteBatch)
        {
            if (ballFirst.BallFired && ballFirst.FireFlashCounter < 15)
            {
                ballFirst.Fire.Draw(
                    spriteBatch,
                    new Vector2(
                        FirstPlayer.Instance.Ship.Position.X + FirstPlayer.Instance.ShipImage.Texture.Width,
                        FirstPlayer.Instance.Ship.Position.Y + (FirstPlayer.Instance.ShipImage.Texture.Height * 0.6f)
                        - (ballFirst.Fire.Texture.Height / 2f)));
                ballFirst.FireFlashCounter++;
            }

            if (!ballFirst.BallFired)
            {
                return;
            }
            ballFirst.SetPositionRangeX(
                (ballFirst.BallFiredPos.X + (ScreenManager.Instance.Dimensions.X / 2)
                 - FirstPlayer.Instance.ShipImage.Texture.Width));

            if (ballFirst.Position.Y < ballFirst.BallFiredPos.Y) // ballFirst.Position.X < ballFirst.BallRangeX.X
            {
                ballFirst.Draw(spriteBatch);
            }
            else if (firstBallTimer.Elapsed.TotalSeconds > DefaultBallTimer)
            {
                ballFirst.BallInitialised = false;
                ballFirst.BallFired = false;
                firstBallTimer.Stop();
                firstBallTimer.Reset();
            }
        }
        
        private static void SecondPlayerBallDraw(SpriteBatch spriteBatch)
        {
            if (ballSecond.BallFired && ballSecond.FireFlashCounter < 15)
            {
                ballSecond.Fire.Draw(
                    spriteBatch,
                    new Vector2(
                        SecondPlayer.Instance.Ship.Position.X - SecondPlayer.Instance.ShipImage.Texture.Width * 0.9f,
                        SecondPlayer.Instance.Ship.Position.Y + SecondPlayer.Instance.ShipImage.Texture.Height * 0.1f));
                ballSecond.FireFlashCounter++;
            }

            if (ballSecond.BallFired)
            {
                ballSecond.SetPositionRangeX(
                    (ballFirst.BallFiredPos.X + (ScreenManager.Instance.Dimensions.X / 2)
                     - SecondPlayer.Instance.ShipImage.Texture.Width));

                if (ballSecond.Position.Y < ballSecond.BallFiredPos.Y)
                {
                    ballSecond.Draw(spriteBatch);
                }
                else if (secondBallTimer.Elapsed.TotalSeconds > DefaultBallTimer)
                {
                    ballSecond.BallInitialised = false;
                    ballSecond.BallFired = false;
                    secondBallTimer.Stop();
                    secondBallTimer.Reset();
                }
            }
        }
    }
}