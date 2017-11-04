using HeroesOfVuklut.Shared;
using HeroesOfVuklut.Shared.Clash.MapItems;
using System;

namespace HeroesOfVuklut.Shared.Clash
{
    public class ClashSceneManager : SceneManager<ClashSceneManager>
    {
        private ClashState _currentClash;
        private IClashResourceManager clashResourceManager;
        private CursorPosition _cursor;

        private int offsetX;
        private int offsetY;
        private ClashTile _selectedTile;

        public ClashSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface) : base(sceneNavigator, inputInterface, graphicsInterface)
        {
            clashResourceManager = new ClashResourceManager();
        }

        public void PrepareClash(ClashState state)
        {
            _currentClash = state;

            offsetX = (800 - state.MapClash.Width * 32) / 2;
            offsetY = (600 - state.MapClash.Heigth * 32) / 4;
        }

        public override void BeginScene(SceneParameter<ClashSceneManager> sceneParameter)
        {
            base.BeginScene(sceneParameter);
            var parsedParam = sceneParameter as ClashSceneParameter;

            var clashState = new ClashState();

            PrepareClash(clashState);

            ProcessInput();
        }

        public override void Update(TimeSpan step)
        {
        }

        public override void Draw()
        {
            for (int i = 0; i < _currentClash.MapClash.Width; i++)
            {
                for (int j = 0; j < _currentClash.MapClash.Heigth; j++)
                {
                    var tile = _currentClash.MapClash.Tiles[j][i];

                    string style = "Idle";
                    if (tile.Hover)
                    {
                        style = "Hover";
                    }
                    var resourceName = clashResourceManager.GetGroundResource(tile.GroundId);
                    GraphicsInterface.Draw(offsetX + i * 32, offsetY + j * 32, 32, 32, resourceName, style);

                    if(tile.Item != null)
                    {
                        var frameName = tile.Item.GetFrameName();
                        GraphicsInterface.Draw(offsetX + i * 32, offsetY + j * 32, 32, 32, tile.Item.Resource, frameName);
                    }
                }
            }

            // ui
            GraphicsInterface.Draw(0, 520, 800, 80, "clashInterface");

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
                for (int j = 0; j < _currentClash.MapClash.Heigth; j++)
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

            if (itemX >= 0 && itemY >= 0 && itemX < _currentClash.MapClash.Width && itemY < _currentClash.MapClash.Heigth)
            {
                var tile = _currentClash.MapClash.Tiles[itemY][itemX];

                tile.Hover = true;
                if (leftButton)
                {
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
                        
                        if(upgradableItem != null)
                        {
                            upgradableItem.Updgrade(_currentClash.Factions[0]);
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

        public class ClashSceneParameter : SceneParameter<ClashSceneManager>
        {
            public ClashSceneParameter()
            {

            }

            public static ClashSceneParameter Default { get { return null; } }
        }

        public interface IClashResourceManager
        {
            string GetGroundResource(int id);
        }

        public class ClashResourceManager : IClashResourceManager
        {
            public string GetGroundResource(int id)
            {
                return "grass";
            }
        }
    }

}
