using HeroesOfVuklut.Engine.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfVuklut.Windows.GraphicsElement
{
    public class RoundGraphicButton : IGraphicButton
    {
        public int Radius { get; set; }
        public int ItemWidth { get { return Radius; } set { Radius = value; } }
        public int ItemHeight { get { return Radius; } set { Radius = value; } }
        public int X { get; set; }
        public int Y { get; set; }

        public bool IsOver(CursorPosition position)
        {
            int disX = position.PositionX - X;
            int disY = position.PositionY - Y;

            long dis = disX * disX + disY * disY;

            return dis <= Radius * Radius;
        }
    }
}
