using HeroesOfVuklut.Shared.Clash;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using HeroesOfVuklut.Engine.DI;
using System.Diagnostics;
using HeroesOfVuklut.Shared.Clash.MapItems;
using HeroesOfVuklut.Shared.Clash.Path;
using HeroesOfVuklut.Shared.Configuration;

namespace HeroesOfVuklut.Shared.GameDataProviders.Maps
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
                    var item = GenerateItem(tile.Item, tile.X, tile.Y);

                    clashTile.Item = item;

                    if(item is ClashBuilding)
                    {
                        var buildingItem = item as ClashBuilding;
                        clashMap.Buildings.Add(buildingItem);
                    }
                }
            }

            foreach (var node in mapInfo.Nodes)
            {
                var nodeEnt = new ClashPathNode();
                nodeEnt.Id = node.Id;
                nodeEnt.X = node.X;
                nodeEnt.Y = node.Y;

                clashMap.MapNodes.Add(nodeEnt);
            }

            foreach (var path in mapInfo.Paths)
            {
                var connection = new ClashMapNodeConnection();
                connection.Unlocked = path.Unlocked;

                var node1 = clashMap.MapNodes.First(nd => nd.Id == path.End1Id);
                var node2 = clashMap.MapNodes.First(nd => nd.Id == path.End2Id);

                connection.Nodes.Add(node1);
                connection.Nodes.Add(node2);



                clashMap.Connections.Add(connection);

                node1.Connections.Add(connection);
                node2.Connections.Add(connection);
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

        private ClashTileItem GenerateItem(TileItem item,int x, int y)
        {
            ClashTileItem newItem = null;

            if(item.Type == 0)
            {
                var castleItem = new ClashFactionCastle();
                var faction = int.Parse(item.Parameters["Faction"]);
                var id = int.Parse(item.Parameters["Id"]);

                castleItem.Owner = faction;
                castleItem.Id = id;
                castleItem.X = x;
                castleItem.Y = y;

                newItem = castleItem;
            }

            return newItem;
        }

    }
}
