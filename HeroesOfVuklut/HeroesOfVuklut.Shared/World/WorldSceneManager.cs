using HeroesOfVuklut.Engine.IO;
using HeroesOfVuklut.Engine.Scenes;
using HeroesOfVuklut.Shared.Clash;
using HeroesOfVuklut.Shared.Factions;
using System;

public class WorldSceneManager : SceneManager<WorldSceneManager>
{
    private CursorPosition _cursor;

    public WorldSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface, IGraphicElementFactory graphicElementFactory) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
    {
    }

    public override void BeginScene(SceneParameter<WorldSceneManager> sceneParameter)
    {
        var parameter = sceneParameter as WorldSceneParameter;
        base.BeginScene(sceneParameter);
    }

    public override Type GetSceneType()
    {
        return typeof(WorldSceneManager);
    }

    public class WorldSceneParameter :  SceneParameter<WorldSceneManager>
    {
        public static WorldSceneParameter Default { get { return null; } }
    }

    public override void Update(TimeSpan elapsedGameTime)
    {
        //  var navigationParameter = new ClashSceneManager.ClashSceneParameter(1);
        // navigationParameter.FactionIds.Add(1);
        //  navigationParameter.FactionIds.Add(2);
        // var navigationParameter = new FactionDescriptionSceneManager.FactionDescriptionSceneParameter(0);
       //  SceneNavigator.GotoScene(typeof(FactionDescriptionSceneManager), navigationParameter);
    }


    public override void Draw()
    {
        var style = "upgrade-active";
        GraphicsInterface.Draw(8, 528, 42, 42, "clashInterfaceDynamic", style);
        
        GraphicsInterface.Draw(58, 528, 42, 42, "clashInterfaceDynamic", style);

        GraphicsInterface.Draw(_cursor.PositionX, _cursor.PositionY, 16, 16, "cursor");
    }
    public override void BeginScene(SceneParameter sceneParameter)
    {
        base.BeginScene(sceneParameter);

        var cursor = InputInterface.GetCursor();

        _cursor = cursor;

    }

    public override void ProcessInput()
    {
        var cursor = InputInterface.GetCursor();

        var leftButton = InputInterface.CheckInputDown("cursorLeft");

        if (leftButton)
        {
            // element 1
            var distance1X = cursor.PositionX - 30;
            var distance1Y = cursor.PositionY - 550;

            var distance1 = Math.Sqrt(distance1X * distance1X + distance1Y * distance1Y);

            if(distance1 <= 21)
            {
                var navigationParameter = new FactionDescriptionSceneManager.FactionDescriptionSceneParameter(0);
                SceneNavigator.GotoScene(typeof(FactionDescriptionSceneManager), navigationParameter);
            }

            // element 2
            var distance2X = cursor.PositionX - 80;
            var distance2Y = cursor.PositionY - 550;

            var distance2 = Math.Sqrt(distance2X * distance2X + distance2Y * distance2Y);

            if (distance2 <= 21)
            {
                var navigationParameter = new ClashSceneManager.ClashSceneParameter(1);
                navigationParameter.FactionIds.Add(1);
                navigationParameter.FactionIds.Add(2);
                SceneNavigator.GotoScene(typeof(ClashSceneManager), navigationParameter);
            }
        }

        _cursor = cursor;
    }
}
