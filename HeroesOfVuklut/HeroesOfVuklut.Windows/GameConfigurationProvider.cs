using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Shared.Configuration;
using Newtonsoft.Json;
using System.IO;

namespace HeroesOfVuklut.Windows
{
    [ServiceInject(typeof(GameConfigurationProvider))]
    public class GameConfigurationProvider : IGameConfigurationProvider
    {
        public IGameConfiguration GetConfiguration()
        {
            GameConfiguration config = null;
            using (var textReader = File.OpenText(@"data/game.json"))
            {
                string fileContent = textReader.ReadToEnd();
                config = JsonConvert.DeserializeObject<GameConfiguration>(fileContent);
            }

            return config;
        }
    }
}
