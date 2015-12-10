﻿namespace Badass_Pirates.Interfaces.Bonuses
{
    using System.Diagnostics;

    using Badass_Pirates.GameObjects.Ships;

    public interface IFreeze
    {
        Stopwatch FreezTimeOut { get; set; }

        void Freeze();

        void DeFrost();
    }
}
