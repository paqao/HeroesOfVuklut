using HeroesOfVuklut.Shared.Input;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfVuklut.Windows.InputProcessor
{
    public interface MouseProcessor : IInputProcessor
    {
        ButtonStateValue GetButtonState(string key);
        Shared.Input.ButtonState GetButton(string key);
        void Refresh(MouseState state);

        int MousePositionX { get; }
        int MousePositionY { get; }
    }

    public class MouseProcessorImpl : MouseProcessor
    {
        public int MousePositionX { get; private set; }
        public int MousePositionY { get; private set; }

        public Shared.Input.ButtonState GetButton(string key)
        {
            return null;
        }

        public ButtonStateValue GetButtonState(string key)
        {
            return ButtonStateValue.NotFound;
        }

        public void Refresh(MouseState state)
        {
            MousePositionX = state.X;
            MousePositionY = state.Y;
        }
        
    }
}
