using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash.MapItems
{
    public class BuildingActionEventArgs : EventArgs
    {
        public BuildingActionEventArgs(ClashBuilding building, ClashFaction faction)
        {
            Building = building;
            FAction = faction;
        }

        public ClashBuilding Building { get; }
        public ClashFaction FAction { get; }
    }
}
