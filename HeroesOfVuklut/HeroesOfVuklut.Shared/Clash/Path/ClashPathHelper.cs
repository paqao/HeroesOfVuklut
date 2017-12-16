using System.Collections.Generic;
using System.Linq;

namespace HeroesOfVuklut.Shared.Clash.Path
{
    public class ClashPathHelper {

        public static UnitPath GeneratePath(ClashUnit clashUnit, ClashPathNode start, ClashPathNode target)
        {
            var path = new UnitPath();
            bool reachTarget = false;

            List<ClashPathNode> toProcess = new List<ClashPathNode>();
            List<UnitPathNode> processed = new List<UnitPathNode>();

            toProcess.Add(start);
            processed.Add(new UnitPathNode
            {
                Cost = 0,
                NodeId = start.Id,
                Precessor = null
            });

            while (toProcess.Any())
            {
                var processing = toProcess.First();
                toProcess.Remove(processing);

                var processedItem = processed.First(p => p.NodeId == processing.Id);
                var cost = processedItem.Cost;

                foreach (var connection in processing.Connections)
                {
                    if (!connection.Unlocked)
                    {
                        continue;
                    }

                    var otherNode = connection.Nodes.First(n => n != processing);
                    var otherProcessed = processed.FirstOrDefault(p => p.NodeId == otherNode.Id);

                    if(otherProcessed == null)
                    {
                        toProcess.Add(otherNode);
                        processed.Add(new UnitPathNode
                        {
                            Cost = cost + 1,
                            NodeId = otherNode.Id,
                            Precessor = processedItem
                        });
                    }
                    else if(otherProcessed.Cost > cost + 1)
                    {
                        if (!toProcess.Contains(otherNode))
                        {
                            toProcess.Add(otherNode);
                        }
                        otherProcessed.Cost = cost + 1;
                        otherProcessed.Precessor = processedItem;
                    }

                    if(otherNode == target)
                    {
                        reachTarget = true;
                    }
                }
            }

            if (!reachTarget)
            {
                return null;
            }

            UnitPathNode startItem = processed.First(p => p.NodeId == start.Id);
            UnitPathNode actual = processed.First(p => p.NodeId == target.Id);

            while(actual != startItem)
            {
                path.OptimumPath.Insert(0, actual);

                actual = actual.Precessor;
            }

            path.OptimumPath.Insert(0, startItem);

            return path ;
        }
    }
}