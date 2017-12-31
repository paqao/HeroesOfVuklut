using HeroesOfVuklut.Engine.IO;
using System.Collections.Generic;
namespace HeroesOfVuklut.Windows.GraphicsElement
{
    public class GraphicSliderElement<T> : ISliderElement<T> where T : class
    {
        public ICollection<T> InnerList { get; set; }
        public int ItemWidth { get; set; }
        public int ItemHeight { get; set; }
        public T SelectedItem { get; set; }
        public int? SelectedIndex { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
