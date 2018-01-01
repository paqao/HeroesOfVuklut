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
using HeroesOfVuklut.Shared.Clash.Helper;

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
        private bool? active = null;
        private ClashFaction playerFaction;
        private ClashBuilding.BuildingType? buildMode = null;

        #region ui elements
        public IGraphicButton buildTowerButton;
        public IGraphicButton upgradeItemButton;
#endregion

        public IArtificialIntelligence<ClashState, ClashStateArtificialDecision> IAi { get;  }

        public ClashSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface, IMapProvider mapProvider, IClashResourceManager clashResourceManager, IFactionManager factionManager, IArtificialIntelligence<ClashState, ClashStateArtificialDecision> ai, IGraphicElementFactory graphicElementFactory) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
        {
            _clashResourceManager = clashResourceManager;
            _mapProvider = mapProvider;
            _factionManager = factionManager;
            IAi = ai;

            buildTowerButton = graphicElementFactory.CreateButton(ButtonType.Circle);
            upgradeItemButton = graphicElementFactory.CreateButton(ButtonType.Circle);
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

            foreach (var item in clashState.Factions)
            {
                item.BuildingBuild += Faction_BuildingBuild;
            }

            playerFaction = clashState.Factions.First(f => f.Aspect.Id == (int) GameEnums.PlayerVariables.PlayerId);

            PrepareClash(clashState);

            ProcessInput();

            IAi.PrepareAi(clashState);

            _unit = new ClashUnit();

            var path = ClashPathHelper.GeneratePath(_unit, clashState.Factions[0].Castle.ClashNode, clashState.Factions[1].Castle.ClashNode);
            
            _unit.Path = path;
            _unit.SiegePower = 2;
            _unit.X = clashState.Factions[0].Castle.X;
            _unit.Y = clashState.Factions[0].Castle.Y;

            clashState.Units.Add(_unit);

            active = true;


            upgradeItemButton.ItemHeight = 23;
            upgradeItemButton.X = 30;
            upgradeItemButton.Y = 550;


            buildTowerButton.ItemHeight = 23;
            buildTowerButton.X = 72;
            buildTowerButton.Y = 590;
        }

        private void Faction_BuildingBuild(object sender, BuildingActionEventArgs e)
        {
            var building = e.Building;

            this._currentClash.MapClash.Buildings.Add(building);
        }

        public override void Update(TimeSpan step)
        {
            if(active == null)
            {

            }
            else if (active.HasValue && active.Value)
            {
                var nodes = _currentClash.MapClash.MapNodes;
                var toRemove = new List<ClashUnit>();
                foreach (var item in _currentClash.Units)
                {
                    var next = item.Path.OptimumPath.IndexOf(item.Path.CurrentItem) + 1;

                    if (item.Path.OptimumPath.Count <= next)
                    {
                        toRemove.Add(item);
                        continue;
                    }
                    var nextItem = item.Path.OptimumPath[next];

                    var previous = nodes.First(n => n.Id == item.Path.CurrentItem.NodeId);
                    var nextItemNode = nodes.First(n => n.Id == nextItem.NodeId);

                    if (item.X > nextItemNode.X)
                    {
                        item.X -= 0.01M;
                    }
                    if (item.X < nextItemNode.X)
                    {
                        item.X += 0.01M;
                    }

                    if (item.Y > nextItemNode.Y)
                    {
                        item.Y -= 0.01M;
                    }
                    if (item.Y < nextItemNode.Y)
                    {
                        item.Y += 0.01M;
                    }

                    if (item.X == nextItemNode.X && item.Y == nextItemNode.Y)
                    {
                        item.Path.CurrentItem = nextItem;
                    }

                }

                foreach (var item in toRemove)
                {
                    var pathNode = nodes.First(n => n.Id == item.Path.CurrentItem.NodeId);

                    pathNode.NodeItem.Item.Affect(item, _currentClash);

                    _currentClash.Units.Remove(item);
                }

                foreach (var item in _currentClash.MapClash.Buildings)
                {
                    item.Affect(_currentClash);
                }

                foreach (var faction in _currentClash.Factions)
                {
                    if (faction.MarkedLose)
                    {
                        active = false;
                    }
                }
            }
            else if (!active.Value)
            {

            }
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

            foreach (var item in _currentClash.Units)
            {
                int x = (int) (offsetX + item.X * 32.0M);
                int y = (int) (offsetY + item.Y * 32.0M);


                GraphicsInterface.Draw(x, y, 32, 32, "unit");
                
            }
            // ui
            GraphicsInterface.Draw(0, 520, 800, 80, "clashInterface");

            if(_selectedTile != null && _selectedTile.Item != null)
            {
                var upgradableItem = _selectedTile.Item as IUpgradeable;
                var clashFaction = _selectedTile.Item as IClashFactionItem;

                if(upgradableItem != null && clashFaction.Owner == (int) GameEnums.PlayerVariables.PlayerId)
                {
                    var style = upgradableItem.CanUpgrade(_currentClash.Factions[0]) ? "upgrade-active" : "upgrade-idle";
                    GraphicsInterface.Draw(8, 528, 42, 42, "clashInterfaceDynamic", style);
                }
            }

            var buildTowerStyle = playerFaction.CanBuild(ClashBuilding.BuildingType.Tower) ? "tower-active" : "tower-idle";
            GraphicsInterface.Draw(50, 568, 42, 42, "clashInterfaceDynamic", buildTowerStyle );
            

            // resources
            GraphicsInterface.DrawText(60, 450, playerFaction[ClashResource.ClashResourceType.Gold].Amount.ToString());
            GraphicsInterface.DrawText(60, 470, playerFaction[ClashResource.ClashResourceType.Mana].Amount.ToString());
            GraphicsInterface.DrawText(60, 490, playerFaction[ClashResource.ClashResourceType.Engineering].Amount.ToString());
            GraphicsInterface.DrawText(60, 510, playerFaction[ClashResource.ClashResourceType.Morale].Amount.ToString());

            // GraphicsInterface.DrawText(40, 528, "test");

            if (active.HasValue && !active.Value)
            {
                GraphicsInterface.DrawText(60, 300, "Koniec gry");
            }

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

            if(active.HasValue && active.Value)
            {
                var located = GetLocation(cursor.PositionX, cursor.PositionY, out int itemX, out int itemY);

                if (located)
                {
                    var tile = _currentClash.MapClash.Tiles[itemY][itemX];

                    tile.Hover = true;

                    if (leftButton && buildMode == null)
                    {
                        if (_selectedTile != null && _selectedTile.Item != null)
                        {
                            _selectedTile.Item.Selected = false;
                        }
                        _selectedTile = tile;

                        if (tile.Item != null)
                        {
                            tile.Item.Selected = true;
                        }
                    }
                    else if(leftButton && buildMode != null)
                    {
                        if (tile.CanBuild)
                        {
                            playerFaction.Build(buildMode.Value, tile);
                        }
                    }
                }
                else
                {
                    if (leftButton)
                    {
                        if (upgradeItemButton.IsOver(cursor))
                        {
                            var item = _selectedTile.Item;
                            var upgradableItem = item as IUpgradeable;
                            var factionItem = item as IClashFactionItem;

                            if (upgradableItem != null && factionItem.Owner == (int)GameEnums.PlayerVariables.PlayerId && upgradableItem.CanUpgrade(_currentClash.Factions[0]))
                            {
                                upgradableItem.Upgrade(_currentClash.Factions[0]);
                            }
                        }

                        if (buildTowerButton.IsOver(cursor))
                        {
                            buildMode = ClashBuilding.BuildingType.Tower;
                        }
                        else
                        {
                            buildMode = null;
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
                else if (rightButton)
                {
                    buildMode = null;
                }
            }
            else if(active.HasValue && !active.Value)
            {

            }

            _cursor = cursor;
        }
        
        private bool GetLocation(int cursorX, int cursorY, out int itemX, out int itemY)
        {
            int tmpX = (cursorX - offsetX) / 32;
            int tmpY = (cursorY - offsetY) / 32;

            if (tmpX >= 0 && tmpY >= 0 && tmpX < _currentClash.MapClash.Width && tmpY < _currentClash.MapClash.Height)
            {
                itemX = tmpX;
                itemY = tmpY;
                return true;
            }
            else
            {
                itemX = -1;
                itemY = -1;
                return false;
            }
        }

        public override void PreUpdate()
        {
            base.PreUpdate();

            if(active.HasValue && active.Value)
            {
                var steps = Calculate();

                IAi.TakeActions(_currentClash, steps);
            }
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
