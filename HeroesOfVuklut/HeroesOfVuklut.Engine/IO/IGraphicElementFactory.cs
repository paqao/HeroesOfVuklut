using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.IO
{
    public interface IGraphicElementFactory
    {
        IListElement<T> CreateListElement<T>() where T : class;
    }
}
