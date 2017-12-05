using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.Game;
using HeroesOfVuklut.Engine.Scenes;
using HeroesOfVuklut.Shared.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfVuklut.Shared
{
    [ServiceInject(typeof(GameManager), typeof(GameManagerBase<GameData, GameSettings>))]
    public class GameManager : GameManagerBase<GameData, GameSettings>
    {
        [InjectParameter]
        public IContainerSystem Container { get; set; }

        [InjectParameter]
        public ISceneNavigator SceneNavigator { get; set; }

        [InjectParameter]
        public IGameConfigurationProvider GameConfigurationProvider { get; set; }

        public override ICollection<string> GetSavedGames()
        {
            var directoryInfo = Directory.GetDirectories("saves");

            return directoryInfo;
        }

        public override void Initialize(GameData game, GameSettings settings)
        {
            base.Initialize(game, settings);

            Container.AddGameData(game, settings);
        }

        public override void LoadGameData()
        {
            base.LoadGameData();
        }

        public override void SaveGame(string filename)
        {
            // save
            var saves = Directory.Exists("saves");

            if (!saves)
            {
                Directory.CreateDirectory("saves");
            }
        }
    }
}
