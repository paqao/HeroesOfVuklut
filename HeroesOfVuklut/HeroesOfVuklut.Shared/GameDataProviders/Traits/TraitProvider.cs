using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Shared.Traits;

namespace HeroesOfVuklut.Shared.GameDataProviders.Traits
{
    [ServiceInject(typeof(TraitProvider), typeof(ITraitProvider))]
    public class TraitProvider : ITraitProvider
    {
    }
}
