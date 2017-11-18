namespace HeroesOfVuklut.Shared.Clash.MapItems
{
    public class ClashTile
    {
        private bool _isHover;
        public int X { get; private set; }
        public int Y { get; private set; }

        public int GroundId { get; set; }

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
        public ClashTileItem Item { get;
            set; }

        public ClashTile(int x, int y, int groundId)
        {
            X = x;
            Y = y;
            GroundId = groundId;
        }
    }

}
