using HeroesOfVuklut.Shared.Clash.Path;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfVuklut.Shared.Clash.MapItems
{
    public abstract class ClashBuilding : ClashTileItem, IUpgradeable, IClashFactionItem
    {
        protected BuildingType Building;

        public ClashBuilding(BuildingType buildingType)
        {
            this.Building = buildingType;
        }

        public enum BuildingType
        {
            Castle,
            Tower
        }

        public int Owner { get; set; }
        public int Level { get; protected set; } = 1;
        public int Id { get; set; }

        public ClashPathNode ClashNode { get; set; }

        protected abstract bool HasHigherLevel();
        protected abstract IList<ClashResource> GetUpgradeRequirements();

        private bool CanAfford(ClashFaction faction, IList<ClashResource> resources)
        {
            bool canAfford = true;
            foreach (var item in resources)
            {
                var factionResource = faction.ClashResources.FirstOrDefault(cr => cr.ResourceType == item.ResourceType);

                if(factionResource.Amount < item.Amount)
                {
                    canAfford = false;
                }
            }

            return canAfford;
        }

        public bool CanUpgrade(ClashFaction faction)
        {
            if (!HasHigherLevel())
            {
                return false;
            }

            var resources = GetUpgradeRequirements();

            return CanAfford(faction, resources);
        }

        public void Upgrade(ClashFaction faction)
        {
            Level++;
        }
    }
}
