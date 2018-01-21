using HeroesOfVuklut.Engine.DI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HeroesOfVuklut.Engine.Localization
{
    [ServiceInject(typeof(FileLocalizedSource), typeof(ILocalizedSource))]
    public class FileLocalizedSource : ILocalizedSource
    {
        private DirectoryInfo directoryInfo;
        private InternalLanguageData content;

        public FileLocalizedSource()
        {
            directoryInfo = new DirectoryInfo("Data/Localized");
            SetLanguage(new LanguageData { Code = "en_US" });
        }

        public ICollection<LanguageData> GetLanguages()
        {
            throw new NotImplementedException();
        }

        public string GetLocalized(string itemKey)
        {
            return content.Items.FirstOrDefault(i => string.CompareOrdinal(i.Key, itemKey) == 0)?.Value;
        }

        public void SetLanguage(LanguageData language)
        {
            var file = directoryInfo.GetFiles($"{language.Code}.json", SearchOption.TopDirectoryOnly).First();
            using (var textReader = file.OpenText())
            {
                string fileContent = textReader.ReadToEnd();
                content = JsonConvert.DeserializeObject<InternalLanguageData>(fileContent);
            }
        }

        protected class InternalLanguageData
        {
            public ICollection<InternalLanguageItemData> Items { get; set; }
        }

        protected class InternalLanguageItemData
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
        
    }
}
