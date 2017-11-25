using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Context
{
    public interface IGameDataBased<T>
    {
        void SetGameData(T gameData);
    }
}
