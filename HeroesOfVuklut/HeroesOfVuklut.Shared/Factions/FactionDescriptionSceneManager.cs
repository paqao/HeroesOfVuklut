using HeroesOfVuklut.Engine.Scenes;
using System;
using System.Collections.Generic;
using System.Text;
using HeroesOfVuklut.Engine.IO;
using System.Linq;

namespace HeroesOfVuklut.Shared.Factions
{
    public class FactionDescriptionSceneManager : SceneManager<FactionDescriptionSceneManager>
    {
        private bool _factionSelected = false;
        private readonly IFactionManager _factionsManager;
        private CursorPosition _cursor;

        private IListElement<FactionAspect> factionList = null;

        public FactionDescriptionSceneManager(ISceneNavigator sceneNavigator, IInputInterface inputInterface, IGraphicsInterface graphicsInterface , IFactionManager factions, IGraphicElementFactory graphicElementFactory) : base(sceneNavigator, inputInterface, graphicsInterface, graphicElementFactory)
        {
            _factionsManager = factions;
        }

        public override Type GetSceneType()
        {
            return typeof(FactionDescriptionSceneManager);
        }

        public override void ProcessInput()
        {

            var cursor = InputInterface.GetCursor();
            var rightButton = InputInterface.CheckInputDown("cursorRight");
            var leftButton = InputInterface.CheckInputDown("cursorLeft");

            if (rightButton)
            {
                if (_factionSelected)
                {
                    _factionSelected = false;
                }
                else
                {
                    SceneNavigator.GotoScene(typeof(WorldSceneManager), WorldSceneManager.WorldSceneParameter.Default);
                }
            }
            if (leftButton)
            {
                if (!_factionSelected)
                {
                    bool clicked = false;
                    FactionAspect fa = null;
                    factionList.CheckIfClick(cursor, out clicked, out fa);
                }
            }

            _cursor = cursor;
        }

        public override void Draw()
        {
            if (_factionSelected)
            {
                DrawSelected();
            }
            else
            {
                DrawUnselected();
            }

            GraphicsInterface.Draw(_cursor.PositionX, _cursor.PositionY, 16, 16, "cursor");
            base.Draw();
        }

        private void DrawUnselected()
        {
            GraphicsInterface.DrawText(50, 50, "Frakcje");

            var factions = _factionsManager.GetAllFactions();

            for(int i =0; i< factions.Count; i++)
            {
                GraphicsInterface.DrawText(30, 70 + i * 30, factions.ElementAt(i).Name);
            }
        }

        private void DrawSelected()
        {
        }

        public override void BeginScene(SceneParameter<FactionDescriptionSceneManager> sceneParameter)
        {
            var customParameter = sceneParameter as FactionDescriptionSceneParameter;

            _factionSelected = customParameter.FacionId != 0;

            factionList = GraphicElementFactory.CreateListElement<FactionAspect>();

            base.BeginScene(sceneParameter);
            
            ProcessInput();
        }

        public class FactionDescriptionSceneParameter : SceneParameter<FactionDescriptionSceneManager>
        {
            public FactionDescriptionSceneParameter(int factionId)
            {
                FacionId = factionId;
            }

            public static FactionDescriptionSceneParameter Default { get { return null; } }

            public int FacionId { get; private set; }
        }
    }
}
