using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems.Problem81.Domain
{
    public class Graph
    {
        public Vertex[][] Vertices { get; set; }

        public IEnumerable<WDiEdge> Edges { get; set; }
    }
}
