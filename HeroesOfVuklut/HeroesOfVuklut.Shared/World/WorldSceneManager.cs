using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.IO;
using HeroesOfVuklut.Engine.Scenes;
using HeroesOfVuklut.Shared.Clash;
using HeroesOfVuklut.Shared.Factions;
using HeroesOfVuklut.Shared.Units;
using HeroesOfVuklut.Windows.InputProcessor;
using System;

namespace HeroesOfVuklut.Shared.World
{
    [SceneInject]
    public class WorldSceneManager : SceneManager<WorldSceneManager>
    {
        private CursorPosition _cursor;
        private IGraphicButton _unitDefinition;
        private IGraphicButton _factionsExplorer;
        private IGraphicButton _clash;

        public WorldSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface, IGraphicElementFactory graphicElementFactory) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
        {
            _unitDefinition = GraphicElementFactory.CreateButton(ButtonType.Circle);
            _factionsExplorer = GraphicElementFactory.CreateButton(ButtonType.Circle);
            _clash = GraphicElementFactory.CreateButton(ButtonType.Circle);
        }

        public override void BeginScene(SceneParameter<WorldSceneManager> sceneParameter)
        {
            var parameter = sceneParameter as WorldSceneParameter;

            _factionsExplorer.ItemHeight = 21;
            _factionsExplorer.X = 30;
            _factionsExplorer.Y = 550;


            _unitDefinition.ItemHeight = 21;
            _unitDefinition.X = 80;
            _unitDefinition.Y = 550;


            _clash.ItemHeight = 21;
            _clash.X = 130;
            _clash.Y = 550;

            base.BeginScene(sceneParameter);
        }

        public override Type GetSceneType()
        {
            return typeof(WorldSceneManager);
        }

        public class WorldSceneParameter : SceneParameter<WorldSceneManager>
        {
            public static WorldSceneParameter Default { get { return null; } }
        }

        public override void Update(TimeSpan elapsedGameTime)
        {

        }


        public override void Draw()
        {
            var style = "upgrade-active";
            GraphicsInterface.Draw(8, 528, 42, 42, "clashInterfaceDynamic", style);

            GraphicsInterface.Draw(58, 528, 42, 42, "clashInterfaceDynamic", style);

            GraphicsInterface.Draw(108, 528, 42, 42, "clashInterfaceDynamic", style);

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

            var leftButton = InputInterface.IsClick("cursorLeft");

            if (leftButton)
            {
                // element 1
                bool element1IsOver = _factionsExplorer.IsOver(cursor);

                if (element1IsOver)
                {
                    var navigationParameter = new FactionDescriptionSceneManager.FactionDescriptionSceneParameter(0);
                    SceneNavigator.GotoScene(typeof(FactionDescriptionSceneManager), navigationParameter);
                }

                // element 2
                bool element2IsOver = _unitDefinition.IsOver(cursor);

                if (element2IsOver)
                {
                    var navigationParameter = new UnitDefinitionSceneManager.UnitDefinitionSceneParameter(1);
                    SceneNavigator.GotoScene(typeof(UnitDefinitionSceneManager), navigationParameter);
                }

                // element 3
                bool element3IsOver = _clash.IsOver(cursor);

                if (element3IsOver)
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

}