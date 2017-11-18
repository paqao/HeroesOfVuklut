using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Map
{
    public abstract class MapBase
    {
        public MapBase(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
