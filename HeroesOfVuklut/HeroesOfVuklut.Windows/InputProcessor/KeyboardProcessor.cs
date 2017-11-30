using HeroesOfVuklut.Engine.IO;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfVuklut.Windows.InputProcessor
{
    public interface KeyboardProcessor : IInputProcessor
    {
        void RegisterKey(string key, Keys keyboard);
        void Refresh(KeyboardState state);
    }

    public class KeyboardProcessorImpl : KeyboardProcessor
    {
        public KeyboardProcessorImpl()
        {
            buttons = new List<ButtonStateItem>();
            actions = new Dictionary<string,Keys>();
        }
        ICollection<ButtonStateItem> buttons;
        IDictionary<string, Keys> actions;

        public InputStateItem GetButton(string key)
        {
            return buttons.FirstOrDefault(x => x.Key == key);
        }

        public ButtonStateValue GetButtonState(string key)
        {
            return buttons.FirstOrDefault(x => x.Key == key).ButtonState;
        }

        public void Refresh(KeyboardState state)
        {
            foreach (var button in buttons)
            {
                var input = actions[button.Key];
                var previous = button.ButtonState;

                var down = state.IsKeyDown(input);

                var newState = ButtonStateValue.NotFound;

               
                if (down)
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

        public void RegisterKey(string action, Keys keyboard)
        {
            var buttonState = new ButtonStateItem(action);

            actions[action] = keyboard;
            buttons.Add(buttonState);
        }
    }
}
