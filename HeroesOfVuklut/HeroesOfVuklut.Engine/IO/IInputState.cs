using System.Collections.Generic;

namespace HeroesOfVuklut.Engine.IO
{
    public class InputStateItem
    {
        public InputStateType Type { get; set; }
        public object State { get; set; }

        public InputStateItem(InputStateType item, object state)
        {
            Type = item;
            State = state;
        }
    }

    public class InputState
    {
        ICollection<InputStateItem> InputStates { get; set; }
        CursorPosition CursorPosition { get; set; }
    }

    public enum InputStateType
    {
        Mouse,
        Numeric,
        Character,
        Functional
    }

    public enum StateParameter
    {
        Click,
        Hold,
        Release
    }
}
