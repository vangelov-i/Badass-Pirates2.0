namespace Badass_Pirates.Managers
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

        private const int BossActivationSeconds = 5;
        private const int DamageFontShowingTime = 150;
        private static IPlayer currentPlayer;
        private static int playerFlagBossCollide;
        private static bool ballColliding;
        private static bool bossBallCollide;
        private static bool bossVsShipCollide;
        private static int? firstPlayerHitCounter;
        private static int? secondPlayerHitCounter;
        private static int? bossHitCounter;
        private static Font damageFont;
        private static Stopwatch activateBossWatch;
        private static bool control;

        #endregion

        public static bool Control
        {
            get
            {
                return control;
            }
            set
            {
                control = value;
            }
        }

        #region Methods
        public static void Initilialise(IPlayer currPlayer)
        {
            control = true;
            activateBossWatch = new Stopwatch();
            damageFont = new Font(Color.Red, "Fonts", "big");
            currentPlayer = currPlayer;
            ballColliding = false;
            bossBallCollide = false;
            bossVsShipCollide = false;
            BallControls.CannonBallInitialise();

            // TODO Could be ENUM
            playerFlagBossCollide = -1;
        }

        public static void LoadContent()
        {
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
            ControlsPlayer(type);

            #region Ball Players Collisions

            // KOGATO TEPAT PURVIQ
            ballColliding = BallCollision.Collide(
                    FirstPlayer.Instance.Ship,
                    BallControls.BallSecond);
            if (ballColliding)
            {
                BallControls.BallSecond.ImpacEffect.Open(new System.Uri(@"C:\Users\Iliyan\Desktop\Dropbox\[Git] Badass Pirates2.0\Badass Pirates\Badass Pirates\Content\impactSound.wav"));
                BallControls.BallSecond.ImpacEffect.Play();
                firstPlayerHitCounter = 0;
                SecondPlayer.Instance.Ship.Attack(FirstPlayer.Instance.Ship);
            }

            ballColliding = BallCollision.Collide(
                SecondPlayer.Instance.Ship,
                BallControls.BallFirst);
            if (ballColliding)
            {
                BallControls.BallFirst.ImpacEffect.Open(new System.Uri(@"C:\Users\Iliyan\Desktop\Dropbox\[Git] Badass Pirates2.0\Badass Pirates\Badass Pirates\Content\impactSound.wav"));
                BallControls.BallFirst.ImpacEffect.Play();
                secondPlayerHitCounter = 0;
                FirstPlayer.Instance.Ship.Attack(SecondPlayer.Instance.Ship);

            }
            #endregion

            #region Ball Boss Collisions
            // 5 - const i za spawn na bossa
            if (activateBossWatch.Elapsed.TotalSeconds > BossActivationSeconds)
            {
                // topchEto na pyrviq igrach
                bossBallCollide = OctopusCollision.BossBallCollide(BallControls.BallFirst);
                if (bossBallCollide)
                {
                    firstPlayerHitCounter = 0;
                    Boss.Instance.Health -= FirstPlayer.Instance.Ship.Damage;  // ne e dobre da e tuk, no Attack() priema Ship, a ne Boss
                }

                // topchEto na vtoriq igrach
                bossBallCollide = OctopusCollision.BossBallCollide(BallControls.BallSecond);
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
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            //TODO Tрябва да се изнесе в логиката при фонтовете или в отделен клас !
            //igrachite
            if (firstPlayerHitCounter < DamageFontShowingTime && firstPlayerHitCounter != null
                && BallControls.FirstController)
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
                && BallControls.SecondController)
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
                if (playerFlagBossCollide == 1 && BallControls.FirstController)
                {
                    damageFont.Draw(
                            spriteBatch,
                            new Vector2(
                            FirstPlayer.Instance.Ship.Position.X,
                            FirstPlayer.Instance.Ship.Position.Y - 40),
                            string.Format((Boss.Instance.Damage * -1).ToString())); // moje i po elegantno :D
                    bossHitCounter++;
                }
                else if(playerFlagBossCollide == 0 && BallControls.SecondController)
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
            //TODO END TODO

            FirstPlayer.Instance.Ship.Specialty.Draw(spriteBatch, FirstPlayer.Instance.Ship.Specialty.Position);
            SecondPlayer.Instance.Ship.Specialty.Draw(spriteBatch, SecondPlayer.Instance.Ship.Specialty.Position);
        }

        private static void ControlsPlayer(PlayerTypes type)
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