using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash.MapItems
{
    public interface IUpgradeable
    {
        bool CanUpgrade(ClashFaction faction);
        void Upgrade(ClashFaction faction);
    }
}
