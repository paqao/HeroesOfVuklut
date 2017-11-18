using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Engine.Map.Nodes
{
    public abstract class MapNodeBase<T>
    {
        public ICollection<MapNodeConnectionBase> Connections { get; set; } = new List<MapNodeConnectionBase>();

        public abstract class MapNodeConnectionBase
        {
            public ICollection<T> Nodes { get; set; }

            public bool Unlocked { get; set; }
        }
    }
}
