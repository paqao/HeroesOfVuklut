using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.IO
{
    public interface ISliderElement<T> : IGraphicElement where T : class
    {
        ICollection<T> InnerList { get; set; }

        int ItemWidth { get; set; }
        int ItemHeight { get; set; }
        
        T SelectedItem { get; set; }
        int? SelectedIndex { get; set; }
        
    }
}
