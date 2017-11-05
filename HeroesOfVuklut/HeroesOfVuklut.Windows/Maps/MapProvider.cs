using HeroesOfVuklut.Shared.Clash;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesOfVuklut.Shared;

namespace HeroesOfVuklut.Windows.Maps
{
    public class MapProvider : IMapProvider
    {
        private IGameConfiguration _gameConfiguration;

        public ClashMap GetMapById(int id)
        {
            var map = _gameConfiguration.Maps.FirstOrDefault(x => x.Id == id);

            if (map == null)
                return null;

            MapInfo mapInfo;
            using (var textReader = File.OpenText(map.Path))
            {
                string fileContent = textReader.ReadToEnd();
                mapInfo = JsonConvert.DeserializeObject<MapInfo>(fileContent);
            }

            var clashMap = new ClashMap(mapInfo.SizeX, mapInfo.SizeY);

            return clashMap;
        }

        public ClashMap GetMapByName(string name)
        {
            throw new NotImplementedException();
        }

        public void SetConfiguration(IGameConfiguration configuration)
        {
            _gameConfiguration = configuration;
        }
    }
}
