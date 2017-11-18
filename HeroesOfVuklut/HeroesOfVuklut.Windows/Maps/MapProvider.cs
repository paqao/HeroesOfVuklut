using HeroesOfVuklut.Shared.Clash;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using HeroesOfVuklut.Shared;
using HeroesOfVuklut.Engine.DI;
using System.Diagnostics;
using HeroesOfVuklut.Shared.Clash.MapItems;

namespace HeroesOfVuklut.Windows.Maps
{
    [ServiceInject(typeof(MapProvider), typeof(IMapProvider))]
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

            var clashMap = new ClashMap(mapInfo.Name, mapInfo.SizeX, mapInfo.SizeY);

            foreach (var tile in mapInfo.Tiles)
            {
                var clashTile = clashMap.Tiles[tile.Y][tile.X];

                clashTile.GroundId = tile.GroundId;

                if(tile.Item != null)
                {
                    var item = GenerateItem(tile.Item);

                    clashTile.Item = item;

                    if(item is ClashBuilding)
                    {
                        var buildingItem = item as ClashBuilding;
                        clashMap.Buildings.Add(buildingItem);
                    }
                }
            }

            Debug.WriteLine(mapInfo.Name);

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

        private ClashTileItem GenerateItem(TileItem item)
        {
            ClashTileItem newItem = null;

            if(item.Type == 0)
            {
                var castleItem = new ClashFactionCastle();
                var faction = int.Parse(item.Parameters["Faction"]);
                var id = int.Parse(item.Parameters["Id"]);

                castleItem.Owner = faction;
                castleItem.Id = id;

                newItem = castleItem;
            }

            return newItem;
        }

    }
}
