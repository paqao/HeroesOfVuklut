using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash
{
    public abstract class ClashBuilding : ClashTileItem
    {
        public int Level { get; protected set; } = 1;

        public virtual void Upgrade()
        {
            Level++;
        }
    }
}
