using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Map.TiledMap
{
    public abstract class TiledMapItemBase : IMapItem
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
