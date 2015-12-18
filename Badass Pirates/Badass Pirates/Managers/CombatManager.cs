﻿namespace Badass_Pirates.Managers
{
    using Badass_Pirates.Collisions;
    using Badass_Pirates.Controls;
    using Badass_Pirates.Fonts;
    using Badass_Pirates.GameObjects.Ships;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System.Diagnostics;

    using Badass_Pirates.Enums;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Models.Mobs.Boss;
    using Badass_Pirates.Models.Players;
    using Badass_Pirates.Models.Ships;

    public static class CombatManager
    {
        #region Fields
        private const int BossActivationSeconds = 45;
        private const int DamageFontShowingTime = 150;


        //private static Player firstPlayer;
        //private static Player secondPlayer;
        private static Player currentPlayer;
        private static int playerFlagBossCollide;
        private static bool ballColliding;
        private static bool bossBallCollide;
        private static bool bossVsShipCollide;
        private static int? firstPlayerHitCounter;
        private static int? secondPlayerHitCounter;
        private static int? bossHitCounter;
        private static Font damageFont;
        private static Stopwatch activateBossWatch;

        public static bool control = true;


        #endregion

        #region Methods
        public static void Initilialise(Player currPlayer)
        {
            activateBossWatch = new Stopwatch();
            damageFont = new Font(Color.Red, "Fonts", "big");
            currentPlayer = currPlayer;
            ballColliding = false;
            bossBallCollide = false;
            bossVsShipCollide = false;
            //firstPlayer = PlayersInfo.GetCurrentPlayer(PlayerTypes.FirstPlayer);
            //secondPlayer = PlayersInfo.GetCurrentPlayer(PlayerTypes.SecondPlayer);
            BallControls.CannonBallInitialise();

            // TODO Could be ENUM
            playerFlagBossCollide = -1;
        }

        public static void LoadContent()
        {
            damageFont.LoadContent();
            FirstPlayer.Instance.Ship.Specialty.LoadContent();
            SecondPlayer.Instance.Ship.Specialty.LoadContent();
            activateBossWatch.Start();
        }

        public static void UnloadContent()
        {
            damageFont.UnloadContent();
            currentPlayer.Ship.Specialty.UnloadContent();
        }

        public static void Update(GameTime gameTime, PlayerTypes type, IPlayer current)
        {
            RegenManager.EnergyRegenUpdate();
            current.Ship.Specialty.Update(gameTime, current);
            ControlsPlayer(type, current);

            #region Ball Players Collisions

            // KOGATO TEPAT PURVIQ
            ballColliding = BallCollision.Collide(
                    FirstPlayer.Instance.Ship,
                    BallControls.ballSecond);
            if (ballColliding)
            {
                firstPlayerHitCounter = 0;
                SecondPlayer.Instance.Ship.Attack(FirstPlayer.Instance.Ship);
            }

            ballColliding = BallCollision.Collide(
                SecondPlayer.Instance.Ship,
                BallControls.ballFirst);
            if (ballColliding)
            {
                secondPlayerHitCounter = 0;
                FirstPlayer.Instance.Ship.Attack(SecondPlayer.Instance.Ship);

            }
            #endregion

            #region Ball Boss Collisions
            // 5 - const i za spawn na bossa
            if (activateBossWatch.Elapsed.TotalSeconds > BossActivationSeconds)
            {
                // topchEto na pyrviq igrach
                bossBallCollide = OctopusCollision.BossBallCollide(BallControls.ballFirst);
                if (bossBallCollide)
                {
                    firstPlayerHitCounter = 0;
                    Boss.Instance.Health -= FirstPlayer.Instance.Ship.Damage;  // ne e dobre da e tuk, no Attack() priema Ship, a ne Boss
                }

                // topchEto na vtoriq igrach
                bossBallCollide = OctopusCollision.BossBallCollide(BallControls.ballSecond);
                if (bossBallCollide)
                {
                    secondPlayerHitCounter = 0;
                    Boss.Instance.Health -= SecondPlayer.Instance.Ship.Damage;  // ne e dobre da e tuk, no Attack() priema Ship, a ne Boss
                }
            }
            #endregion

            #region BossVsPlayer Collisions

            if (activateBossWatch.Elapsed.TotalSeconds > BossActivationSeconds)
            {
                Boss.Instance.Update();
                bossVsShipCollide = OctopusCollision.Collide(current.Ship);
                if (bossVsShipCollide)
                {
                    bossHitCounter = 0;
                    Boss.Instance.Attack(current.Ship);
                    if (current is FirstPlayer)
                    {
                        playerFlagBossCollide = 1;
                    }
                    else
                    {
                        playerFlagBossCollide = 0;
                    }
                }
            }

            #endregion


            // Трябва да се премести в пропърти на кораба
            if (FirstPlayer.Instance.Ship.Health <= 0)
            {
                FirstPlayer.Instance.Sunk = true;
            }
            if (SecondPlayer.Instance.Ship.Health <= 0)
            {
               SecondPlayer.Instance.Sunk = true;
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            //igrachite
            if (firstPlayerHitCounter < DamageFontShowingTime && firstPlayerHitCounter != null
                && BallControls.firstController) // ballColliding && 
            {
                damageFont.Draw(
                    spriteBatch,
                    new Vector2(
                        FirstPlayer.Instance.Ship.Position.X,
                        FirstPlayer.Instance.Ship.Position.Y - 40),
                    string.Format((SecondPlayer.Instance.Ship.Damage * -1).ToString())); // moje i po elegantno :D
                firstPlayerHitCounter++;
            }
            if (secondPlayerHitCounter < DamageFontShowingTime && secondPlayerHitCounter != null
                && BallControls.secondController)
            {
                damageFont.Draw(
                    spriteBatch,
                    new Vector2(
                        SecondPlayer.Instance.Ship.Position.X,
                        SecondPlayer.Instance.Ship.Position.Y - 40),
                    string.Format((FirstPlayer.Instance.Ship.Damage * -1).ToString())); // moje i po elegantno :D
                secondPlayerHitCounter++;
            }

            if (bossHitCounter < DamageFontShowingTime && bossHitCounter != null)
            {
                if (playerFlagBossCollide == 1 && BallControls.firstController)
                {
                    damageFont.Draw(
                            spriteBatch,
                            new Vector2(
                            FirstPlayer.Instance.Ship.Position.X,
                            FirstPlayer.Instance.Ship.Position.Y - 40),
                            string.Format((Boss.Instance.Damage * -1).ToString())); // moje i po elegantno :D
                    bossHitCounter++;
                }
                else if(playerFlagBossCollide == 0 && BallControls.secondController)
                {
                    damageFont.Draw(
                            spriteBatch,
                            new Vector2(
                            SecondPlayer.Instance.Ship.Position.X,
                            SecondPlayer.Instance.Ship.Position.Y - 40),
                            string.Format((Boss.Instance.Damage * -1).ToString())); // moje i po elegantno :D
                    bossHitCounter++;
                }
            }

            // kogato e udaren bossyt
            if (firstPlayerHitCounter < DamageFontShowingTime && firstPlayerHitCounter != null &&
                activateBossWatch.Elapsed.TotalSeconds > BossActivationSeconds)
            {
                damageFont.Draw(
                    spriteBatch,
                    new Vector2(
                        Boss.Instance.Position.X + Boss.Instance.image.Texture.Width / 2f - 25,
                        Boss.Instance.Position.Y),
                        string.Format((FirstPlayer.Instance.Ship.Damage * -1).ToString())); // ne e dovyrsheno, ne raboti!!! 
                        firstPlayerHitCounter++;

            }

            if (secondPlayerHitCounter < DamageFontShowingTime && secondPlayerHitCounter != null &&
                activateBossWatch.Elapsed.TotalSeconds > BossActivationSeconds)
            {
                damageFont.Draw(
                    spriteBatch,
                    new Vector2(
                        Boss.Instance.Position.X + Boss.Instance.image.Texture.Width / 2f - 25,
                        Boss.Instance.Position.Y),
                        string.Format((SecondPlayer.Instance.Ship.Damage * -1).ToString())); // ne e dovyrsheno, ne raboti!!! 
                        secondPlayerHitCounter++;

            }


            FirstPlayer.Instance.Ship.Specialty.Draw(spriteBatch, FirstPlayer.Instance.Ship.Specialty.Position);
            SecondPlayer.Instance.Ship.Specialty.Draw(spriteBatch, SecondPlayer.Instance.Ship.Specialty.Position);
        }

        private static void ControlsPlayer(PlayerTypes type, IPlayer current)
        {
            if (control)
            {
                switch (type)
                {
                    case PlayerTypes.FirstPlayer:
                        CombatManager.UpdateFirstPlayer();
                        break;
                    case PlayerTypes.SecondPlayer:
                        CombatManager.UpdateSecondPlayer();
                        break;
                }
            }
        }

        private static void UpdateFirstPlayer()
        {
            FirstPlayer.Instance.InputManagerInstance.RotateStates();

            if (FirstPlayer.Instance.Ship.Energy >= Ship.MAX_ENERGY && FirstPlayer.Instance.InputManagerInstance.KeyDown(Keys.LeftShift))
            {
                if (FirstPlayer.Instance.Ship is Battleship)
                {
                    FirstPlayer.Instance.Ship.Specialty.ActivateSpecialty(SecondPlayer.Instance);
                }
                else
                {
                    FirstPlayer.Instance.Ship.Specialty.ActivateSpecialty(FirstPlayer.Instance);
                }

                FirstPlayer.Instance.Ship.Energy = 0;
            }

            FirstPlayer.Instance.InputManagerInstance.Update();
        }

        private static void UpdateSecondPlayer()
        {
            SecondPlayer.Instance.InputManagerInstance.RotateStates();

            if (SecondPlayer.Instance.Ship.Energy >= Ship.MAX_ENERGY && SecondPlayer.Instance.InputManagerInstance.KeyDown(Keys.RightShift))
            {
                if (SecondPlayer.Instance.Ship is Battleship)
                {
                    SecondPlayer.Instance.Ship.Specialty.ActivateSpecialty(FirstPlayer.Instance);
                }
                else
                {
                    SecondPlayer.Instance.Ship.Specialty.ActivateSpecialty(SecondPlayer.Instance);
                }

                SecondPlayer.Instance.Ship.Energy = 0;
            }

            SecondPlayer.Instance.InputManagerInstance.Update();
        }


        #endregion

    }
}