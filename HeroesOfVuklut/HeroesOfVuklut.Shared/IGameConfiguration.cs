using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared
{
    public interface IGameConfiguration
    {
        ICollection<IGameMapConfiguration> Maps { get;  }
    }

    public interface IGameMapConfiguration
    {
        string Name { get;  }
        string Path { get;  }
        int Id { get; }
    }
}
