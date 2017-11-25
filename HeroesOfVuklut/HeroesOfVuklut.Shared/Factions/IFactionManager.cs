using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Factions
{
    public interface IFactionManager
    {
        ICollection<FactionAspect> GetAllFactions();
    }
}
