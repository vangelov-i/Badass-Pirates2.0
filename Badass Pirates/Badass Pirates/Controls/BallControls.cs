namespace Badass_Pirates.Controls
{
    #region

    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Objects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System.Diagnostics;
    using Player = Badass_Pirates.GameObjects.Players.Player;

    #endregion

    public class BallControls
    {
        // TODO NEED PROPERTY
        private const int DefaultBallTimer = 2;


        public static CannonBall ballFirst;

        public static CannonBall ballSecond;

        public static bool firstController = true;

        public static bool secondController = true;

        private static Stopwatch firstBallTimer = new Stopwatch();

        private static Stopwatch secondBallTimer = new Stopwatch();


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

        public static void CannonBallControls(
            PlayerTypes type,
            Player currentPlayer,
            Image shipImage,
            GameTime gameTime)
        {
            switch (type)
            {
                case PlayerTypes.FirstPlayer:
                    if (firstController)
                    {
                        FirstPlayerBallControls(currentPlayer, shipImage, gameTime);
                    }
                    break;
                case PlayerTypes.SecondPlayer:
                    if (secondController)
                    {
                        SecondPlayerBallControls(currentPlayer, shipImage, gameTime);
                    }
                    break;
            }
        }

        public static void CannonBallDraw(
            PlayerTypes type,
            SpriteBatch spriteBatch,
            Player currentPlayer,
            Image shipImage)
        {
            switch (type)
            {
                case PlayerTypes.FirstPlayer:
                    FirstPlayerBallDraw(spriteBatch, currentPlayer, shipImage);
                    type = PlayerTypes.FirstPlayer;
                    break;
                case PlayerTypes.SecondPlayer:
                    SecondPlayerBallDraw(spriteBatch, currentPlayer, shipImage);
                    type = PlayerTypes.SecondPlayer;
                    break;
            }
        }

        private static void FirstPlayerBallControls(Player currentPlayer, Image shipImage, GameTime gameTime)
        {
            if (currentPlayer.InputManagerInstance.KeyDown(Keys.LeftControl))
            {
                ballFirst.BallFired = true;
                firstBallTimer.Start();

                if (!ballFirst.BallInitialised)
                {
                    ballFirst.FireFlashCounter = 0;
                    ballFirst.Initialise(
                        ballFirst.BallFiredPos =
                        new Vector2(
                            currentPlayer.Ship.Position.X + shipImage.Texture.Width,
                            currentPlayer.Ship.Position.Y + (shipImage.Texture.Height / 2f)),
                        currentPlayer.TypeOfPlayer);
                    ballFirst.BallInitialised = true;
                }

            }

            if (ballFirst.BallFired)
            {
                ballFirst.UpdateFirst(gameTime);
            }
        }

        private static void SecondPlayerBallControls(Player currentPlayer, Image shipImage, GameTime gameTime)
        {
            if (currentPlayer.InputManagerInstance.KeyDown(Keys.RightControl))
            {
                ballSecond.BallFired = true;
                secondBallTimer.Start();

                if (!ballSecond.BallInitialised)
                {
                    ballSecond.FireFlashCounter = 0;
                    ballSecond.Initialise(
                        ballSecond.BallFiredPos =
                        new Vector2(
                            currentPlayer.Ship.Position.X - shipImage.Texture.Width / 2f,
                            currentPlayer.Ship.Position.Y + (shipImage.Texture.Height / 2f)),
                        currentPlayer.TypeOfPlayer);
                    ballSecond.BallInitialised = true;
                }

            }

            if (ballSecond.BallFired)
            {
                ballSecond.UpdateSecond(gameTime);
            }
        }

        private static void FirstPlayerBallDraw(SpriteBatch spriteBatch, Player currentPlayer, Image shipImage)
        {
            if (ballFirst.BallFired && ballFirst.FireFlashCounter < 15)
            {
                ballFirst.Fire.Draw(
                    spriteBatch,
                    new Vector2(
                        currentPlayer.Ship.Position.X + shipImage.Texture.Width,
                        currentPlayer.Ship.Position.Y + (shipImage.Texture.Height * 0.6f)
                        - (ballFirst.Fire.Texture.Height / 2f)));
                ballFirst.FireFlashCounter++;
            }

            if (ballFirst.BallFired)
            {
                ballFirst.SetPositionRangeX(
                    (ballFirst.BallFiredPos.X + (ScreenManager.Instance.Dimensions.X / 2) - shipImage.Texture.Width));

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
        }

        private static void SecondPlayerBallDraw(SpriteBatch spriteBatch, Player currentPlayer, Image shipImage)
        {
            if (ballSecond.BallFired && ballSecond.FireFlashCounter < 15)
            {
                ballSecond.Fire.Draw(
                    spriteBatch,
                    new Vector2(
                        currentPlayer.Ship.Position.X - shipImage.Texture.Width * 0.9f,
                        currentPlayer.Ship.Position.Y + shipImage.Texture.Height * 0.1f));
                ballSecond.FireFlashCounter++;
            }

            if (ballSecond.BallFired)
            {
                ballSecond.SetPositionRangeX(
                    (ballFirst.BallFiredPos.X + (ScreenManager.Instance.Dimensions.X / 2) - shipImage.Texture.Width));

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