using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Map.Nodes
{
    public abstract class MapNodeConnectionBase<T>
    {
        public ICollection<T> Nodes { get; set; } = new List<T>();

        public bool Unlocked { get; set; }
    }
}
