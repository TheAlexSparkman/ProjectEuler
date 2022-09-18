using System.Collections.Generic;

namespace ProjectEuler.Problems.Problem81
{
    public class WDiEdge
    {
        public Vertex Source { get; set; }
        public Vertex Destination { get; set; }
        public long Weight { get; set; }

        public override bool Equals(object obj)
        {
            return obj is WDiEdge edge &&
                   EqualityComparer<Vertex>.Default.Equals(Source, edge.Source) &&
                   EqualityComparer<Vertex>.Default.Equals(Destination, edge.Destination) &&
                   Weight == edge.Weight;
        }
    }
}
