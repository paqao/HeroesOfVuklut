using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Map.Nodes
{
    public abstract class MapNodeBase<T, U, V> where V : MapNodeConnectionBase<T>
    {
        public ICollection<V> Connections { get; set; } = new List<V>();
        public U NodeItem { get; set; }
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
