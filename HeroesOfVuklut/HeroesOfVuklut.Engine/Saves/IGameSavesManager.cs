using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Saves
{
    public interface IGameSavesManager<T> where T : ISaveGameInfo
    {
        ICollection<T> GetAllSaves();

        bool HasSave();
    }
}
