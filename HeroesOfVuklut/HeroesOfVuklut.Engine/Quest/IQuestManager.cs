using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Quest
{
    public interface IQuestManager<T> where T : IMission
    {
        ICollection<T> GetAllMissions();
    }
}
