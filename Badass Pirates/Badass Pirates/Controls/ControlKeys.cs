namespace Badass_Pirates.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Badass_Pirates.Enums;
    using Badass_Pirates.Interfaces;

    using Microsoft.Xna.Framework.Input;

    public class ControlKeys : IKeysLibrary
    {
        private static Dictionary<string, Keys> firstPlayersControlers = new Dictionary<string, Keys>()
                                                                        {
            {"Up", Keys.W},
            {"Right", Keys.D },
            {"Left", Keys.A },
            {"Down", Keys.S }
                                                                        };

        private static Dictionary<string, Keys> secondPlayersControlers = new Dictionary<string, Keys>()
                                                                        {
            {"Up", Keys.Up},
            {"Right", Keys.Right },
            {"Left", Keys.Left },
            {"Down", Keys.Down }
                                                                        };

        private static ControlKeys instance;

        public static ControlKeys Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ControlKeys();
                }

                return instance;
            }
        }
        
        public Dictionary<string, Keys> SecondPlayersControlers
        {
            get
            {
                return secondPlayersControlers;
            }
            set
            {
                secondPlayersControlers = value;
            }
        }

        public Dictionary<string, Keys> FirstPlayersControlers
        {
            get
            {
                return firstPlayersControlers;
            }
            set
            {
                firstPlayersControlers = value;
            }
        }
      
        public Keys GetKey(PlayerTypes type,string key)
        {
            switch (type)
            {
                    case PlayerTypes.FirstPlayer:
                    if (ControlKeys.Instance.FirstPlayersControlers.Any(firstPlayersControler => ControlKeys.Instance.FirstPlayersControlers.ContainsKey(key)))
                    {
                        return ControlKeys.Instance.FirstPlayersControlers[key];
                    }

                    break;

                    case PlayerTypes.SecondPlayer:
                    if (ControlKeys.Instance.SecondPlayersControlers.Any(secondPlayersControler => ControlKeys.Instance.SecondPlayersControlers.ContainsKey(key)));
                    {
                        return ControlKeys.Instance.SecondPlayersControlers[key];
                    }
                //default:
                //    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return default(Keys);
        }
    }
}
