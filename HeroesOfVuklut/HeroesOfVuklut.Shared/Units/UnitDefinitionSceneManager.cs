using HeroesOfVuklut.Engine.Scenes;
using System;
using HeroesOfVuklut.Engine.IO;
using HeroesOfVuklut.Shared.World;
using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Shared.Traits;

namespace HeroesOfVuklut.Shared.Units
{
    [SceneInject]
    public class UnitDefinitionSceneManager : SceneManager<UnitDefinitionSceneManager>
    {
        private IGraphicButton _backButton;
        private IGraphicButton _addNewDefinitionButton;
        private CursorPosition _cursor;

        private IListElement<UnitDefinition> unitDefinitions = null;
        private IUnitDefinitionManager _unitDefinitionManager;
        private UnitDefinition _selected = null;
        private int _factionId;

        #region class buttons
        private IGraphicButton warriorButton;
        private IGraphicButton knightButton;

        [InjectParameter]
        public ITraitProvider TraitProvider { get; set; }

        #endregion

        public UnitDefinitionSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface, IGraphicElementFactory graphicElementFactory, IUnitDefinitionManager unitDefinitionManager) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
        {
            _backButton = GraphicElementFactory.CreateButton(ButtonType.Circle);
            _addNewDefinitionButton = GraphicElementFactory.CreateButton(ButtonType.Rectangle);
            unitDefinitions = GraphicElementFactory.CreateListElement<UnitDefinition>();

            warriorButton = GraphicElementFactory.CreateButton(ButtonType.Rectangle);
            knightButton = GraphicElementFactory.CreateButton(ButtonType.Rectangle);

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

            GraphicsInterface.DrawText(30, 30, LocalizedSource.GetLocalized("AddUnitType"));

            if (_selected != null)
            {
                DrawSelected();
            }

            GraphicsInterface.Draw(_cursor.PositionX, _cursor.PositionY, 16, 16, "cursor");



            base.Draw();
        }

        private void DrawSelected()
        {
            GraphicsInterface.DrawText(252, 32, _selected.DefinitionName);
            GraphicsInterface.DrawText(252, 52, LocalizedSource.GetLocalized("Class"));
            
            GraphicsInterface.Draw(knightButton.X, knightButton.Y, knightButton.ItemWidth, knightButton.ItemHeight, "classes", _selected.CharacterClass?.Name == "Knight" ? "Knight-Active" : "Knight-Idle");
            GraphicsInterface.Draw(warriorButton.X, warriorButton.Y, warriorButton.ItemWidth, warriorButton.ItemHeight, "classes", _selected.CharacterClass?.Name ==  "Warrior" ? "Warrior-Active" : "Warrior-Idle");

            GraphicsInterface.DrawText(252, 112, LocalizedSource.GetLocalized("STR"));
            GraphicsInterface.DrawText(332, 112, _selected.Strength.ToString());


            GraphicsInterface.DrawText(252, 132, LocalizedSource.GetLocalized("END"));
            GraphicsInterface.DrawText(332, 132, _selected.Endurance.ToString());

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
                    var newCreated = _unitDefinitionManager.AddDefinitionToFaction(_factionId);
                    if(newCreated != null)
                    {
                        _selected = newCreated;
                    }
                    unitDefinitions.InnerList = _unitDefinitionManager.GetUnitDefinitionsPerFaction(_factionId);
                }
                
                bool clicked = false;
                UnitDefinition ud = null;
                unitDefinitions.CheckIfClick(cursor, out clicked, out ud);
                
                if (clicked && ud != null)
                {
                    _selected = ud;
                }

                if(_selected != null)
                {
                    if (warriorButton.IsOver(cursor))
                    {
                        _selected.CharacterClass = TraitProvider.GetClassTrait("Warrior");
                    }
                    else if (knightButton.IsOver(cursor))
                    {
                        _selected.CharacterClass = TraitProvider.GetClassTrait("Knight");
                    }

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

            knightButton.ItemHeight = 32;
            knightButton.ItemWidth = 32;
            knightButton.X = 252;
            knightButton.Y = 72;
            
            warriorButton.ItemHeight = 32;
            warriorButton.ItemWidth = 32;
            warriorButton.X = 292;
            warriorButton.Y = 72;

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
