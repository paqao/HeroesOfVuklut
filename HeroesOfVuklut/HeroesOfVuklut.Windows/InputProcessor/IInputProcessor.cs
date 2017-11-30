using HeroesOfVuklut.Engine.IO;

namespace HeroesOfVuklut.Windows.InputProcessor
{
    public interface IInputProcessor
    {
        ButtonStateValue GetButtonState(string key);
        InputStateItem GetButton(string key);
    }
}
