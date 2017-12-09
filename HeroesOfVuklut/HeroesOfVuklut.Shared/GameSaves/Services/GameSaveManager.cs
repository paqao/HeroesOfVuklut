using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.Saves;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HeroesOfVuklut.Shared.GameSaves.Services
{
    [ServiceInject(typeof(GameSaveManager), typeof(IGameSavesManager<VuklutSaveGameInfo>))]
    public class GameSaveManager : IGameSavesManager<VuklutSaveGameInfo>
    {
        private DirectoryInfo directoryInfo { get; set; }

        public GameSaveManager()
        {
            directoryInfo = new DirectoryInfo("saves");

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
        }

        public ICollection<VuklutSaveGameInfo> GetAllSaves()
        {
            var result = new List<VuklutSaveGameInfo>();

            foreach (var item in directoryInfo.GetDirectories())
            {
                result.Add(new VuklutSaveGameInfo());
            }

            return result;
        }
    }
}
