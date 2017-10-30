using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared
{
    public interface IInputInterface
    {
        bool CheckInputDown(string key);

        CursorPosition GetCursor();

    }

    public interface CursorPosition
    {
        int PositionX { get; }
        int PositionY { get; }
    }
}
