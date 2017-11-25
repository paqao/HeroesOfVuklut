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
        public ICollection<T> InnerList { get; set; }
        public int ItemWidth { get; set; }
        public int ItemHeight { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void CheckIfClick(CursorPosition cursorPosition, out bool clicked, out T seledtedItem)
        {

            bool passX = (cursorPosition.PositionX <= X + ItemWidth && cursorPosition.PositionX >= X);
            bool passY = (cursorPosition.PositionY <= Y + ItemHeight * InnerList.Count && cursorPosition.PositionY >= Y);

            if(passX && passY)
            {
                int itemId = (cursorPosition.PositionY - Y) / ItemHeight;
                
                if(itemId >= 0 && itemId < InnerList.Count)
                {
                    clicked = true;
                    seledtedItem = InnerList.ElementAt(itemId);
                }
                else
                {
                    clicked = false;
                    seledtedItem = default(T);
                }
            }
            else
            {
                clicked = false;
                seledtedItem = default(T);
            }
            

        }

    }
}
