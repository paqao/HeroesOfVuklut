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
}
