using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Configuration
{
    public interface IGameConfigurationProvider
    {
        IGameConfiguration GetConfiguration();
    }
}
