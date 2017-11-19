using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Quest.Logic
{
    public class MissionLogicAll<T> : IMissionTaskLogic<T> where T : IMissionTask
    {
        public ICollection<T> ChildrenTasks = new List<T>();

        public MissionState GetState()
        {
            MissionState result = MissionState.Visible;
            bool? success = null;

            foreach (var item in ChildrenTasks)
            {
                var itemState = item.GetState();

                if (success == null && itemState == MissionState.Complete)
                {
                    success = true;
                }
                else if(itemState == MissionState.Fail)
                {
                    result = MissionState.Fail;
                }
               
                if(success != null && success == true)
                {
                    result = MissionState.Complete;
                }
            }

            return result;
        }
    }
}
