using HeroesOfVuklut.Shared.Clash.MapItems;
using System.Collections.Generic;

namespace HeroesOfVuklut.Shared.Clash
{
    public class ClashMap
    {
        public ClashTile[][] Tiles { get; private set; }
        public List<ClashRegion> Regions { get; private set; }
        public IList<ClashBuilding> Buildings { get; protected set; }
        public int Width { get; private set; }
        public int Heigth { get; private set; }

        public ClashMap(int w, int h)
        {
            Width = w;
            Heigth = h;
            Tiles = new ClashTile[h][];
            Regions = new List<ClashRegion>();
            Buildings = new List<ClashBuilding>();
            for (int i = 0; i < h; i++)
            {
                Tiles[i] = new ClashTile[w];
                for (int j = 0; j < w; j++)
                {
                    Tiles[i][j] = new ClashTile(i, j, 0);

                    
                }
            }


        }
    }

}

