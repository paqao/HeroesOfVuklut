using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Game
{
    public interface ISettingsManager<T> where T : IGameSettings
    {
        T GetSettings();

        void UpdateSettings();
    }
}
