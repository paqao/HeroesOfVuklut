using HeroesOfVuklut.Engine.DI;
using System.Collections.Generic;
using System.Linq;
using HeroesOfVuklut.Shared.Units;

namespace HeroesOfVuklut.Shared.Clash.Units
{
    [ServiceInject(typeof(ClashUnitFactory), typeof(IClashUnitFactory))]
    public class ClashUnitFactory : IClashUnitFactory
    {
        private ICollection<UnitTemplate> _templates;

        public void AddForScene(ClashFaction faction, ICollection<UnitDefinition> unitDefinitions)
        {
            foreach (var unitDefinition in unitDefinitions)
            {
                UnitBase uBase = new UnitBase(unitDefinition.DefinitionName);
                UnitTemplate template = new UnitTemplate(uBase, faction, unitDefinition.Quantity);
                _templates.Add(template);
            }
        }

        public ICollection<UnitTemplate> GetTemplates(ClashFaction faction)
        {
            return _templates.Where(ut => ut.Faction == faction).ToList();
        }

        public ClashUnit GetUnit(ClashFaction faction, UnitTemplate template)
        {
            if(template != null && template.Faction == faction && template.AvailableUnits > 0)
            {
                return template.CreateUnit();
            }
            else
            {
                return null;
            }
        }

        public void PrepareForScene()
        {
            _templates = new List<UnitTemplate>();
        }
    }
}
