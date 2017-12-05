using Newtonsoft.Json;
using System.IO;

namespace HeroesOfVuklut.Engine.Game
{
    public abstract class JSonSettingsManager<T> : ISettingsManager<T> where T : IGameSettings, new()
    {
        private string settingsPath = "settings.json";
        private T _innerSettings = new T();
        private bool _isLoaded = false;
        public T GetSettings()
        {
            if (!_isLoaded)
            {
                Load();
            }
            return _innerSettings;
        }

        private void Load()
        {
            var content = File.ReadAllText(settingsPath);
            _innerSettings = JsonConvert.DeserializeObject<T>(content);
            _isLoaded = true;
        }

        public void UpdateSettings()
        {
            var settingsContent = JsonConvert.SerializeObject(_innerSettings);
            File.WriteAllText(settingsPath, settingsContent);
        }
    }
}
