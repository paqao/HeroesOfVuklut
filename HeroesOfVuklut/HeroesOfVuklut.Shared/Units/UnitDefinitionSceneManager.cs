using HeroesOfVuklut.Engine.Scenes;
using System;
using System.Collections.Generic;
using System.Text;
using HeroesOfVuklut.Engine.IO;

namespace HeroesOfVuklut.Shared.Units
{
    public class UnitDefinitionSceneManager : SceneManager<UnitDefinitionSceneManager>
    {
        private IGraphicButton _backButton;
        private CursorPosition _cursor;

        private IListElement<UnitDefinition> unitDefinitions = null;

        public UnitDefinitionSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface, IGraphicElementFactory graphicElementFactory) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
        {
            _backButton = GraphicElementFactory.CreateButton(ButtonType.Circle);
            unitDefinitions = GraphicElementFactory.CreateListElement<UnitDefinition>();
        }

        public override Type GetSceneType()
        {
            return typeof(UnitDefinitionSceneManager);
        }

        public override void Draw()
        {
            var style = "upgrade-active";
            GraphicsInterface.Draw(8, 528, 42, 42, "clashInterfaceDynamic", style);

            GraphicsInterface.Draw(_cursor.PositionX, _cursor.PositionY, 16, 16, "cursor");

            base.Draw();
        }

        public override void ProcessInput()
        {
            var cursor = InputInterface.GetCursor();

            var leftButton = InputInterface.IsClick("cursorLeft");


            if (leftButton)
            {
                bool element1IsOver = _backButton.IsOver(cursor);

                if (element1IsOver)
                {
                    var navigationParameter = new WorldSceneManager.WorldSceneParameter();
                    SceneNavigator.GotoScene(typeof(WorldSceneManager), navigationParameter);
                }

            }

            _cursor = cursor;
        }

        public override void BeginScene(SceneParameter<UnitDefinitionSceneManager> sceneParameter)
        {
            base.BeginScene(sceneParameter);

            _backButton.ItemHeight = 21;
            _backButton.X = 30;
            _backButton.Y = 550;

            var cursor = InputInterface.GetCursor();

            _cursor = cursor;
        }

        public class UnitDefinitionSceneParameter : SceneParameter<UnitDefinitionSceneManager>
        {
            public UnitDefinitionSceneParameter()
            {
            }

            public static UnitDefinitionSceneParameter Default { get { return null; } }
        }
    }
}
