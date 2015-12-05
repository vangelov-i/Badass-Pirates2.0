namespace Badass_Pirates.EngineComponents.Managers
{
    #region

    using Microsoft.Xna.Framework.Input;

    #endregion

    public class InputManager
    {
        private static InputManager instance;

        private KeyboardState currentState;

        private KeyboardState prevState;

        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputManager();
                }

                return instance;
            }
        } // => instance ?? (instance = new InputManager());

        public void Update()
        {
            this.currentState = Keyboard.GetState();
        }

        public void RotateStates()
        {
            this.prevState = this.currentState;
        }

        public bool KeyPressed(Keys keys)
        {
            return this.currentState.IsKeyDown(keys) && this.prevState.IsKeyUp(keys);
        }

        public bool KeyDown(Keys keys)
        {
            return this.currentState.IsKeyDown(keys);
        }

        public bool KeyReleased(Keys keys)
        {
            return this.currentState.IsKeyUp(keys) && this.prevState.IsKeyDown(keys);
        }
    }
}