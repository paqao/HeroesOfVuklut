using System.Collections.Generic;
using HeroesOfVuklut.Windows.InputProcessor;
using HeroesOfVuklut.Engine.IO;
using HeroesOfVuklut.Engine.DI;

namespace HeroesOfVuklut.Windows
{
    [ServiceInject(typeof(InputInterface), typeof(IInputInterface))]
    public class InputInterface : IInputInterface
    {
        private List<IInputProcessor> _processors = new List<IInputProcessor>();

        public InputInterface()
        {

        }
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
            bool down = false;
            foreach (var item in _processors)
            {
                var actionItem = item.GetButton(key);

                if(actionItem != null)
                {
                    down = actionItem.State == Shared.Input.ButtonStateValue.OnClick || actionItem.State == Shared.Input.ButtonStateValue.OnHold;
                }
            }

            return down;
        }

        public CursorPosition GetCursor()
        {
            return new CursorPositionImpl(_mouseProcessor.MousePositionX, _mouseProcessor.MousePositionY);
        }

        internal void AddProcessor(KeyboardProcessorImpl inputProce)
        {
            _processors.Add(inputProce);
        }
        
        internal void AddProcessor(MouseProcessor mouseProcessor)
        {
            _mouseProcessor = mouseProcessor;
            _processors.Add(mouseProcessor);
        }
    }
}
