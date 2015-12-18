using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badass_Pirates.Interfaces
{
    using System.Xml.Serialization;

    using Microsoft.Xna.Framework;

    interface IXnaDependencies
    {
        void Initialise();

        void LoadContent();

        void UnloadContent();

        void Update(GameTime gameTime);

        void Draw();
    }
}
