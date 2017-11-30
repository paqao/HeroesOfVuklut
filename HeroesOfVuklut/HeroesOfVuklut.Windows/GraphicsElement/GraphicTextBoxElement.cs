using HeroesOfVuklut.Engine.IO;
using HeroesOfVuklut.Windows.InputProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfVuklut.Windows.GraphicsElement
{
    public class GraphicTextBoxElement : ITextBoxElement
    {
        private string _content = "";
        public string Value { get { return _content; } }

        public int X { get; set; }
        public int Y { get; set; }

        public event EventHandler OnComplete;

        public void ProcessInput(InputState inputState, KeyboardType keyboardType = KeyboardType.Standard)
        {

        }
    }
}
