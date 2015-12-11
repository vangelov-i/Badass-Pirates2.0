using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Badass_Pirates.EngineComponents.Objects.Specialties
{
    using Badass_Pirates.Enums;
    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DMine : Specialty, IShoot
    {
        #region IShoot fields
        private const int DAMAGE = 45;

        private const string PATH = "Specialties/seamineResized";
        
        private readonly Vector2 defaultInitPos = new Vector2(900,900);

        private static readonly Point FRAMESIZE = new Point(64, 63);

        private Vector2 ballRangeX;

        private bool mineFired;

        private bool mineInitialised;

        private Vector2 mineFiredPos;

        private Vector2 mineRangeX;
        
        private float heightMax;

        private bool flipper;

        private int counter;

        #endregion

        #region Constructor
        
        public DMine()
            : base(PATH, FRAMESIZE, DAMAGE)
        {
        }
        #endregion

        #region Properties
        
        public bool MineFired
        {
            get
            {
                return this.mineFired;
            }
            set
            {
                this.mineFired = value;
            }
        }
        
        public bool MineInitialised
        {
            get
            {
                return this.mineInitialised;
            }
            set
            {
                this.mineInitialised = value;
            }
        }

        public Vector2 MineFiredPos
        {
            get
            {
                return this.mineFiredPos;
            }
            set
            {
                this.mineFiredPos = value;
            }
        }

        public Vector2 MineRangeX
        {
            get
            {
                return this.mineRangeX;
            }
            set
            {
                this.mineRangeX = value;
            }
        }
        
        public Vector2 PositionMine
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

        public float HeightMax
        {
            get
            {
                return this.heightMax;
            }
            set
            {
                this.heightMax = value;
            }
        }

        public bool Flipper
        {
            get
            {
                return this.flipper;
            }
            set
            {
                this.flipper = value;
            }
        }

        public int Counter
        {
            get
            {
                return this.counter;
            }
            set
            {
                this.counter = value;
            }
        }

        public Vector2 BallRangeX
        {
            get
            {
                return this.ballRangeX;
            }
            set
            {
                this.ballRangeX = value;
            }
        }

        #endregion

        #region IShoot Methods
        public void SetPosition(CoordsDirections coordsDirections, float value)
        {
        }

        public void Initialise(Vector2 pos, PlayerTypes type)
        {
            this.position = pos;
            this.heightMax = pos.Y - 50;
            this.counter = 0;
            this.flipper = false;
        }

        public void UpdateFirst(GameTime gameTime)
        {
            this.position.X += 14;
            if (!this.flipper && this.position.Y > this.heightMax + 100)
            {
                this.position.Y -= 5;
            }
            else if (!this.flipper && this.position.Y > this.heightMax)
            {
                this.position.Y -= 2;
            }
            else if (!this.flipper)
            {
                this.flipper = true;
                this.position.Y += 2;
            }
            else if (this.counter < 8)
            {
                this.counter++;
            }
            else if (this.flipper && this.position.Y > this.heightMax + 100)
            {
                this.position.Y += 2;
            }
            else
            {
                this.position.Y += 5;
            }
        }

        public void UpdateSecond(GameTime gameTime)
        {
            this.position.X -= 13;
            if (!this.flipper && this.position.Y > this.heightMax + 100)
            {
                this.position.Y -= 5; //-=10
            }
            else if (!this.flipper && this.position.Y > this.heightMax)
            {
                this.position.Y -= 2; // -= 4
            }
            else if (!this.flipper)
            {
                this.flipper = true;
                this.position.Y += 2; // +=4
            }
            else if (this.counter < 8)
            {
                this.counter++;
            }
            else if (this.flipper && this.position.Y > this.heightMax + 100)
            {
                this.position.Y += 2; // +=4
            }
            else
            {
                this.position.Y += 5; // += 10
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Image.Texture, this.position);
        }

        public void SetPositionRangeX(float value)
        {
            this.ballRangeX.X = value;
        }
        #endregion
    }
}
