namespace HeroesOfVuklut.Engine.Configuration
{
    public interface IConfiguralable<in T>
    {
        void SetConfiguration(T configuration);
    }
}
