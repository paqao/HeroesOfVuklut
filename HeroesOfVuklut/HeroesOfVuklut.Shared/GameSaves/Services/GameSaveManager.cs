using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.Saves;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.GameSaves.Services
{
    [ServiceInject(typeof(GameSaveManager), typeof(IGameSavesManager<VuklutSaveGameInfo>))]
    public class GameSaveManager : IGameSavesManager<VuklutSaveGameInfo>
    {
        public ICollection<VuklutSaveGameInfo> GetAllSaves()
        {
            throw new NotImplementedException();
        }
    }
}
