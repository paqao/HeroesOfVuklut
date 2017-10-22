using HeroesOfVuklut.Shared.Input;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfVuklut.Windows.InputProcessor
{
    public interface KeyboardProcessor : IInputProcessor
    {
        ButtonStateValue GetButtonState(string key);
        Shared.Input.ButtonState GetButton(string key);
        void RegisterKey(string key, Keys keyboard);
        void Refresh(KeyboardState state);
    }

    public class KeyboardProcessorImpl : KeyboardProcessor
    {
        public KeyboardProcessorImpl()
        {
            buttons = new List<Shared.Input.ButtonState>();
            actions = new Dictionary<string,Keys>();
        }
        ICollection<Shared.Input.ButtonState> buttons;
        IDictionary<string, Keys> actions;

        public Shared.Input.ButtonState GetButton(string key)
        {
            return buttons.First(x => x.Key == key);
        }

        public ButtonStateValue GetButtonState(string key)
        {
            return GetButton(key).State;
        }

        public void Refresh(KeyboardState state)
        {
            foreach (var button in buttons)
            {
                var input = actions[button.Key];
                var previous = button.State;

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
               


                button.State = newState;
            }
        }

        public void RegisterKey(string action, Keys keyboard)
        {
            var buttonState = new Shared.Input.ButtonState(action);

            actions[action] = keyboard;
            buttons.Add(buttonState);
        }
    }
}
