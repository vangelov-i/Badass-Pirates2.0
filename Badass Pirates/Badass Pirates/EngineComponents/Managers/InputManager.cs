namespace Badass_Pirates.EngineComponents
{
    #region

    using System.Linq;

    using Microsoft.Xna.Framework.Input;

    #endregion

    public class InputManager
    {
        private static InputManager instance;

        private KeyboardState currentState;

        private KeyboardState prevState;

        public static InputManager Instance => instance ?? (instance = new InputManager());

        public void Update()
        {
            this.prevState = this.currentState;
            if (this.prevState == null)
            {
                this.currentState = Keyboard.GetState();
            }
        }

        public bool KeyPressed(params Keys[] keys)
        {
            return keys.Any(key => this.currentState.IsKeyDown(key) && this.prevState.IsKeyUp(key));
        }

        public bool KeyDown(params Keys[] keys)
        {
            return keys.Any(key => this.currentState.IsKeyUp(key) && this.prevState.IsKeyDown(key));
        }

        public bool KeyReleased(params Keys[] keys)
        {
            return keys.Any(key => this.currentState.IsKeyDown(key));
        }
    }
}