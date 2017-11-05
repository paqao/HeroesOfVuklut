using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared
{
    public interface IConfiguralable<in T>
    {
        void SetConfiguration(T configuration);
    }
}
