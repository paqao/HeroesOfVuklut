using HeroesOfVuklut.Engine.Context;
using HeroesOfVuklut.Engine.DI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Factions
{
    [ServiceInject(typeof(FactionManager), typeof(IFactionManager))]
    public class FactionManager : IFactionManager, IGameDataBased<GameData>
    {
        private GameData _gameData { get; set; }

        public ICollection<FactionAspect> GetAllFactions()
        {
            return _gameData.Factions;
        }

        public void SetGameData(GameData gameData)
        {
            _gameData = gameData;
        }
    }
}
