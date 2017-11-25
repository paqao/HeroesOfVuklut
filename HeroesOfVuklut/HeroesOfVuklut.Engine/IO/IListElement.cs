using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.IO
{
    public interface IListElement<T> : IGraphicElement where T : class
    {
        ICollection<T> InnerList { get; set; }
        
        int ItemWidth { get; set; }
        int ItemHeight { get; set; }

        void CheckIfClick(CursorPosition cursorPosition, out bool clicked, out T seledtedItem);
    }
}
