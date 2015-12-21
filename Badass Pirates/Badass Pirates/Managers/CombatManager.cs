namespace Badass_Pirates.Managers
{
    using System.Diagnostics;

    using Badass_Pirates.Collisions;
    using Badass_Pirates.Controls;
    using Badass_Pirates.Enums;
    using Badass_Pirates.Fonts;
    using Badass_Pirates.GameObjects.Ships;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Models.Mobs.Boss;
    using Badass_Pirates.Models.Players;
    using Badass_Pirates.Models.Ships;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class CombatManager
    {
        #region Fields

        private const int BossActivationSeconds = 5;

        private const int DamageFontShowingTime = 150;

        private IPlayer currentPlayer;

        private int playerFlagBossCollide;

        private bool ballColliding;

        private bool bossBallCollide;

        private bool bossVsShipCollide;

        private int? firstPlayerHitCounter;

        private int? secondPlayerHitCounter;

        private int? bossHitCounter;

        private Font damageFont;

        private Stopwatch activateBossWatch;

        private bool control;

        private PlayerTypes typeOfPlayer;


        private PlayerTypes TypeOfPlayer
        {
            get
            {
                if (this.currentPlayer is FirstPlayer)
                {
                    return PlayerTypes.FirstPlayer;
                }

                return PlayerTypes.SecondPlayer;
            }
        }

        #endregion

        #region Methods

        public void Initilialise(IPlayer currPlayer)
        {
            this.control = true;
            this.activateBossWatch = new Stopwatch();
            this.damageFont = new Font(Color.Red, "Fonts", "big");
            this.currentPlayer = currPlayer;
            this.ballColliding = false;
            this.bossBallCollide = false;
            this.bossVsShipCollide = false;
            // TODO Could be ENUM
            this.playerFlagBossCollide = -1;
        }

        public void LoadContent()
        {
            this.currentPlayer.Ship.Specialty.LoadContent();
            this.activateBossWatch.Start();
        }

        public void UnloadContent()
        {
            this.damageFont.UnloadContent();
            this.currentPlayer.Ship.Specialty.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            RegenManager.EnergyRegenUpdate();
            this.currentPlayer.Ship.Specialty.Update(gameTime, this.currentPlayer);
            this.ControlsPlayer(this.TypeOfPlayer);

            #region Ball Players Collisions

            //TODO COLLISION BETWEEN FIRST'S PLAYER BALL AND SECOND'S
            if (this.currentPlayer is FirstPlayer)
            {
                this.ballColliding = BallCollision.Collide(FirstPlayer.Instance.Ship, this.currentPlayer.Ball);
                if (this.ballColliding)
                {
                    this.firstPlayerHitCounter = 0;
                    SecondPlayer.Instance.Ship.Attack(FirstPlayer.Instance.Ship);
                }
            }
            else
            {
                this.ballColliding = BallCollision.Collide(SecondPlayer.Instance.Ship, this.currentPlayer.Ball);
                if (this.ballColliding)
                {
                    this.secondPlayerHitCounter = 0;
                    FirstPlayer.Instance.Ship.Attack(SecondPlayer.Instance.Ship);
                }
            }
            

            #endregion

            #region Ball Boss Collisions

            // 5 - const i za spawn na bossa
            if (this.activateBossWatch.Elapsed.TotalSeconds > BossActivationSeconds)
            {
                // topchEto na pyrviq igrach
                if (this.currentPlayer is FirstPlayer)
                {
                    this.bossBallCollide = OctopusCollision.BossBallCollide(this.currentPlayer.Ball);
                    if (this.bossBallCollide)
                    {
                        this.firstPlayerHitCounter = 0;
                        Boss.Instance.Health -= FirstPlayer.Instance.Ship.Damage;
                        // ne e dobre da e tuk, no Attack() priema Ship, a ne Boss
                    }
                }
                else
                {
                    // topchEto na vtoriq igrach
                    this.bossBallCollide = OctopusCollision.BossBallCollide(this.currentPlayer.Ball);
                    if (this.bossBallCollide)
                    {
                        this.secondPlayerHitCounter = 0;
                        Boss.Instance.Health -= SecondPlayer.Instance.Ship.Damage;
                        // ne e dobre da e tuk, no Attack() priema Ship, a ne Boss
                    }
                }
            }

            #endregion

            #region BossVsPlayer Collisions

            if (this.activateBossWatch.Elapsed.TotalSeconds > BossActivationSeconds)
            {
                Boss.Instance.Update();
                this.bossVsShipCollide = OctopusCollision.Collide(this.currentPlayer.Ship);
                if (this.bossVsShipCollide)
                {
                    this.bossHitCounter = 0;
                    Boss.Instance.Attack(this.currentPlayer.Ship);
                    if (this.currentPlayer is FirstPlayer)
                    {
                        this.playerFlagBossCollide = 1;
                    }
                    else
                    {
                        this.playerFlagBossCollide = 0;
                    }
                }
            }

            #endregion
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //TODO Tрябва да се изнесе в логиката при фонтовете или в отделен клас !
            ////igrachite
            /// public void Draw(SpriteBatch spriteBatch, IProjectile ballFirst, IProjectile ballSecond)
            //if (this.firstPlayerHitCounter < DamageFontShowingTime && this.firstPlayerHitCounter != null
            //    && ballFirst.BallControler)
            //{
            //    this.damageFont.Draw(
            //        spriteBatch,
            //        new Vector2(FirstPlayer.Instance.Ship.Position.X, FirstPlayer.Instance.Ship.Position.Y - 40),
            //        string.Format((SecondPlayer.Instance.Ship.Damage * -1).ToString())); // moje i po elegantno :D
            //    this.firstPlayerHitCounter++;
            //}
            //if (this.secondPlayerHitCounter < DamageFontShowingTime && this.secondPlayerHitCounter != null
            //    && ballSecond.BallControler)
            //{
            //    this.damageFont.Draw(
            //        spriteBatch,
            //        new Vector2(SecondPlayer.Instance.Ship.Position.X, SecondPlayer.Instance.Ship.Position.Y - 40),
            //        string.Format((FirstPlayer.Instance.Ship.Damage * -1).ToString())); // moje i po elegantno :D
            //    this.secondPlayerHitCounter++;
            //}

            //if (this.bossHitCounter < DamageFontShowingTime && this.bossHitCounter != null)
            //{
            //    if (this.playerFlagBossCollide == 1 && ballFirst.BallControler)
            //    {
            //        this.damageFont.Draw(
            //            spriteBatch,
            //            new Vector2(FirstPlayer.Instance.Ship.Position.X, FirstPlayer.Instance.Ship.Position.Y - 40),
            //            string.Format((Boss.Instance.Damage * -1).ToString())); // moje i po elegantno :D
            //        this.bossHitCounter++;
            //    }
            //    else if (this.playerFlagBossCollide == 0 && ballSecond.BallControler)
            //    {
            //        this.damageFont.Draw(
            //            spriteBatch,
            //            new Vector2(SecondPlayer.Instance.Ship.Position.X, SecondPlayer.Instance.Ship.Position.Y - 40),
            //            string.Format((Boss.Instance.Damage * -1).ToString())); // moje i po elegantno :D
            //        this.bossHitCounter++;
            //    }
            //}

            //// kogato e udaren bossyt
            //if (this.firstPlayerHitCounter < DamageFontShowingTime && this.firstPlayerHitCounter != null
            //    && this.activateBossWatch.Elapsed.TotalSeconds > BossActivationSeconds)
            //{
            //    this.damageFont.Draw(
            //        spriteBatch,
            //        new Vector2(
            //            Boss.Instance.Position.X + Boss.Instance.image.Texture.Width / 2f - 25,
            //            Boss.Instance.Position.Y),
            //        string.Format((FirstPlayer.Instance.Ship.Damage * -1).ToString()));
            //    // ne e dovyrsheno, ne raboti!!! 
            //    this.firstPlayerHitCounter++;
            //}

            //if (this.secondPlayerHitCounter < DamageFontShowingTime && this.secondPlayerHitCounter != null
            //    && this.activateBossWatch.Elapsed.TotalSeconds > BossActivationSeconds)
            //{
            //    this.damageFont.Draw(
            //        spriteBatch,
            //        new Vector2(
            //            Boss.Instance.Position.X + Boss.Instance.image.Texture.Width / 2f - 25,
            //            Boss.Instance.Position.Y),
            //        string.Format((SecondPlayer.Instance.Ship.Damage * -1).ToString()));
            //    // ne e dovyrsheno, ne raboti!!! 
            //    this.secondPlayerHitCounter++;
            //}
            ////TODO END TODO

            FirstPlayer.Instance.Ship.Specialty.Draw(spriteBatch, FirstPlayer.Instance.Ship.Specialty.Position);
            SecondPlayer.Instance.Ship.Specialty.Draw(spriteBatch, SecondPlayer.Instance.Ship.Specialty.Position);
        }

        private void ControlsPlayer(PlayerTypes type)
        {
            if (this.control)
            {
                IPlayer player = null;
                IPlayer playerParamForBattleShip = null;
                //TODO Fire button ! Could be changed with other variable
                var controls = default(Keys);

                switch (type)
                {
                    case PlayerTypes.FirstPlayer:
                        player = FirstPlayer.Instance;
                        playerParamForBattleShip = SecondPlayer.Instance;
                        controls = Keys.LeftControl;
                        break;
                    case PlayerTypes.SecondPlayer:
                        player = SecondPlayer.Instance;
                        playerParamForBattleShip = FirstPlayer.Instance;
                        controls = Keys.RightControl;
                        break;
                }

                player.InputManagerInstance.RotateStates();

                if (player.Ship.Energy >= Ship.MAX_ENERGY && player.InputManagerInstance.KeyDown(controls))
                {
                    if (player.Ship is Battleship)
                    {
                        player.Ship.Specialty.ActivateSpecialty(playerParamForBattleShip);
                    }
                    else
                    {
                        player.Ship.Specialty.ActivateSpecialty(playerParamForBattleShip);
                    }

                    player.Ship.Energy = 0;
                }

                player.InputManagerInstance.Update();
            }
        }

        #endregion
    }
}