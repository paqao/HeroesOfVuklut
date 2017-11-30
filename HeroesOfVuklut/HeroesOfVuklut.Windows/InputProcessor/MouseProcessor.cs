using HeroesOfVuklut.Engine.IO;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfVuklut.Windows.InputProcessor
{
    public enum MouseKeys
    {
        Left,
        Right
    }

    public interface MouseProcessor : IInputProcessor
    {
        void Refresh(MouseState state);

        void Register(string key, MouseKeys keys);

        int MousePositionX { get; }
        int MousePositionY { get; }
    }

    public class MouseProcessorImpl : MouseProcessor
    {
        public MouseProcessorImpl()
        {
            buttons = new List<ButtonStateItem>();
            actions = new Dictionary<string, MouseKeys>();
        }
        ICollection<ButtonStateItem> buttons;
        IDictionary<string, MouseKeys> actions;

        public int MousePositionX { get; private set; }
        public int MousePositionY { get; private set; }

        public InputStateItem GetButton(string key)
        {
            return buttons.FirstOrDefault(x => x.Key == key);
        }

        public ButtonStateValue GetButtonState(string key)
        {
            return buttons.FirstOrDefault(x => x.Key == key).ButtonState;
        }

        public void Refresh(MouseState state)
        {
            MousePositionX = state.X;
            MousePositionY = state.Y;

            foreach (var button in buttons)
            {
                var input = actions[button.Key];
                var previous = button.ButtonState;

                ButtonState processedButton = default(ButtonState);

                if (input == MouseKeys.Left)
                {
                    processedButton = state.LeftButton;
                }
                else if(input == MouseKeys.Right)
                {
                    processedButton = state.RightButton;
                }

                var newState = ButtonStateValue.NotFound;


                if (processedButton == ButtonState.Pressed)
                {
                    if (previous == ButtonStateValue.OnHold || previous == ButtonStateValue.OnClick)
                    {
                        newState = ButtonStateValue.OnHold;
                    }
                    else
                    {
                        newState = ButtonStateValue.OnClick;
                    }
                }
                else
                {
                    if (previous == ButtonStateValue.OnRelease || previous == ButtonStateValue.OnReleased)
                    {
                        newState = ButtonStateValue.OnReleased;
                    }
                    else
                    {
                        newState = ButtonStateValue.OnRelease;
                    }
                }
                // bothDown


                button.ButtonState = newState;
            }
        }

        public void Register(string action, MouseKeys keys)
        {
            var buttonState = new ButtonStateItem(action);

            actions[action] = keys;
            buttons.Add(buttonState);
        }
    }
}
