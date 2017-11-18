using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash.MapItems
{
    public class ClashFactionCastle : ClashBuilding, IClashFactionItem
    {
        public ClashFactionCastle()
        {
            Resource = "castle";
        }

        public int Owner { get; set; }

        public override string GetFrameName()
        {
            string frame = Hover ? "Hover" : "Idle";

            if (Selected)
            {
                frame = "Selected";
            }
            return $"{Resource}{Level}-{frame}";
        }
    }
}
