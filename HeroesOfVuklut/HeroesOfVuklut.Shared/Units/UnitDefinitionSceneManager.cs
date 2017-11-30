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
        private IGraphicButton _addNewDefinitionButton;
        private CursorPosition _cursor;

        private IListElement<UnitDefinition> unitDefinitions = null;
        private IUnitDefinitionManager _unitDefinitionManager;
        private UnitDefinition _selected = null;
        private int _factionId;

        public UnitDefinitionSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface, IGraphicElementFactory graphicElementFactory, IUnitDefinitionManager unitDefinitionManager) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
        {
            _backButton = GraphicElementFactory.CreateButton(ButtonType.Circle);
            _addNewDefinitionButton = GraphicElementFactory.CreateButton(ButtonType.Rectangle);
            unitDefinitions = GraphicElementFactory.CreateListElement<UnitDefinition>();
            

            _unitDefinitionManager = unitDefinitionManager;
        }

        public override Type GetSceneType()
        {
            return typeof(UnitDefinitionSceneManager);
        }

        public override void Draw()
        {
            var style = "upgrade-active";
            GraphicsInterface.Draw(8, 528, 42, 42, "clashInterfaceDynamic", style);

            int upperLimit = unitDefinitions.Offset + unitDefinitions.MaxShow;
            for (int i = unitDefinitions.Offset; i < upperLimit; i++)
            {
                if(i < unitDefinitions.InnerList.Count)
                {
                    var item = unitDefinitions[i];
                    GraphicsInterface.DrawText(12, 60 + i * 30, item.DefinitionName);
                }

            }
                
            GraphicsInterface.Draw(_cursor.PositionX, _cursor.PositionY, 16, 16, "cursor");

            base.Draw();
        }

        public override void ProcessInput()
        {
            var cursor = InputInterface.GetCursor();

            var leftButton = InputInterface.IsClick("cursorLeft");
            var rightButton = InputInterface.IsClick("cursorRight");


            if (leftButton)
            {
                bool element1IsOver = _backButton.IsOver(cursor);
                bool element2ISOver = _addNewDefinitionButton.IsOver(cursor);

                if (element1IsOver)
                {
                    var navigationParameter = new WorldSceneManager.WorldSceneParameter();
                    SceneNavigator.GotoScene(typeof(WorldSceneManager), navigationParameter);
                }
                else if (element2ISOver)
                {
                    _unitDefinitionManager.AddDefinitionToFaction(_factionId);
                    unitDefinitions.InnerList = _unitDefinitionManager.GetUnitDefinitionsPerFaction(_factionId);
                }
                
                bool clicked = false;
                UnitDefinition ud = null;
                unitDefinitions.CheckIfClick(cursor, out clicked, out ud);
                
                if (clicked && ud != null)
                {
                    _selected = ud;
                }
            }

            if (rightButton)
            {
                if(_selected != null)
                {
                    _selected = null;
                }
            }

            _cursor = cursor;
        }

        public override void BeginScene(SceneParameter<UnitDefinitionSceneManager> sceneParameter)
        {
            base.BeginScene(sceneParameter);

            var parameter = sceneParameter as UnitDefinitionSceneParameter;

            _backButton.ItemHeight = 21;
            _backButton.X = 30;
            _backButton.Y = 550;

            _addNewDefinitionButton.ItemHeight = 30;
            _addNewDefinitionButton.ItemWidth = 200;
            _addNewDefinitionButton.X = 30;
            _addNewDefinitionButton.Y = 30;

            _factionId = parameter.FactionId;
            unitDefinitions.InnerList = _unitDefinitionManager.GetUnitDefinitionsPerFaction(_factionId);


            unitDefinitions.ItemHeight = 30;
            unitDefinitions.ItemWidth = 200;
            unitDefinitions.X = 25;
            unitDefinitions.Y = 65;
            unitDefinitions.MaxShow = 10;
            unitDefinitions.Offset = 0;

            var cursor = InputInterface.GetCursor();

            _cursor = cursor;
        }

        public class UnitDefinitionSceneParameter : SceneParameter<UnitDefinitionSceneManager>
        {
            public UnitDefinitionSceneParameter(int factionId)
            {
                FactionId = factionId;
            }

            public int FactionId { get; }
            public static UnitDefinitionSceneParameter Default { get { return null; } }
        }
    }
}
