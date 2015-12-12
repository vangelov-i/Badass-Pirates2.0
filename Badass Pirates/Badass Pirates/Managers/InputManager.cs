namespace Badass_Pirates.EngineComponents.Managers
{
    #region

    using System.Linq;

    using Microsoft.Xna.Framework.Input;

    #endregion

    public class InputManager
    {
        private KeyboardState currentState;

        private KeyboardState prevState;

        //public static InputManager Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new InputManager();
        //        }

        //        return instance;
        //    }
        //} // => instance ?? (instance = new InputManager());

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
            //return this.currentState.IsKeyDown(keys) && this.prevState.IsKeyUp(keys);
        }

        public bool KeyDown(params Keys[] keys)
        {
            return keys.Any(key => this.currentState.IsKeyDown(key));
            //return this.currentState.IsKeyDown(keys);
        }

        public bool KeyReleased(params Keys[] keys)
        {
            return keys.Any(key => this.currentState.IsKeyUp(key) && this.prevState.IsKeyDown(key));
            //return this.currentState.IsKeyUp(keys) && this.prevState.IsKeyDown(keys);
        }
    }
}