namespace Badass_Pirates.Handler
{
    using Badass_Pirates.Collisions;
    using Badass_Pirates.Controls;
    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.Exceptions;
    using Badass_Pirates.Fonts;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Managers;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public static class CombatManager
    {
        #region Fields

        private static Player firstPlayer;
        private static Player secondPlayer;
        private static Player currentPlayer;
        private static bool ballColliding;
        private static int? firstPlayerHitCounter;
        private static int? secondPlayerHitCounter;
        private static Font damageFont;
        public static bool control = true;


        #endregion

        #region Methods
        public static void Initilialise(Player currPlayer)
        {
            damageFont = new Font(Color.Red, "Fonts", "big");
            currentPlayer = currPlayer;
            ballColliding = false;
            firstPlayer = PlayersInfo.GetCurrentPlayer(PlayerTypes.FirstPlayer);
            secondPlayer = PlayersInfo.GetCurrentPlayer(PlayerTypes.SecondPlayer);
            BallControls.CannonBallInitialise();
        }

        public static void LoadContent()
        {
            damageFont.LoadContent();
            firstPlayer.Ship.Specialty.LoadContent();
            secondPlayer.Ship.Specialty.LoadContent();
        }

        public static void UnloadContent()
        {
            damageFont.UnloadContent();
            currentPlayer.Ship.Specialty.UnloadContent();
        }

        public static void Update(GameTime gameTime, PlayerTypes type, Player current)
        {

            RegenManager.EnergyRegenUpdate(firstPlayer,secondPlayer);
            current.Ship.Specialty.Update(gameTime, current);
            ControlsPlayer(type, gameTime, current);

            #region Ball

            // KOGATO TEPAT PURVIQ
            ballColliding = BallCollision.Collide(
                    firstPlayer.Ship,
                    BallControls.ballSecond);
            if (ballColliding)
            {
                firstPlayerHitCounter = 0;
                secondPlayer.Ship.Attack(firstPlayer.Ship);
            }
            if (firstPlayer.Ship.Health <= 0)
            {
                throw new OutOfHealthException();
            }

            ballColliding = BallCollision.Collide(
                secondPlayer.Ship,
                BallControls.ballFirst);
            if (ballColliding)
            {
                secondPlayerHitCounter = 0;
                firstPlayer.Ship.Attack(secondPlayer.Ship);
                if (secondPlayer.Ship.Health <= 0)
                {
                    throw new OutOfHealthException();
                }
            }
            #endregion

        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if (firstPlayerHitCounter < 15 && firstPlayerHitCounter != null) // ballColliding && 
            {
                damageFont.Draw(
                    spriteBatch,
                    new Vector2(
                        firstPlayer.Ship.Position.X,
                        firstPlayer.Ship.Position.Y - 40),
                    string.Format("-" + secondPlayer.Ship.Damage)); // moje i po elegantno :D
                firstPlayerHitCounter++;
            }
            if (secondPlayerHitCounter < 15 && secondPlayerHitCounter != null)
            {
                damageFont.Draw(
                    spriteBatch,
                    new Vector2(
                        secondPlayer.Ship.Position.X,
                        secondPlayer.Ship.Position.Y - 40),
                    string.Format("-" + firstPlayer.Ship.Damage)); // moje i po elegantno :D
                secondPlayerHitCounter++;
            }

            firstPlayer.Ship.Specialty.Draw(spriteBatch, firstPlayer.Ship.Specialty.Position);
            secondPlayer.Ship.Specialty.Draw(spriteBatch, secondPlayer.Ship.Specialty.Position);
        }


        private static void ControlsPlayer(PlayerTypes type, GameTime gameTime, Player current)
        {
            if (control)
            {
                switch (type)
                {
                    case PlayerTypes.FirstPlayer:
                        CombatManager.UpdateFirstPlayer(gameTime, current);
                        break;
                    case PlayerTypes.SecondPlayer:
                        CombatManager.UpdateSecondPlayer(gameTime, current);
                        break;
                }
            }
        }

        private static void UpdateFirstPlayer(GameTime gameTime, Player current)
        {
            current.InputManagerInstance.RotateStates();

            if (current.Ship.Energy >= Ship.energyStatic && firstPlayer.InputManagerInstance.KeyDown(Keys.LeftShift))
            {
                if (current.Ship is Battleship)
                {
                    current.Ship.Specialty.ActivateSpecialty(secondPlayer);
                }
                else
                {
                    current.Ship.Specialty.ActivateSpecialty(current);
                }

                current.Ship.Energy = 0;
            }

            current.InputManagerInstance.Update();
        }

        private static void UpdateSecondPlayer(GameTime gameTime, Player current)
        {
            current.InputManagerInstance.RotateStates();

            if (current.Ship.Energy >= Ship.energyStatic && secondPlayer.InputManagerInstance.KeyDown(Keys.RightShift))
            {
                if (current.Ship is Battleship)
                {
                    current.Ship.Specialty.ActivateSpecialty(firstPlayer);
                }
                else
                {
                    current.Ship.Specialty.ActivateSpecialty(current);
                }

                current.Ship.Energy = 0;
            }

            current.InputManagerInstance.Update();
        }


        #endregion

    }
}
