using HeroesOfVuklut.Engine.Context;
using HeroesOfVuklut.Engine.DI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Units
{
    [ServiceInject(typeof(UnitDefinitionManager), typeof(IUnitDefinitionManager))]
    public class UnitDefinitionManager : IUnitDefinitionManager, IGameDataBased<GameData>
    {
        private GameData _gameData { get; set; }

        public ICollection<UnitDefinition> GetUnitDefinitionsPerFaction(string factionName)
        {
            return new List<UnitDefinition>();
        }

        public ICollection<UnitDefinition> GetUnitDefinitionsPerFaction(int factionId)
        {
            return new List<UnitDefinition>();
        }

        public void SetGameData(GameData gameData)
        {
            _gameData = gameData;
        }
    }
}
