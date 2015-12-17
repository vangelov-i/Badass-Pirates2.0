﻿namespace Badass_Pirates.Managers
{
    using Badass_Pirates.Collisions;
    using Badass_Pirates.Controls;
    using Badass_Pirates.Fonts;
    using Badass_Pirates.GameObjects.Mobs.Boss;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System.Diagnostics;

    public static class CombatManager
    {
        #region Fields
        private const int BossActivationSeconds = 60;
        private const int DamageFontShowingTime = 150;


        private static Player firstPlayer;
        private static Player secondPlayer;
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
            firstPlayer = PlayersInfo.GetCurrentPlayer(PlayerTypes.FirstPlayer);
            secondPlayer = PlayersInfo.GetCurrentPlayer(PlayerTypes.SecondPlayer);
            BallControls.CannonBallInitialise();

            // TODO Could be ENUM
            playerFlagBossCollide = -1;
        }

        public static void LoadContent()
        {
            damageFont.LoadContent();
            firstPlayer.Ship.Specialty.LoadContent();
            secondPlayer.Ship.Specialty.LoadContent();
            activateBossWatch.Start();
        }

        public static void UnloadContent()
        {
            damageFont.UnloadContent();
            currentPlayer.Ship.Specialty.UnloadContent();
        }

        public static void Update(GameTime gameTime, PlayerTypes type, Player current)
        {
            RegenManager.EnergyRegenUpdate(firstPlayer, secondPlayer);
            current.Ship.Specialty.Update(gameTime, current);
            ControlsPlayer(type, current);

            #region Ball Players Collisions

            // KOGATO TEPAT PURVIQ
            ballColliding = BallCollision.Collide(
                    firstPlayer.Ship,
                    BallControls.ballSecond);
            if (ballColliding)
            {
                firstPlayerHitCounter = 0;
                secondPlayer.Ship.Attack(firstPlayer.Ship);
            }

            ballColliding = BallCollision.Collide(
                secondPlayer.Ship,
                BallControls.ballFirst);
            if (ballColliding)
            {
                secondPlayerHitCounter = 0;
                firstPlayer.Ship.Attack(secondPlayer.Ship);

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
                    Boss.Health -= firstPlayer.Ship.Damage;  // ne e dobre da e tuk, no Attack() priema Ship, a ne Boss
                }

                // topchEto na vtoriq igrach
                bossBallCollide = OctopusCollision.BossBallCollide(BallControls.ballSecond);
                if (bossBallCollide)
                {
                    secondPlayerHitCounter = 0;
                    Boss.Health -= secondPlayer.Ship.Damage;  // ne e dobre da e tuk, no Attack() priema Ship, a ne Boss
                }
            }
            #endregion

            #region BossVsPlayer Collisions

            if (activateBossWatch.Elapsed.TotalSeconds > BossActivationSeconds)
            {
                Boss.Update();
                bossVsShipCollide = OctopusCollision.Collide(current.Ship);
                if (bossVsShipCollide)
                {
                    bossHitCounter = 0;
                    Boss.Attack(current.Ship);
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
            if (firstPlayer.Ship.Health <= 0)
            {
                PlayersInfo.GetCurrentVirtualPlayer(PlayerTypes.FirstPlayer).Sinked = true;
            }
            if (secondPlayer.Ship.Health <= 0)
            {
                PlayersInfo.GetCurrentVirtualPlayer(PlayerTypes.SecondPlayer).Sinked = true;
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            //igrachite
            if (firstPlayerHitCounter < DamageFontShowingTime && firstPlayerHitCounter != null) // ballColliding && 
            {
                damageFont.Draw(
                    spriteBatch,
                    new Vector2(
                        firstPlayer.Ship.Position.X,
                        firstPlayer.Ship.Position.Y - 40),
                    string.Format((secondPlayer.Ship.Damage * -1).ToString())); // moje i po elegantno :D
                firstPlayerHitCounter++;
            }
            if (secondPlayerHitCounter < DamageFontShowingTime && secondPlayerHitCounter != null)
            {
                damageFont.Draw(
                    spriteBatch,
                    new Vector2(
                        secondPlayer.Ship.Position.X,
                        secondPlayer.Ship.Position.Y - 40),
                    string.Format((firstPlayer.Ship.Damage * -1).ToString())); // moje i po elegantno :D
                secondPlayerHitCounter++;
            }

            if (bossHitCounter < DamageFontShowingTime && bossHitCounter != null)
            {
                if (playerFlagBossCollide == 1)
                {
                    damageFont.Draw(
                            spriteBatch,
                            new Vector2(
                            firstPlayer.Ship.Position.X,
                            firstPlayer.Ship.Position.Y - 40),
                            string.Format((Boss.Damage * -1).ToString())); // moje i po elegantno :D
                    bossHitCounter++;
                }
                else if(playerFlagBossCollide == 0)
                {
                    damageFont.Draw(
                            spriteBatch,
                            new Vector2(
                            secondPlayer.Ship.Position.X,
                            secondPlayer.Ship.Position.Y - 40),
                            string.Format((Boss.Damage * -1).ToString())); // moje i po elegantno :D
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
                        Boss.Position.X + Boss.image.Texture.Width / 2f - 25,
                        Boss.Position.Y),
                        string.Format((firstPlayer.Ship.Damage * -1).ToString())); // ne e dovyrsheno, ne raboti!!! 
                        firstPlayerHitCounter++;

            }

            if (secondPlayerHitCounter < DamageFontShowingTime && secondPlayerHitCounter != null &&
                activateBossWatch.Elapsed.TotalSeconds > BossActivationSeconds)
            {
                damageFont.Draw(
                    spriteBatch,
                    new Vector2(
                        Boss.Position.X + Boss.image.Texture.Width / 2f - 25,
                        Boss.Position.Y),
                        string.Format((secondPlayer.Ship.Damage * -1).ToString())); // ne e dovyrsheno, ne raboti!!! 
                        secondPlayerHitCounter++;

            }


            firstPlayer.Ship.Specialty.Draw(spriteBatch, firstPlayer.Ship.Specialty.Position);
            secondPlayer.Ship.Specialty.Draw(spriteBatch, secondPlayer.Ship.Specialty.Position);
        }

        private static void ControlsPlayer(PlayerTypes type, Player current)
        {
            if (control)
            {
                switch (type)
                {
                    case PlayerTypes.FirstPlayer:
                        CombatManager.UpdateFirstPlayer(current);
                        break;
                    case PlayerTypes.SecondPlayer:
                        CombatManager.UpdateSecondPlayer(current);
                        break;
                }
            }
        }

        private static void UpdateFirstPlayer(Player current)
        {
            current.InputManagerInstance.RotateStates();

            if (current.Ship.Energy >= Ship.MAX_ENERGY && firstPlayer.InputManagerInstance.KeyDown(Keys.LeftShift))
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

        private static void UpdateSecondPlayer(Player current)
        {
            current.InputManagerInstance.RotateStates();

            if (current.Ship.Energy >= Ship.MAX_ENERGY && secondPlayer.InputManagerInstance.KeyDown(Keys.RightShift))
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