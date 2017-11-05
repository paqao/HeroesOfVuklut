using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash
{
    public interface IMapProvider
    {
        ClashMap GetMapByName(string name);
    }
}
