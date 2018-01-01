using HeroesOfVuklut.Engine.Context;
using HeroesOfVuklut.Shared.Clash.Helpers;
using HeroesOfVuklut.Shared.Clash.MapItems;
using System;
using System.Collections.Generic;
using System.Linq;
using static HeroesOfVuklut.Shared.Clash.ClashResource;

namespace HeroesOfVuklut.Shared.Clash
{
    public class ClashFaction : IContext
    {
        public event EventHandler<BuildingActionEventArgs> BuildingBuild;

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

        public ClashResource this[ClashResourceType key]
        {
            get
            {
                return ClashResources.First(cr => cr.ResourceType == key);
            }
        }

        public bool CanBuild(ClashBuilding.BuildingType buildingType)
        {
            var isAvailable = ClashFactionBuildingHelper.HasBuildingAvailable(this, buildingType);

            if (!isAvailable)
            {
                return false;
            }

            return ClashFactionBuildingHelper.HasEnoughResources(this, buildingType);
        }

        public void Build(ClashBuilding.BuildingType buildingType, ClashTile tile)
        {
            if(buildingType == ClashBuilding.BuildingType.Tower)
            {
                var newTower = new ClashTower();
                tile.Item = newTower;
                

                if(BuildingBuild != null)
                {
                    BuildingBuild.Invoke(this, new BuildingActionEventArgs(newTower, this));
                }
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
