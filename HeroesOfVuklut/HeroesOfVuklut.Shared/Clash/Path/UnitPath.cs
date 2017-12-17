using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash.Path
{
    public class UnitPath
    { 
        public UnitPathNode CurrentItem { get; set; }
        public List<UnitPathNode> OptimumPath { get; set; } = new List<UnitPathNode>();
    }
}
