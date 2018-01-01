using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static HeroesOfVuklut.Shared.Clash.ClashResource;

namespace HeroesOfVuklut.Shared.Clash.MapItems
{
    public class ClashFactionCastle : ClashBuilding
    {
        public ClashFactionCastle() : base(BuildingType.Castle)
        {
            Resource = "castle";
        }

        public override void Affect(ClashState state)
        {
            var ownerFaction = state.Factions.First(f => f.Aspect.Id == Owner);

            var data = ownerFaction.ClashResources.First(cr => cr.ResourceType == ClashResourceType.Gold);
            var current = data.Amount;
            var future = data.Amount + 0.05M < data.Max ? data.Amount + 0.05M : data.Max;

            data.Amount = future;
        }

        public override void Affect(ClashUnit passedObject, ClashState state)
        {
            var myFaction = state.Factions.First(f => f.Aspect.Id == Owner);

            myFaction.DecreaseHealth(passedObject.SiegePower);
        }

        public override string GetFrameName()
        {
            string frame = Hover ? "Hover" : "Idle";

            if (Selected)
            {
                frame = "Selected";
            }
            return $"{Resource}{Level}-{frame}";
        }

        protected override IList<ClashResource> GetUpgradeRequirements()
        {
            return new List<ClashResource>()
            {
                CreateResource(5,10, ClashResourceType.Gold)
            };
        }

        protected override bool HasHigherLevel()
        {
            return Level < 2;
        }
    }
}
