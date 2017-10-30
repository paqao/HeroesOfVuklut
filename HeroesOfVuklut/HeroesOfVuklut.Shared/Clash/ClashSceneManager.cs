using HeroesOfVuklut.Shared;
using System;

public class ClashSceneManager : SceneManager<ClashSceneManager> {
    private ClashState _currentClash;
    private IClashResourceManager clashResourceManager;

    public ClashSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface) : base(sceneNavigator, inputInterface, graphicsInterface)
    {
        clashResourceManager = new ClashResourceManager();
    }

    public void PrepareClash(ClashState state) {
        _currentClash = state;
    }

    public override void BeginScene(SceneParameter<ClashSceneManager> sceneParameter)
    {
        base.BeginScene(sceneParameter);
        var parsedParam = sceneParameter as ClashSceneParameter;

        var clashState = new ClashState();

        PrepareClash(clashState);
    }

    public override void Update(TimeSpan step)
    {
    }

    public override void Draw()
    {
        for(int i=0; i < _currentClash.MapClash.Width; i++)
        {
            for(int j=0;j < _currentClash.MapClash.Heigth; j++)
            {
                var tile = _currentClash.MapClash.Tiles[j][i];

                if (!tile.Hover)
                {
                    var resourceName = clashResourceManager.GetGroundResource(tile.GroundId);
                    GraphicsInterface.Draw(i * 32, j * 32, 32, 32, resourceName);
                }
            }
        }
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
        
        int itemX = cursor.PositionX / 32;
        int itemY = cursor.PositionY / 32;

        if(itemX >= 0 && itemY >= 0 && itemX < _currentClash.MapClash.Width && itemY < _currentClash.MapClash.Heigth)
        {
            var tile = _currentClash.MapClash.Tiles[itemY][itemX];

            tile.Hover = true;
        }
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
