//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Badass_Pirates.EngineComponents.Controls
//{
//    using System.Runtime.CompilerServices;

//    using Badass_Pirates.EngineComponents.Managers;
//    using Badass_Pirates.EngineComponents.Objects.Specialties;
//    using Badass_Pirates.GameObjects.Players;

//    using Microsoft.Xna.Framework;
//    using Microsoft.Xna.Framework.Graphics;
//    using Microsoft.Xna.Framework.Input;

//    public class MineControls : BallControls
//    {
//        public static PlayerTypes typeOf;
        
//        public static void Initialise()
//        {
//            MineControls.ballFirst = new Mine();
//            MineControls.ballSecond = new Mine();
//        }

//        public static void MineBallControls(
//            PlayerTypes type,
//            Player currentPlayer,
//            Image shipImage,
//            GameTime gameTime)
//        {
//            switch (type)
//            {
//                case PlayerTypes.FirstPlayer:
//                    MineControls.FirstPlayerBallControls(currentPlayer, shipImage, gameTime);
//                    typeOf = PlayerTypes.FirstPlayer;
//                    break;
//                case PlayerTypes.SecondPlayer:
//                    MineControls.SecondPlayerBallControls(currentPlayer, shipImage, gameTime);
//                    typeOf = PlayerTypes.SecondPlayer;
//                    break;
//            }
//        }

//        public static void MineBallDraw(
//            PlayerTypes type,
//            SpriteBatch spriteBatch,
//            Player currentPlayer,
//            Image shipImage)
//        {
//            switch (type)
//            {
//                case PlayerTypes.FirstPlayer:
//                    MineControls.FirstPlayerBallDraw(spriteBatch, currentPlayer, shipImage);
//                    typeOf = PlayerTypes.FirstPlayer;
//                    break;
//                case PlayerTypes.SecondPlayer:
//                    MineControls.SecondPlayerBallDraw(spriteBatch, currentPlayer, shipImage);
//                    typeOf = PlayerTypes.SecondPlayer;
//                    break;
//            }
//        }

//        private static void FirstPlayerBallControls(GameObjects.Players.Player currentPlayer, Image shipImage, GameTime gameTime)
//        {
//            if (currentPlayer.InputManagerInstance.KeyDown(Keys.F1))
//            {
//                MineControls.ballFirst.BallFired = true;

//                if (!MineControls.ballFirst.BallInitialised)
//                {
//                    MineControls.ballFirst.FireFlashCounter = 0;
//                    MineControls.ballFirst.Initialise(
//                        MineControls.ballFirst.BallFiredPos =
//                        new Vector2(
//                            currentPlayer.Ship.Position.X + shipImage.Texture.Width,
//                            currentPlayer.Ship.Position.Y + (shipImage.Texture.Height / 2f)),
//                        currentPlayer.TypeOfPlayer);
//                    MineControls.ballFirst.BallInitialised = true;
//                }

//            }

//            if (MineControls.ballFirst.BallFired)
//            {
//                MineControls.ballFirst.UpdateFirst(gameTime);
//            }
//        }

//        private static void SecondPlayerBallControls(GameObjects.Players.Player currentPlayer, Image shipImage, GameTime gameTime)
//        {
//            if (currentPlayer.InputManagerInstance.KeyDown(Keys.F2))
//            {
//                MineControls.ballSecond.BallFired = true;

//                if (!ballSecond.BallInitialised)
//                {
//                    MineControls.ballSecond.FireFlashCounter = 0;
//                    MineControls.ballSecond.Initialise(
//                        MineControls.ballSecond.BallFiredPos =
//                        new Vector2(
//                            currentPlayer.Ship.Position.X - shipImage.Texture.Width / 2f,
//                            currentPlayer.Ship.Position.Y + (shipImage.Texture.Height / 2f)),
//                        currentPlayer.TypeOfPlayer);
//                    MineControls.ballSecond.BallInitialised = true;
//                }

//            }

//            if (MineControls.ballSecond.BallFired)
//            {
//                MineControls.ballSecond.UpdateSecond(gameTime);
//            }

//        }

//        private static void FirstPlayerBallDraw(SpriteBatch spriteBatch, Player currentPlayer, Image shipImage)
//        {
//            if (MineControls.ballFirst.BallFired && ballFirst.FireFlashCounter < 15)
//            {
//                MineControls.ballFirst.Fire.Draw(
//                    spriteBatch,
//                    new Vector2(
//                        currentPlayer.Ship.Position.X + shipImage.Texture.Width,
//                        currentPlayer.Ship.Position.Y + (shipImage.Texture.Height * 0.6f)
//                        - (MineControls.ballFirst.Fire.Texture.Height / 2f)));
//                MineControls.ballFirst.FireFlashCounter++;
//            }

//            if (MineControls.ballFirst.BallFired)
//            {
//                MineControls.ballFirst.SetPositionRangeX(
//                    (MineControls.ballFirst.BallFiredPos.X + (ScreenManager.Instance.Dimensions.X / 2) - shipImage.Texture.Width));

//                if (MineControls.ballFirst.Position.Y < MineControls.ballFirst.BallFiredPos.Y) // ballFirst.Position.X < ballFirst.BallRangeX.X
//                {
//                    MineControls.ballFirst.Draw(spriteBatch);
//                }
//                else
//                {
//                    MineControls.ballFirst.BallInitialised = false;
//                    MineControls.ballFirst.BallFired = false;
//                }
//            }

//        }

//        private static void SecondPlayerBallDraw(SpriteBatch spriteBatch, Player currentPlayer, Image shipImage)
//        {
//        }
//    }
//}
