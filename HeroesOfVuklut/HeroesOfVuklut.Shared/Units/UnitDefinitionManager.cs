using HeroesOfVuklut.Engine.Context;
using HeroesOfVuklut.Engine.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeroesOfVuklut.Shared.Units
{
    [ServiceInject(typeof(UnitDefinitionManager), typeof(IUnitDefinitionManager))]
    public class UnitDefinitionManager : IUnitDefinitionManager, IGameDataBased<GameData>
    {
        private GameData _gameData { get; set; }

        public UnitDefinition AddDefinitionToFaction(int factionId)
        {
            var faction = _gameData.Factions.First(f => f.Id == factionId);
            var factionDefinitions = _gameData.UnitDefinitions.Where(u => u.FactionId == factionId).ToList();

            if(faction.MaxUnitDefinitions <= factionDefinitions.Count)
            {
                return null;
            }
            var lastId = factionDefinitions.LastOrDefault()?.DefinitionId;



            var ud = new UnitDefinition();
            ud.FactionId = factionId;
            ud.DefinitionId = lastId != null ? lastId.Value + 1 : 1;
            ud.DefinitionName = $"definitionName-{ud.DefinitionId}";
            _gameData.UnitDefinitions.Add(ud);

            return ud;
        }

        public ICollection<UnitDefinition> GetUnitDefinitionsPerFaction(string factionName)
        {
            return new List<UnitDefinition>();
        }

        public ICollection<UnitDefinition> GetUnitDefinitionsPerFaction(int factionId)
        {
            return _gameData.UnitDefinitions.Where(ud => ud.FactionId == factionId).ToList();
        }

        public void SetGameData(GameData gameData)
        {
            _gameData = gameData;
        }
    }
}
