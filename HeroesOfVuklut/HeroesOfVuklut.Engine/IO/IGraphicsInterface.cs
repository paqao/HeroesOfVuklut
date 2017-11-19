namespace HeroesOfVuklut.Engine.IO
{
    public interface IGraphicsInterface
    {
        void Draw(int x, int y, int w, int h, string resourceKey);
        void Draw(int x, int y, int w, int h, string resourceKey, string frame);

        void DrawText(int x, int y, string text);
        void DrawCircle(int x, int y);
    }
}
