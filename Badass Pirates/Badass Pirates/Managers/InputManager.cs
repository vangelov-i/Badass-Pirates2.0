namespace Badass_Pirates.Managers
{
    #region

    using System.Linq;

    using Microsoft.Xna.Framework.Input;

    #endregion
    // TODO ЧИСТИЧЪК И СПРЕТНАТ (евентуално,могат да се поразгледат методите KeyPressed & KeyReleased)
    public class InputManager
    {
        private KeyboardState currentState;

        private KeyboardState prevState;

        public void Update()
        {
            this.currentState = Keyboard.GetState();
        }

        public void RotateStates()
        {
            this.prevState = this.currentState;
        }

        public bool KeyPressed(params Keys[] keys)
        {
            return keys.Any(key => this.currentState.IsKeyDown(key) && this.prevState.IsKeyUp(key));
        }

        public bool KeyDown(params Keys[] keys)
        {
            return keys.Any(key => this.currentState.IsKeyDown(key));
        }

        public bool KeyReleased(params Keys[] keys)
        {
            return keys.Any(key => this.currentState.IsKeyUp(key) && this.prevState.IsKeyDown(key));
        }
    }
}