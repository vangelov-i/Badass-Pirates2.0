﻿using System;

namespace Badass_Pirates
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for Badass Pirates.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            using (var game = new MainEngine())
                game.Run();
        }
    }
#endif
}
