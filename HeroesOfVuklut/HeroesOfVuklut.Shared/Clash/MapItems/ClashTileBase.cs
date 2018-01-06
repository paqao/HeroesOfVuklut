using HeroesOfVuklut.Engine.Map;
using HeroesOfVuklut.Engine.Map.TiledMap;

namespace HeroesOfVuklut.Shared.Clash.MapItems
{
    public class ClashTile : TiledMapTileBase<ClashTileItem>, IMapItem
    {
        private bool _isHover;

        public bool Hover { get
            {
                return _isHover;
            }
            set
            {
                if (Item != null)
                {
                    Item.Hover = value;
                }
                _isHover = value;
            }
        }
        
        public ClashTile(int x, int y, int groundId) : base(x,y,groundId)
        {
            FreeTile = true;
        }

        public override bool CanBuild { get { return Item == null && FreeTile; } }

        public bool FreeTile { get; set; }
    }

}
