using HeroesOfVuklut.Shared.Clash.MapItems;
using System.Collections.Generic;


namespace HeroesOfVuklut.Shared.Clash
{
    public class ClashState
    {
        public IList<ClashFaction> Factions { get; set; }
        public ClashMap MapClash { get; set; }

        public ClashState()
        {
        }
    }
}
