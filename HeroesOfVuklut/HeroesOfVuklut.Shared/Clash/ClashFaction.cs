using HeroesOfVuklut.Engine.Context;
using HeroesOfVuklut.Shared.Clash.MapItems;
using System;
using System.Collections.Generic;

namespace HeroesOfVuklut.Shared.Clash
{
    public class ClashFaction : IContext
    {
        public int Health { get; private set; }
        public bool MarkedLose { get; private set; }

        public IList<UnitTemplate> UnitTemplates { get; protected set; }
        public IList<ClashResource> ClashResources { get; protected set; }

        public ClashFactionCastle Castle { get; set; }

        public FactionAspect Aspect { get; set; }

        public ClashFaction()
        {
            Health = 1;
            MarkedLose = false;
            UnitTemplates = new List<UnitTemplate>();
            ClashResources = new List<ClashResource>();
            var array = Enum.GetValues(typeof(ClashResource.ClashResourceType));
            foreach (var item  in array)
            {
                var resourceType = (ClashResource.ClashResourceType) item;

                ClashResources.Add(ClashResource.CreateResource(0, 50, resourceType));
            }
        }

        public void DecreaseHealth(int siegePower)
        {
            Health -= siegePower;

            if(Health <= 0)
            {
                MarkedLose = true;
            }
        }
    }

}
