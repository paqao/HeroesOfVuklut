using Newtonsoft.Json;
using System.IO;

namespace HeroesOfVuklut.Windows
{
    public class GameConfigurationProvider
    {
        public GameConfiguration GetConfiguration()
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
