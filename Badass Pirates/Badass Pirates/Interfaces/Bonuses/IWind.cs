using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badass_Pirates.Interfaces.Bonuses
{
    using System.Diagnostics;

    interface IWind
    {
        Stopwatch WindTimeOut { get; set; }

        void Wind();

        void UnWind();
    }
}
