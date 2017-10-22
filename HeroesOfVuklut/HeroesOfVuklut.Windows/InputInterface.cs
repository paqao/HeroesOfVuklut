using HeroesOfVuklut.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesOfVuklut.Windows.InputProcessor;

namespace HeroesOfVuklut.Windows
{
    public class InputInterface : IInputInterface
    {
        public bool CheckInputDown(string key)
        {
            return false;
        }

        internal void AddProcessor(KeyboardProcessorImpl inputProce)
        {
        }
    }
}
