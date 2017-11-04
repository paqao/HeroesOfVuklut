using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash.MapItems
{
    public abstract class ClashBuilding : ClashTileItem, IUpgradeable
    {
        public int Level { get; protected set; } = 1;

        public bool CanUpgrade(ClashFaction faction)
        {
            if(Level <= 1)
            {
                return true;
            }

            return false;
        }

        public void Upgrade(ClashFaction faction)
        {
            Level++;
        }
    }
}
