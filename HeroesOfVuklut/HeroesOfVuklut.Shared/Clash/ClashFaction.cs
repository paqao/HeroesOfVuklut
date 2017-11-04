using HeroesOfVuklut.Shared.Clash.MapItems;
using System.Collections.Generic;

namespace HeroesOfVuklut.Shared.Clash
{
    public class ClashFaction
    {
        public IList<UnitTemplate> UnitTemplates { get; protected set; }

        public ClashFactionCastle Castle { get; set; }

        public FactionAspect Aspect { get; set; }

        public ClashFaction()
        {
            UnitTemplates = new List<UnitTemplate>();
        }

       
    }

}
