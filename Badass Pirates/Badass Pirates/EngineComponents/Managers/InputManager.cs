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
        }//=> instance ?? (instance = new InputManager());

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
            // return keys.Any(key => this.currentState.IsKeyDown(key) && this.prevState.IsKeyUp(key));
            return this.currentState.IsKeyDown(keys) && this.prevState.IsKeyUp(keys);
        }

        public bool KeyDown(Keys keys)
        {
            // return keys.Any(key => this.currentState.IsKeyDown(key));
            return this.currentState.IsKeyDown(keys);

        }

        public bool KeyReleased(Keys keys)
        {
            // return keys.Any(key => this.currentState.IsKeyUp(key) && this.prevState.IsKeyDown(key));
            return this.currentState.IsKeyUp(keys) && this.prevState.IsKeyDown(keys);
        }
    }
}