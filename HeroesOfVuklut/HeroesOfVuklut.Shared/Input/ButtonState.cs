using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Input
{
    public class ButtonState : IState
    {
        public string Key { get; }
        public ButtonStateValue State { get; set; }

        public ButtonState(string key)
        {
            Key = key;
        }
    }

    public enum ButtonStateValue
    {
        NotFound = 0,
        OnReleased = 2,
        OnRelease = 3,
        OnHold = 4,
        OnClick = 5
    }
}
