using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems.Problem81
{
    public class Vertex
    {
        public int X { get; set; }
        public int Y { get; set; }
        public long OriginalValue { get; set; }
        public IList<WDiEdge> OutgoingEdges { get; set; } = new List<WDiEdge>();

        public Vertex Predecessor { get; set; }
        public long Distance { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Vertex vertex &&
                   X == vertex.X &&
                   Y == vertex.Y &&
                   OriginalValue == vertex.OriginalValue;
        }
    }
}
