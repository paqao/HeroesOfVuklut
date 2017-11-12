using HeroesOfVuklut.Engine.Configuration;

namespace HeroesOfVuklut.Shared.Factions
{
    public interface IFactionProvider : IConfigurationProvider
    {
        FactionAspect GetFaction(int id);
    }
}
