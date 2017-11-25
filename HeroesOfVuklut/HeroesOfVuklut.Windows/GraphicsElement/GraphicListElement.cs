using HeroesOfVuklut.Engine.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfVuklut.Windows.GraphicsElement
{
    public class GraphicListElement<T> : IListElement<T> where T : class
    {
        public ICollection<T> InnerList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ItemWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ItemHeight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int X { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void CheckIfClick(CursorPosition cursorPosition, out bool clicked, out T seledtedItem)
        {
            clicked = false;
            seledtedItem = default(T);
        }

    }
}
