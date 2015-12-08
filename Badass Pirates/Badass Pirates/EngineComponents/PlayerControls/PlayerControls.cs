namespace Badass_Pirates.EngineComponents.PlayerControls
{
    using System.Runtime.CompilerServices;

    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.EngineComponents.Objects;
    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Players;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using Player = Badass_Pirates.GameObjects.Players.Player;

    public class PlayerControls
    {
        private static bool ballFired;

        private static int fireFlashCounter;

        private static bool ballInitialised;

        private static Vector2 ballFiredPos;

        private static CannonBall ball;

        private static Vector2 ballRangeX;

        public static void BallInitialise()
        {
            ball = new CannonBall();
        }

        public static void BallLoadContent()
        {
            ball.LoadContent();
        }

        public static void BallUnloadContent()
        {
            ball.UnloadContent();
        }

        public static void ControlsPlayer(PlayerTypes type,GameTime gameTime,Player currentPlayer,Image shipImage)
        {
            switch (type)
            {
                    case PlayerTypes.FirstPlayer:
                    PlayerControls.UpdateFirstPlayer(gameTime,currentPlayer,shipImage);
                    break;
                    case PlayerTypes.SecondPlayer:
                    PlayerControls.UpdateSecondPlayer(gameTime,currentPlayer,shipImage);
                    break;
            }
        }
        
        private static void UpdateFirstPlayer(GameTime gameTime, Player currentPlayer,Image shipImage)
        {
            InputManager.Instance.RotateStates();
            if (InputManager.Instance.KeyDown(Keys.S))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Ordinate,
                    Direction.Positive,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer,shipImage);
            }

            if (InputManager.Instance.KeyDown(Keys.W))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Ordinate,
                    Direction.Negative,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer,shipImage);
            }

            if (InputManager.Instance.KeyDown(Keys.D))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Abscissa,
                    Direction.Positive,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer,shipImage);
            }

            if (InputManager.Instance.KeyDown(Keys.A))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Abscissa,
                    Direction.Negative,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer,shipImage);
            }

            InputManager.Instance.Update();
        }

        private static void UpdateSecondPlayer(GameTime gameTime, Player currentPlayer, Image shipImage)
        {
            InputManager.Instance.RotateStates();
            if (InputManager.Instance.KeyDown(Keys.Down))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Ordinate,
                    Direction.Positive,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer, shipImage);
            }

            if (InputManager.Instance.KeyDown(Keys.Up))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Ordinate,
                    Direction.Negative,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer, shipImage);
            }

            if (InputManager.Instance.KeyDown(Keys.Right))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Abscissa,
                    Direction.Positive,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer, shipImage);
            }

            if (InputManager.Instance.KeyDown(Keys.Left))
            {
                // имплементиран е метод Move.Намира се в абстрактния клас Ship
                currentPlayer.Ship.Move(
                    CoordsDirections.Abscissa,
                    Direction.Negative,
                    currentPlayer.Ship.Speed);
                PlayerControls.ValidateShipPosition(currentPlayer, shipImage);
            }

            InputManager.Instance.Update();
        }
        

        public static void BallControls(Player currentPlayer,Image shipImage,GameTime gameTime)
        {
            
           if (InputManager.Instance.KeyDown(Keys.Space))
            {
                ballFired = true;
                if (ballFired)
                {
                    if (!ballInitialised)
                    {
                        fireFlashCounter = 0;
                        ball.Initialise(
                            ballFiredPos =
                            new Vector2(
                                currentPlayer.Ship.Position.X + shipImage.Texture.Width,
                                currentPlayer.Ship.Position.Y + (shipImage.Texture.Height / 2f)));
                        ballInitialised = true;
                    }
                }
            }

            if (ballFired)
            {
                ball.Update(gameTime);
            }
        }

        public static void BallDraw(SpriteBatch spriteBatch,Player currentPlayer,Image shipImage)
        {
            if (ballFired && fireFlashCounter < 15)
            {
                ball.Fire.Draw(
                    spriteBatch,
                    new Vector2(
                        currentPlayer.Ship.Position.X + shipImage.Texture.Width,
                        currentPlayer.Ship.Position.Y + (shipImage.Texture.Height / 2f)
                        - (ball.Fire.Texture.Height / 2f)));
                fireFlashCounter++;
            }

            if (ballFired)
            {
                ballRangeX.X = ballFiredPos.X + (ScreenManager.Instance.Dimensions.X / 2)
                                    - shipImage.Texture.Width;

                if (ball.Position.X < ballRangeX.X)
                {
                    ball.Draw(spriteBatch);
                }
                else
                {
                    ballInitialised = false;
                    ballFired = false;
                }
            }
        }

        private static void ValidateShipPosition(Player currentPlayer,Image shipImage)
        {
            if (currentPlayer.Ship.Position.X < 0)
            {
                currentPlayer.Ship.SetPosition(CoordsDirections.Abscissa, 0);
            }

            if (currentPlayer.Ship.Position.Y < 0)
            {
                /* setter - а на Vector2 е недостъпен.Изисква собствена имплементация,минаваща през полето ! ! !
                            Имплементирана е в абстрактния клас Ship,чрез метода : SetPosition() */
                currentPlayer.Ship.SetPosition(CoordsDirections.Ordinate, 0);
            }

            if (currentPlayer.Ship.Position.Y > ScreenManager.Instance.Dimensions.Y - shipImage.Texture.Height)
            {
                /* setter - а на Vector2 е недостъпен.Изисква собствена имплементация,минаваща през полето ! ! !
                            Имплементирана е в абстрактния клас Ship,чрез метода : SetPosition() */
                currentPlayer.Ship.SetPosition(
                    CoordsDirections.Ordinate,
                    ScreenManager.Instance.Dimensions.Y - shipImage.Texture.Height);
            }

            if (currentPlayer.Ship.Position.X > ScreenManager.Instance.Dimensions.X - shipImage.Texture.Width)
            {
                /* setter - а на Vector2 е недостъпен.Изисква собствена имплементация,минаваща през полето ! ! !
                            Имплементирана е в абстрактния клас Ship,чрез метода : SetPosition() */
                currentPlayer.Ship.SetPosition(
                    CoordsDirections.Abscissa,
                    ScreenManager.Instance.Dimensions.X - shipImage.Texture.Width);
            }
        }
    }
}
