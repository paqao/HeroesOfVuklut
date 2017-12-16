using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfVuklut.Windows.Maps
{
    internal class MapInfo
    {
        public string Name
        {
            get; set;
        }

        public int Id { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public IList<MapInfoTile> Tiles { get; set; }
        = new List<MapInfoTile>();

        public IList<TilePath> Paths { get; set; }
        = new List<TilePath>();


        public IList<TileNode> Nodes { get; set; }
        = new List<TileNode>();
    }

    internal class MapInfoTile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int GroundId { get; set; }
        public TileItem Item { get; set; }
    }

    internal class TileItem
    {
        public int Type { get; set; }
        public int SubType { get; set; }

        public Dictionary<string,string> Parameters { get; set; }
    }

    internal class TileNode
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }

    internal class TilePath
    {
        public int Id { get; set; }
        public int End1Id { get; set; }
        public int End2Id { get; set; }
        public bool Unlocked { get; set; } = true;
    }
}
