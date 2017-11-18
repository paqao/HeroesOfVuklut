using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Map.TiledMap
{
    public class TiledMapBase<T,U> : MapBase where T : TiledMapTileBase<U>
        where U : TiledMapItemBase
    {
        public readonly int Width;
        public readonly int Height;

        public T[][] Tiles { get; }
        public TiledMapBase(string name, int width, int height): base(name)
        {
            Width = width;
            Height = height;

            Tiles = new T[height][];

            for(int j = 0;j < height; j++) 
            {
                Tiles[j] = new T[width];
            }
        }

        public T GetTile(int x, int y)
        {
            if(x <= Width && x >= 0 && y <= Height && y >= 0)
            {
                return Tiles[y][x];
            }
            return null;
        }
    }
}
