using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.IO
{
    public interface ITextBoxElement : IGraphicElement
    {
        void ProcessInput(InputState inputState, KeyboardType keyboardType = KeyboardType.Standard); 

        string Value { get; }
        event EventHandler OnComplete;
    }

    public enum KeyboardType
    {
        Standard = 1,
        Character = 2,
        Number = 3
    }
}
