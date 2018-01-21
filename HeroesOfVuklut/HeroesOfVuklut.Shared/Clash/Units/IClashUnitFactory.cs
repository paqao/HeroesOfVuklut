using HeroesOfVuklut.Shared.Units;
using System.Collections.Generic;

namespace HeroesOfVuklut.Shared.Clash.Units
{
    public interface IClashUnitFactory
    {
        void PrepareForScene();

        void AddForScene(ClashFaction faction, ICollection<UnitDefinition> unitDefinitions);

        ICollection<UnitTemplate> GetTemplates(ClashFaction faction);

        ClashUnit GetUnit(ClashFaction faction, UnitTemplate template);
    }
}
