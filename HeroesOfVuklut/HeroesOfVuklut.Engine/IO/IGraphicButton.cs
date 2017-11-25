using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.IO
{
    public interface IGraphicButton : IGraphicElement
    {
        int ItemWidth { get; set; }
        int ItemHeight { get; set; }

        bool IsOver(CursorPosition position);
    }

}
