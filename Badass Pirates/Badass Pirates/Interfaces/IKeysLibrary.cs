namespace Badass_Pirates.Interfaces
{
    using System.Collections.Generic;

    using Badass_Pirates.Enums;

    using Microsoft.Xna.Framework.Input;

    public interface IKeysLibrary
    {
        Dictionary<string, Keys> FirstPlayersControlers { get; set; }

        Dictionary<string, Keys> SecondPlayersControlers { get; set; }

        Keys GetKey(PlayerTypes type, string key);
    }
}
