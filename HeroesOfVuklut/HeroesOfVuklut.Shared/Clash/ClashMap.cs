using HeroesOfVuklut.Engine.Map.TiledMap;
using HeroesOfVuklut.Shared.Clash.MapItems;
using HeroesOfVuklut.Shared.Clash.Path;
using System.Collections.Generic;

namespace HeroesOfVuklut.Shared.Clash
{
    public class ClashMap : TiledMapBase<ClashTile, ClashTileItem, ClashPathNode, ClashMapNodeConnection>
    {
        public List<ClashRegion> Regions { get; private set; }
        public IList<ClashBuilding> Buildings { get; protected set; }

        public ClashMap(string name, int w, int h) : base(name, w,h)
        {
            Regions = new List<ClashRegion>();
            Buildings = new List<ClashBuilding>();
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    Tiles[i][j] = new ClashTile(i, j, 0);
                }
            }
        }
    }

}

