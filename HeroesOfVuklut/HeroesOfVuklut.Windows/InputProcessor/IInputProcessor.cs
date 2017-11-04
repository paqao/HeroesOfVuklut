using HeroesOfVuklut.Shared.Input;

namespace HeroesOfVuklut.Windows.InputProcessor
{
    public interface IInputProcessor
    {
        ButtonStateValue GetButtonState(string key);
        ButtonState GetButton(string key);
    }
}
