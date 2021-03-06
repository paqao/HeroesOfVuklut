﻿using HeroesOfVuklut.Engine.Map.Nodes;
using System.Collections.Generic;

namespace HeroesOfVuklut.Engine.Map.TiledMap
{
    public class TiledMapBase<T,U, V, W> : MapBase 
        where T : TiledMapTileBase<U>
        where U : TiledMapItemBase
        where V : MapNodeBase<V, T, W>
        where W : MapNodeConnectionBase<V>
    {
        public readonly int Width;
        public readonly int Height;

        public T[][] Tiles { get; }
        public ICollection<V> MapNodes { get; }
        public ICollection<W> Connections { get; }

        public TiledMapBase(string name, int width, int height): base(name)
        {
            Width = width;
            Height = height;

            Tiles = new T[height][];
            MapNodes = new List<V>();
            Connections = new List<W>();

            for (int j = 0;j < height; j++) 
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
