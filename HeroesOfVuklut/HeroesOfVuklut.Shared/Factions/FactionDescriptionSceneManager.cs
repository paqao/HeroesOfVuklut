using HeroesOfVuklut.Engine.Scenes;
using System;
using System.Collections.Generic;
using System.Text;
using HeroesOfVuklut.Engine.IO;
using System.Linq;
using HeroesOfVuklut.Windows.InputProcessor;
using HeroesOfVuklut.Shared.World;

namespace HeroesOfVuklut.Shared.Factions
{
    public class FactionDescriptionSceneManager : SceneManager<FactionDescriptionSceneManager>
    {
        private bool _factionSelected = false;
        private readonly IFactionManager _factionsManager;
        private CursorPosition _cursor;

        private IListElement<FactionAspect> factionList = null;
        private int _factionId;

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
            var rightButton = InputInterface.IsClick("cursorRight");
            var leftButton = InputInterface.IsClick("cursorLeft");

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

                    _factionSelected = clicked;
                    if(fa != null)
                    {
                        _factionId = fa.Id;
                    }
                    else
                    {
                        _factionId = 0;
                    }
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

            GraphicsInterface.DrawText(50, 50, "Frakcje");

            var faction = _factionsManager.GetAllFactions().First(fac => fac.Id == _factionId);

            
            GraphicsInterface.DrawText(50, 80, faction.Name);
        }

        public override void BeginScene(SceneParameter<FactionDescriptionSceneManager> sceneParameter)
        {
            var customParameter = sceneParameter as FactionDescriptionSceneParameter;

            _factionSelected = customParameter.FactionId != 0;
            _factionId = customParameter.FactionId;

            factionList = GraphicElementFactory.CreateListElement<FactionAspect>();

            factionList.ItemHeight = 30;
            factionList.ItemWidth = 200;
            factionList.X = 25;
            factionList.Y = 65;
            factionList.MaxShow = 5;
            factionList.Offset = 0;

            var factions = _factionsManager.GetAllFactions();
            factionList.InnerList = factions;

            base.BeginScene(sceneParameter);

            _cursor = InputInterface.GetCursor();
        }

        public class FactionDescriptionSceneParameter : SceneParameter<FactionDescriptionSceneManager>
        {
            public FactionDescriptionSceneParameter(int factionId)
            {
                FactionId = factionId;
            }

            public static FactionDescriptionSceneParameter Default { get { return null; } }

            public int FactionId { get; private set; }
        }
    }
}
