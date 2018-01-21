using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.Game;

namespace HeroesOfVuklut.Shared.Settings
{
    [ServiceInject(typeof(GameSettingsManager), typeof(ISettingsManager<GameSettings>))]
    public class GameSettingsManager : JSonSettingsManager<GameSettings>
    {
    }
}
