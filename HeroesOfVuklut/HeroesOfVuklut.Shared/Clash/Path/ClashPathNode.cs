﻿using HeroesOfVuklut.Engine.Map.Nodes;
using HeroesOfVuklut.Shared.Clash.MapItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash.Path
{
    public class ClashPathNode : MapNodeBase<ClashPathNode, ClashTile, ClashMapNodeConnection>
    {
    }

    public class ClashMapNodeConnection : MapNodeConnectionBase<ClashPathNode>
    {

    }
}
