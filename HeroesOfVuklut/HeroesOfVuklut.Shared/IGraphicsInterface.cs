using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared
{
    public interface IGraphicsInterface
    {
        void Draw(int x, int y, int w, int h, string resourceKey);
    }
}
