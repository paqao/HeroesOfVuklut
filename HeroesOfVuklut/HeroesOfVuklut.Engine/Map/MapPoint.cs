namespace HeroesOfVuklut.Engine.Map
{
    public class MapPoint
    {
        public MapPoint(int x, int y) { X = x; Y = y; }
        public int X { get; protected set; }
        public int Y { get; protected set; }
    }
}
