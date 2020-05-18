using System;
using System.Collections.Generic;

namespace Problems.MaxSumPath
{
    public class Vertex : List<WDiEdge>
    {
        public void Add(Vertex destination, long weight)
        {
            this.Add(
                new WDiEdge()
                {
                    Source = this,
                    Destination = destination,
                    Weight = weight
                }
            );
        }

        public long _distance { get; set; } = long.MaxValue;
        public Vertex _predecessor { get; set; }

        public static void BellmanFord(List<Vertex> vertices, List<WDiEdge> edges, Vertex root)
        {
            foreach (var vertex in vertices)
            {
                vertex._distance = long.MaxValue;
                vertex._predecessor = null;
            }

            root._distance = 0;


            foreach (var vertex in vertices)
            {
                foreach (var edge in edges)
                {
                    if (edge.Source._distance + edge.Weight < edge.Destination._distance)
                    {
                        edge.Destination._distance = edge.Source._distance + edge.Weight;
                        edge.Destination._predecessor = edge.Source;
                    }
                }
            }

            foreach (var edge in edges)
            {
                if (edge.Source._distance + edge.Weight < edge.Destination._distance)
                {
                    throw new Exception("Graph contains a negative-weight cycle");
                }
            }
        }
    }
}
