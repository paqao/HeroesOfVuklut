using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared
{
    public interface IGameConfiguration
    {
        ICollection<IGameMapConfiguration> Maps { get; }
        ICollection<IGameLanguageConfiguration> Languages { get; }
    }

    public interface IGameLanguageConfiguration
    {
        string English { get; }
        string Origin { get; }
        int Id { get; }
    }

    public interface IGameMapConfiguration
    {
        string Name { get;  }
        string Path { get;  }
        int Id { get; }
    }
}
