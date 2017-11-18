using HeroesOfVuklut.Engine.Map.TiledMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash.MapItems
{
    public abstract class ClashTileItem : TiledMapItemBase
    {
        public bool Hover { get; set; }
        public bool Selected { get; set; }
        public string Resource { get; protected set; }
        public abstract string GetFrameName();
    }
}
