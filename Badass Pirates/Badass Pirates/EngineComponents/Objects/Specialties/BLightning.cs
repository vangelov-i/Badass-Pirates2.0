﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badass_Pirates.EngineComponents.Objects.Specialties
{
    using System.Diagnostics;

    using Badass_Pirates.EngineComponents.Managers;
    using Badass_Pirates.EngineComponents.Screens;
    using Badass_Pirates.GameObjects.Players;

    using Microsoft.Xna.Framework;

    public class BLightning : Specialty
    {
        private const string PATH = "Specialties/lightningResized";

        private static readonly Point FRAMESIZE = new Point(250,245);

        private const int LIGHTNING_TIME = 3;

        private const int DAMAGE = 35;

        private Stopwatch lightningTimer;
        
        public BLightning()
            : base(PATH, FRAMESIZE, DAMAGE)
        {
            this.lightningTimer = new Stopwatch();
        }

        public override void ActivateSpecialty(Player currentPlayer) // currentPlayer is the enemy 
        {
            // this position might have bugs when applied to the FirstPlayer
            this.position = new Vector2(currentPlayer.Ship.Position.X - this.image.Texture.Width/2f, currentPlayer.Ship.Position.Y - this.image.Texture.Height);
            this.SpecialtyFired = true;
            this.lightningTimer.Start();
        }

        public override void Update(GameTime gameTime, Player currentPlayer)
        {
            // NEEDS LOTS OF ELEGANCE
            if (currentPlayer is FirstPlayer)
            {
                this.position = new Vector2(TitleScreen.SecondPlayer.CurrentPlayer.Ship.Position.X - this.image.Texture.Width / 2f, TitleScreen.SecondPlayer.CurrentPlayer.Ship.Position.Y - this.image.Texture.Height);
                if (this.lightningTimer.Elapsed.Seconds > LIGHTNING_TIME)
                {
                    currentPlayer.Ship.SpecialtyAttack(TitleScreen.SecondPlayer.CurrentPlayer.Ship);
                }
            }
            else
            {
                this.position = new Vector2(TitleScreen.FirstPlayer.CurrentPlayer.Ship.Position.X + this.image.Texture.Width / 2f, TitleScreen.FirstPlayer.CurrentPlayer.Ship.Position.Y - this.image.Texture.Height);
                if (this.lightningTimer.Elapsed.Seconds > LIGHTNING_TIME)
                {
                    currentPlayer.Ship.SpecialtyAttack(TitleScreen.FirstPlayer.CurrentPlayer.Ship);
                }
            }

            if (this.lightningTimer.Elapsed.Seconds > LIGHTNING_TIME)
            {
                this.SpecialtyFired = false;
                this.lightningTimer.Stop();
                this.lightningTimer.Reset();
            }
        }
    }
}
