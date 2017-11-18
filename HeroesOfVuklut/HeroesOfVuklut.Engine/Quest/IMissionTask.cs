using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Quest
{
    public interface IMissionTask
    {
        MissionState GetState();
    }
}
