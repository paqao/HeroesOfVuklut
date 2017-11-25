using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared
{
    [ServiceInject(typeof(GameManager), typeof(GameManagerBase<GameData, GameSettings>))]
    public class GameManager : GameManagerBase<GameData, GameSettings>
    {
    }
}
