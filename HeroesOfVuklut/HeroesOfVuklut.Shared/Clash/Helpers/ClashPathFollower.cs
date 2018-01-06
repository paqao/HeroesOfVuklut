using HeroesOfVuklut.Engine.Map;
using HeroesOfVuklut.Shared.Clash.Path;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeroesOfVuklut.Shared.Clash.Helpers
{
    public static class ClashPathFollower
    {
        public static List<MapPoint> TrackPoints(ClashMapNodeConnection mapConnection)
        {
            var result = new List<MapPoint>();

            var start = mapConnection.Nodes.First();
            var target = mapConnection.Nodes.Last();
            bool reachTarget = false;

            var current = new MapPoint(start.X, start.Y);
            result.Add(current);

            do
            {
                int currentX, currentY;

                if (current.X == target.X)
                {
                    currentX = target.X;
                }
                else if (current.X < target.X)
                {
                    currentX = current.X + 1;
                }
                else
                {
                    currentX = current.X - 1;
                }

                if (current.Y == target.Y)
                {
                    currentY = target.Y;
                }
                else if (current.Y < target.Y)
                {
                    currentY = current.Y + 1;
                }
                else
                {
                    currentY = current.Y - 1;
                }

                current = new MapPoint(currentX, currentY);
                result.Add(current);

                if(currentX == target.X && currentY == target.Y)
                {
                    reachTarget = true;
                }
            } while (!reachTarget) ;

            return result;
        }
    }
}
