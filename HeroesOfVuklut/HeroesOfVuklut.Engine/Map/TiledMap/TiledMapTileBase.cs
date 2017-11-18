using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Map.TiledMap
{
    public abstract class TiledMapTileBase<T> where T : TiledMapItemBase
    {
        protected TiledMapTileBase(int x, int y, int groundId)
        {
            X = x;
            Y = y;
            GroundId = groundId;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public int GroundId { get; set; }
        public T Item { get; set; }
    }
}
