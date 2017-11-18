using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Quest
{
    public interface IMissionTaskLogic<T> : IMissionTask where T : IMissionTask
    {
    }
}
