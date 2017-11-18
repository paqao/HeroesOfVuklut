using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash.MapItems
{
    public abstract class ClashBuilding : ClashTileItem, IUpgradeable, IClashFactionItem
    {
        public int Owner { get; set; }
        public int Level { get; protected set; } = 1;
        public int Id { get; set; }

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
