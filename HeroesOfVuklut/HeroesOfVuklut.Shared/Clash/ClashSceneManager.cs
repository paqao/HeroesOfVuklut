using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.IO;
using HeroesOfVuklut.Engine.Scenes;
using HeroesOfVuklut.Engine.AI;
using HeroesOfVuklut.Shared.Clash.AI;
using HeroesOfVuklut.Shared.Clash.MapItems;
using System;
using System.Collections.Generic;
using System.Linq;
using HeroesOfVuklut.Shared.Factions;
using HeroesOfVuklut.Shared.Clash.Path;

namespace HeroesOfVuklut.Shared.Clash
{
    [SceneInject]
    public class ClashSceneManager : SceneManager<ClashSceneManager>, ISceneIntelligence<ClashState, ClashStateArtificialDecision>
    {
        private ClashState _currentClash;
        private IClashResourceManager _clashResourceManager;
        private CursorPosition _cursor;
        private IFactionManager _factionManager;

        private int offsetX;
        private int offsetY;
        private ClashTile _selectedTile;
        private readonly IMapProvider _mapProvider;
        private ClashUnit _unit;

        public IArtificialIntelligence<ClashState, ClashStateArtificialDecision> IAi { get;  }

        public ClashSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface, IMapProvider mapProvider, IClashResourceManager clashResourceManager, IFactionManager factionManager, IArtificialIntelligence<ClashState, ClashStateArtificialDecision> ai, IGraphicElementFactory graphicElementFactory) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
        {
            _clashResourceManager = clashResourceManager;
            _mapProvider = mapProvider;
            _factionManager = factionManager;
            IAi = ai;
        }

        public void PrepareClash(ClashState state)
        {
            _currentClash = state;

            offsetX = (800 - state.MapClash.Width * 32) / 2;
            offsetY = (600 - state.MapClash.Height * 32) / 4;

            var startBuilding = state.MapClash.Buildings;
            var mapNodes = state.MapClash.MapNodes;

            foreach (var building in startBuilding)
            {
                var mapItem = mapNodes.FirstOrDefault(m => m.X == building.X && m.Y == building.Y);

                building.ClashNode = mapItem;

                if(building is ClashFactionCastle)
                {
                    var castle = building as ClashFactionCastle;

                    var faction = state.Factions.First(f => f.Aspect.Id == castle.Owner);

                    faction.Castle = castle;
                }
            }
        }

        public override void BeginScene(SceneParameter<ClashSceneManager> sceneParameter)
        {
            base.BeginScene(sceneParameter);
            var parsedParam = sceneParameter as ClashSceneParameter;

            var factions = _factionManager.GetAllFactions().Where(f => parsedParam.FactionIds.Contains(f.Id));
            
            var map = _mapProvider.GetMapById(parsedParam.MapId);
            var clashState = new ClashState();
            clashState.MapClash = map;
            clashState.Factions = factions.Select(f => new ClashFaction() { Aspect = f }).ToList();
            
            PrepareClash(clashState);

            ProcessInput();

            IAi.PrepareAi(clashState);

            _unit = new ClashUnit();

            var path = ClashPathHelper.GeneratePath(_unit, clashState.Factions[0].Castle.ClashNode, clashState.Factions[1].Castle.ClashNode);
        }

        public override void Update(TimeSpan step)
        {
        }

        public override void Draw()
        {
            for (int i = 0; i < _currentClash.MapClash.Width; i++)
            {
                for (int j = 0; j < _currentClash.MapClash.Height; j++)
                {
                    var tile = _currentClash.MapClash.Tiles[j][i];

                    string style = "Idle";
                    if (tile.Hover)
                    {
                        style = "Hover";
                    }
                    var resourceName = _clashResourceManager.GetGroundResource(tile.GroundId);
                    GraphicsInterface.Draw(offsetX + i * 32, offsetY + j * 32, 32, 32, resourceName, style);

                    if(tile.Item != null)
                    {
                        var frameName = tile.Item.GetFrameName();
                        GraphicsInterface.Draw(offsetX + i * 32, offsetY + j * 32, 32, 32, tile.Item.Resource, frameName);
                    }
                }
            }


            foreach (var node in _currentClash.MapClash.MapNodes)
            {
                GraphicsInterface.DrawCircle(offsetX + 16 + node.X * 32, offsetY + 16 + node.Y * 32);
            }

            foreach(var connection in _currentClash.MapClash.Connections)
            {
                var firstCon = connection.Nodes.First();
                var lastCon = connection.Nodes.Last();
                GraphicsInterface.DrawLine(offsetX + 16 + firstCon.X * 32, offsetY + 16 + firstCon.Y * 32, offsetX + 16 + lastCon.X * 32, offsetY + 16 + lastCon.Y * 32);
            }
            // ui
            GraphicsInterface.Draw(0, 520, 800, 80, "clashInterface");

            if(_selectedTile != null && _selectedTile.Item != null)
            {
                var upgradableItem = _selectedTile.Item as IUpgradeable;
                var clashFaction = _selectedTile.Item as IClashFactionItem;

                if(upgradableItem != null && clashFaction.Owner == 0)
                {
                    var style = upgradableItem.CanUpgrade(_currentClash.Factions[0]) ? "upgrade-active" : "upgrade-idle";
                    GraphicsInterface.Draw(8, 528, 42, 42, "clashInterfaceDynamic", style);
                }
            }

            // GraphicsInterface.DrawText(40, 528, "test");

            // ui controllers
            GraphicsInterface.Draw(_cursor.PositionX, _cursor.PositionY, 16, 16, "cursor");
        }

        public override Type GetSceneType()
        {
            return typeof(ClashSceneManager);
        }

        public override void ClearScene()
        {
            for (int i = 0; i < _currentClash.MapClash.Width; i++)
            {
                for (int j = 0; j < _currentClash.MapClash.Height; j++)
                {
                    var tile = _currentClash.MapClash.Tiles[j][i];
                    tile.Hover = false;
                }
            }
        }

        public override void ProcessInput()
        {
            var cursor = InputInterface.GetCursor();
            var leftButton = InputInterface.CheckInputDown("cursorLeft");
            var rightButton = InputInterface.CheckInputDown("cursorRight");

            int itemX = (cursor.PositionX - offsetX) / 32;
            int itemY = (cursor.PositionY - offsetY) / 32;

            if (itemX >= 0 && itemY >= 0 && itemX < _currentClash.MapClash.Width && itemY < _currentClash.MapClash.Height)
            {
                var tile = _currentClash.MapClash.Tiles[itemY][itemX];

                tile.Hover = true;
                if (leftButton)
                {
                    if(_selectedTile  != null && _selectedTile.Item != null)
                    {
                        _selectedTile.Item.Selected = false;
                    }
                    _selectedTile = tile;

                    if(tile.Item != null)
                    {
                        tile.Item.Selected = true;
                    }
                }
                
            }
            else
            {
                if (leftButton)
                {
                    var distanceX = cursor.PositionX - 30;
                    var distanceY = cursor.PositionY - 550;

                    var distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

                    if(distance < 23 && _selectedTile != null && _selectedTile.Item != null)
                    {
                        var item = _selectedTile.Item;
                        var upgradableItem = item as IUpgradeable;
                        var factionItem = item as IClashFactionItem;
                        
                        if(upgradableItem != null && factionItem.Owner == 0 && upgradableItem.CanUpgrade(_currentClash.Factions[0]))
                        {
                            upgradableItem.Upgrade(_currentClash.Factions[0]);
                        }
                    }
                }
            }
            

            if (rightButton && _selectedTile != null)
            {
                if (_selectedTile.Item != null)
                {
                    _selectedTile.Item.Selected = false;
                }
                _selectedTile = null;
            }

            _cursor = cursor;
        }

        public override void PreUpdate()
        {
            base.PreUpdate();

            var steps = Calculate();

            IAi.TakeActions(_currentClash, steps);
        }

        public ICollection<ClashStateArtificialDecision> Calculate()
        {
            var ai = IAi.CalculateStep(_currentClash);

            return ai;
        }

        public class ClashSceneParameter : SceneParameter<ClashSceneManager>
        {
            public ClashSceneParameter(int mapId)
            {
                MapId = mapId;
            }

            public static ClashSceneParameter Default { get { return null; } }

            public int MapId { get; private set; }

            public ICollection<int> FactionIds { get; set; } = new List<int>();
        }

        public interface IClashResourceManager
        {
            string GetGroundResource(int id);
        }

        [ServiceInject(typeof(ClashResourceManager), typeof(IClashResourceManager))]
        public class ClashResourceManager : IClashResourceManager
        {
            private Dictionary<int, string> _resourceDictionary = new Dictionary<int, string>();

            public ClashResourceManager()
            {
                _resourceDictionary[0] = "grass";
                _resourceDictionary[1] = "forrest";
            }
            public string GetGroundResource(int id)
            {
                return _resourceDictionary[id];
            }
        }
    }

}
