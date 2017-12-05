using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Settings
{
    [ServiceInject(typeof(GameSettingsManager), typeof(ISettingsManager<GameSettings>))]
    public class GameSettingsManager : JSonSettingsManager<GameSettings>
    {
    }
}
