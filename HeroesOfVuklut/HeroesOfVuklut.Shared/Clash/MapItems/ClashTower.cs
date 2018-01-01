using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash.MapItems
{
    public class ClashTower : ClashBuilding
    {
        public ClashTower()
        {
            Resource = "Tower"; 
        }

        public override void Affect(ClashState state)
        {
            throw new NotImplementedException();
        }

        public override void Affect(ClashUnit passedObject, ClashState state)
        {
            throw new NotImplementedException();
        }

        public override string GetFrameName()
        {
            throw new NotImplementedException();
        }

        protected override IList<ClashResource> GetUpgradeRequirements()
        {
            throw new NotImplementedException();
        }

        protected override bool HasHigherLevel()
        {
            throw new NotImplementedException();
        }
    }
}
