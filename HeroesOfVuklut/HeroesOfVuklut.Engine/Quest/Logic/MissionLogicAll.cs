using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Quest.Logic
{
    public class MissionLogicAll<T> : IMissionTaskLogic<T> where T : IMissionTask
    {
        public MissionState GetState()
        {
            throw new NotImplementedException();
        }
    }
}
