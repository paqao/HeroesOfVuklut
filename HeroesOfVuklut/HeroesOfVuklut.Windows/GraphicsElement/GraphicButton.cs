using HeroesOfVuklut.Engine.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfVuklut.Windows.GraphicsElement
{
    public class GraphicButton : IGraphicButton
    {
        public int ItemWidth { get; set; }
        public int ItemHeight { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public bool IsOver(CursorPosition position)
        {
            bool passX = (position.PositionX <= X + ItemWidth && position.PositionX >= X);
            bool passY = (position.PositionY <= Y + ItemHeight && position.PositionY >= Y);

            return passX && passY;
        }
    }
}
