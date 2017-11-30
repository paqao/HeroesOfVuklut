using Microsoft.Xna.Framework.Input;

namespace HeroesOfVuklut.Engine.IO
{
    public class ButtonStateItem : InputStateItem
    {
        public string Key { get; }
        public ButtonStateValue ButtonState { get; set; }

        public ButtonStateItem(string key) : base(InputStateType.Functional, key)
        {
            Key = key;
        }
    }

    public class KeyboardStateItem : InputStateItem
    {
        private readonly Keys _key;

        public KeyboardStateItem(Keys key) : base(InputStateType.Character, key)
        {
            _key = key;
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
