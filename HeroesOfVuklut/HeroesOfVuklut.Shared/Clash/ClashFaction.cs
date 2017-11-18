using HeroesOfVuklut.Engine.Context;
using HeroesOfVuklut.Shared.Clash.MapItems;
using System;
using System.Collections.Generic;

namespace HeroesOfVuklut.Shared.Clash
{
    public class ClashFaction : IContext
    {
        public IList<UnitTemplate> UnitTemplates { get; protected set; }
        public IList<ClashResource> ClashResources { get; protected set; }

        public ClashFactionCastle Castle { get; set; }

        public FactionAspect Aspect { get; set; }

        public ClashFaction()
        {
            UnitTemplates = new List<UnitTemplate>();
            ClashResources = new List<ClashResource>();
            var array = Enum.GetValues(typeof(ClashResource.ClashResourceType));
            foreach (var item  in array)
            {
                var resourceType = (ClashResource.ClashResourceType) item;

                ClashResources.Add(ClashResource.CreateResource(0, 50, resourceType));
            }
        }

       
    }

}
