
using HeroesOfVuklut.Engine.Configuration;

namespace HeroesOfVuklut.Shared.Clash
{
    public interface IMapProvider : IConfiguralable<IGameConfiguration>
    {
        ClashMap GetMapByName(string name);
        ClashMap GetMapById(int id);
    }
}
