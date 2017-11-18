using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Context
{
    public interface IOwned<T>
    {
        T OwnedBy { get; set; }
    }
}
