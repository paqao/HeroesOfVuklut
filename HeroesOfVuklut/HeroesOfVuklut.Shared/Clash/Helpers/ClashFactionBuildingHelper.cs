using HeroesOfVuklut.Shared.Clash.MapItems;
using System;
using static HeroesOfVuklut.Shared.Clash.ClashResource;

namespace HeroesOfVuklut.Shared.Clash.Helpers
{
    public static class ClashFactionBuildingHelper
    {
        public static bool HasBuildingAvailable(ClashFaction faction, ClashBuilding.BuildingType buildingType)
        {
            return true;
        }

        public static bool HasEnoughResources(ClashFaction clashFaction, ClashBuilding.BuildingType buildingType)
        {
            return clashFaction[ClashResourceType.Gold].Amount >= clashFaction.Buildings.Count * 10;
        }

        internal static void ReduceResources(ClashFaction clashFaction, ClashBuilding.BuildingType buildingType)
        {
            clashFaction[ClashResourceType.Gold].Amount -= clashFaction.Buildings.Count * 10;
        }
    }
}
