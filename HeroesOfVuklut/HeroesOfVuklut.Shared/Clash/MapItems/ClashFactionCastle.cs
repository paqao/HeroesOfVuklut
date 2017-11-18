﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash.MapItems
{
    public class ClashFactionCastle : ClashBuilding
    {
        public ClashFactionCastle()
        {
            Resource = "castle";
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
    }
}
