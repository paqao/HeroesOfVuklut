using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash
{
    public class ClashFactionCastle : ClashBuilding
    {
        public ClashFactionCastle()
        {
            Resource = "castle";
        }

        public override void Upgrade()
        {
            base.Upgrade();
        }

        public override string GetFrameName()
        {
            string frame = Hover ? "Hover" : "Idle";
            return $"{Resource}{Level}-{frame}";
        }
    }
}
