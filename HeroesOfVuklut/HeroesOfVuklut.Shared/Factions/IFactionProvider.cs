using HeroesOfVuklut.Engine.Configuration;
using System.Collections.Generic;

namespace HeroesOfVuklut.Shared.Factions
{
    public interface IFactionProvider : IConfigurationProvider
    {
        ICollection<FactionAspect> AllFactions { get; }
    }
}
