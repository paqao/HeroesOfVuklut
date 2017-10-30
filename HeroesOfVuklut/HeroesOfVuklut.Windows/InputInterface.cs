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
        internal class CursorPositionImpl : CursorPosition
        {
            internal CursorPositionImpl(int x, int y)
            {
                PositionX = x;
                PositionY = y;
            }

            public int PositionX { get; private set; }

            public int PositionY { get; private set; }
        }
        private MouseProcessor _mouseProcessor;
        public bool CheckInputDown(string key)
        {
            return false;
        }

        public CursorPosition GetCursor()
        {
            return new CursorPositionImpl(_mouseProcessor.MousePositionX, _mouseProcessor.MousePositionY);
        }

        internal void AddProcessor(KeyboardProcessorImpl inputProce)
        {
        }
        
        internal void AddProcessor(MouseProcessor mouseProcessor)
        {
            _mouseProcessor = mouseProcessor;
        }
    }
}
