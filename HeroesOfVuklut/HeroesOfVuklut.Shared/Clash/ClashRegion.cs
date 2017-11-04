using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash
{
    public class ClashRegion
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public ClashFaction Ownere { get; set; }
    }
}
