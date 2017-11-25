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

        public void SetGameData(GameData gameData)
        {
            _gameData = gameData;
        }
    }
}
