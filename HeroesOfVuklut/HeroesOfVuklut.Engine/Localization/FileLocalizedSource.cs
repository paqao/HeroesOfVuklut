using HeroesOfVuklut.Engine.DI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HeroesOfVuklut.Engine.Localization
{
    [ServiceInject(typeof(FileLocalizedSource), typeof(ILocalizedSource))]
    public class FileLocalizedSource : ILocalizedSource
    {
        private DirectoryInfo directoryInfo;

        public FileLocalizedSource()
        {
            directoryInfo = new DirectoryInfo("Data/Localized");
        }

        public ICollection<LanguageData> GetLanguages()
        {
            throw new NotImplementedException();
        }

        public string GetLocalized(string key)
        {
            throw new NotImplementedException();
        }

        public void SetLanguage(LanguageData language)
        {
            throw new NotImplementedException();
        }
    }
}
