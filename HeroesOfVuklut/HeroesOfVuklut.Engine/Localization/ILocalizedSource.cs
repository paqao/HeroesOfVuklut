using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Localization
{
    public interface ILocalizedSource
    {
        ICollection<LanguageData> GetLanguages();

        void SetLanguage(LanguageData language);
        string GetLocalized(string key);
    }
}
