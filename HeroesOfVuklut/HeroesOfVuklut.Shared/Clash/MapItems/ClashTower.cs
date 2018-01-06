using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash.MapItems
{
    public class ClashTower : ClashBuilding
    {
        public ClashTower() : base(BuildingType.Tower)
        {
            Resource = "tower"; 
        }

        public override void Affect(ClashState state)
        {

        }

        public override void Affect(ClashUnit passedObject, ClashState state)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        protected override bool HasHigherLevel()
        {
            return false;
        }
    }
}
