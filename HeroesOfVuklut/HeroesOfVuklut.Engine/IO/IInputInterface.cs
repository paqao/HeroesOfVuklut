namespace HeroesOfVuklut.Engine.IO
{
    public interface IInputInterface
    {
        bool CheckInputDown(string key);

        bool IsClick(string key);

        CursorPosition GetCursor();

    }

    public interface CursorPosition
    {
        int PositionX { get; }
        int PositionY { get; }
    }
}
