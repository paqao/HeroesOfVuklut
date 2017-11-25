using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Quest.Logic
{
    public class MissionLogicOr<T> : IMissionTaskLogic<T> where T : IMissionTask
    {
        public ICollection<T> ChildrenTasks = new List<T>();

        public MissionState GetState()
        {
            MissionState result = MissionState.Visible;
            bool? success = false;
            bool chance = false;

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
                else {
                    chance = true;
                }
            }

            if(success != null && success == true)
            {
                result = MissionState.Complete;
            }
            else if(success != null && !chance){
                result = MissionState.Fail;
            }

            return result;
        }
    }
}
