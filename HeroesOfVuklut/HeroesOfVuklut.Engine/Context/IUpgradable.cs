namespace HeroesOfVuklut.Engine.Context
{
    public interface IUpgradable<T> where T : IContext
    {
        bool CanUpgrade(T context);

        void Upgrade(T context);
    }
}
