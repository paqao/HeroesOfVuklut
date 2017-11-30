using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Units
{
    public interface IUnitDefinitionManager
    {
        ICollection<UnitDefinition> GetUnitDefinitionsPerFaction(string factionName);
        ICollection<UnitDefinition> GetUnitDefinitionsPerFaction(int factionId);

        UnitDefinition AddDefinitionToFaction(int factionId);
    }
}
