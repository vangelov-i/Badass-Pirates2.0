namespace Badass_Pirates.Controls
{
    #region

    using System;

    using Badass_Pirates.Enums;
    using Badass_Pirates.Interfaces;
    using Badass_Pirates.Managers;
    using Badass_Pirates.Models.Players;
    using Badass_Pirates.Objects;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    #endregion

    public class BallControls
    {
        private readonly IPlayer player;

        private PlayerTypes type;

        //TODO Ball should not have methods draw,load etc.
        public BallControls (IPlayer player)
        {
            this.player = player;
        }
        
        public void Initialise(PlayerTypes typeOfPlayer)
        {
            this.type = typeOfPlayer;
            this.player.Ball = new CannonBall(this.player.Ball.BallFiredPos, this.type);
        }

        public void LoadContent()
        {
            this.player.Ball.LoadContent();
        }

        public void UnloadContent()
        {
            this.player.Ball.UnloadContent();
        }
        
        public void Update(GameTime gameTime)
        {
            if (this.player.Ball.BallControler)
            {
                this.PlayerBallControls(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 fireStartPosition = new Vector2();

            switch (this.type)
            {
                case PlayerTypes.FirstPlayer:
                    fireStartPosition = new Vector2(FirstPlayer.Instance.Ship.Position.X + FirstPlayer.Instance.ShipImage.Texture.Width, FirstPlayer.Instance.Ship.Position.Y + (FirstPlayer.Instance.ShipImage.Texture.Height * 0.6f) - (this.player.Ball.Fire.Texture.Height / 2f));
                    break;
                case PlayerTypes.SecondPlayer:
                    fireStartPosition = new Vector2(SecondPlayer.Instance.Ship.Position.X - SecondPlayer.Instance.ShipImage.Texture.Width * 0.9f, SecondPlayer.Instance.Ship.Position.Y + SecondPlayer.Instance.ShipImage.Texture.Height * 0.1f);
                    break;
            }

            if (this.player.Ball.BallFired && this.player.Ball.FireFlashCounter < 15)
            {
                this.player.Ball.Fire.Draw(spriteBatch, fireStartPosition);
                this.player.Ball.FireFlashCounter++;
            }

            if (!this.player.Ball.BallFired)
            {
                return;
            }
            this.player.Ball.SetPositionRangeX((this.player.Ball.BallFiredPos.X + (ScreenManager.Instance.Dimensions.X / 2) - FirstPlayer.Instance.ShipImage.Texture.Width));

            if (this.player.Ball.Position.Y < this.player.Ball.BallFiredPos.Y)
            {
                this.player.Draw(spriteBatch);
            }
            else if (this.player.Ball.BallTimer.Elapsed.TotalSeconds > CannonBall.DefaultBallTimer)
            {
                this.player.Ball.BallInitialised = false;
                this.player.Ball.BallFired = false;
                this.player.Ball.BallTimer.Stop();
                this.player.Ball.BallTimer.Reset();
            }
        }
        
        //TODO make a local variable of PlayerTypes
        private void PlayerBallControls(GameTime gameTime)
        {
            IPlayer instance;
            Keys controls;

            switch (this.type)
            {
                case PlayerTypes.FirstPlayer:
                    this.player.Ball.BallFiredPos = new Vector2(FirstPlayer.Instance.Ship.Position.X + FirstPlayer.Instance.ShipImage.Texture.Width, FirstPlayer.Instance.Ship.Position.Y + FirstPlayer.Instance.ShipImage.Texture.Height / 2f);
                    instance = FirstPlayer.Instance;
                    controls = Keys.LeftControl;
                    break;
                case PlayerTypes.SecondPlayer:
                    this.player.Ball.BallFiredPos = new Vector2(SecondPlayer.Instance.Ship.Position.X - SecondPlayer.Instance.ShipImage.Texture.Width / 2f, SecondPlayer.Instance.Ship.Position.Y + (SecondPlayer.Instance.ShipImage.Texture.Height / 2f));
                    instance = SecondPlayer.Instance;
                    controls = Keys.RightControl;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(this.type), this.type, null);
            }

            if (instance != null && instance.InputManagerInstance.KeyDown(controls))
            {
                this.player.Ball.BallFired = true;
                this.player.Ball.BallTimer.Start();

                if (!this.player.Ball.BallInitialised)
                {
                    this.player.Ball.FireFlashCounter = 0;
                    this.player.Ball.Initialise();
                    this.player.Ball.BallInitialised = true;
                }
            }

            if (this.player.Ball.BallFired)
            {
                this.player.Ball.Update(gameTime);
            }
        }
    }
}