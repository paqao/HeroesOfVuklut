using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfVuklut.Windows.GraphicsElement
{
    [ServiceInject(typeof(GraphicElementFactory), typeof(IGraphicElementFactory))]
    public class GraphicElementFactory : IGraphicElementFactory
    {
        public IGraphicButton CreateButton(ButtonType type)
        {
            switch (type)
            {
                case ButtonType.Rectangle:
                    return new GraphicButton();
                case ButtonType.Circle:
                    return new RoundGraphicButton();
                default:
                    return null;
            }
        }

        public IListElement<T> CreateListElement<T>() where T : class
        {
            return new GraphicListElement<T>();
        }

        public ITextBoxElement CreateTextBox(KeyboardType keyboardType)
        {
            return new GraphicTextBoxElement();
        }
    }
}
