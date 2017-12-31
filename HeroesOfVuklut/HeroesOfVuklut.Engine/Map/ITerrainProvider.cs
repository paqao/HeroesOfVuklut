namespace HeroesOfVuklut.Engine.Map
{
    public interface ITerrainProvider<T> where T : IMapItem
    {
        T GetTemplate(int type);
    }
}
