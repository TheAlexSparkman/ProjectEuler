using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Problems.Problem81.Domain;

namespace ProjectEuler.Problems.Problem81
{
    public class Solver
    {
        public long FindMinimalPathSum(Graph graph, Vertex start, Vertex end)
        {
            start.Distance = 0;
            foreach (var vertex in graph.Vertices)
            {
                if (vertex != start)
                {
                    vertex.Distance = long.MaxValue;
                    vertex.Predecessor = null;
                }
            }

            var initialPriorityQueue = graph.Vertices.Select(vertex => new KeyValuePair<long, Vertex>(vertex.Distance, vertex));
            var priorityQueue = new PriorityQueue<long, Vertex>(initialPriorityQueue);

            while (priorityQueue.Any())
            {
                var currentVertex = priorityQueue.Pop();
                foreach (var edge in currentVertex.OutgoingEdges)
                {
                    var neighbor = edge.Destination;
                    var candidateDistance = currentVertex.Distance + edge.Weight;
                    if (candidateDistance < neighbor.Distance)
                    {
                        priorityQueue.Reprioritize(neighbor.Distance, candidateDistance, neighbor);
                        neighbor.Distance = candidateDistance;
                        neighbor.Predecessor = currentVertex;
                    }
                }
            }

            return end.Distance;
        }

        public long[][] ParseMatrixFromString(string matrix)
        {
            var matrixLines = matrix.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var result = matrixLines
                .Select(row => row.Split(',').Select(cell => long.Parse(cell)).ToArray())
                .ToArray();
            return result;
        }

        public Graph ParseGraphFromMatrix(long[][] matrix)
        {
            var verticesMatrixList = new List<List<Vertex>>();
            for (var y = 0; y < matrix.Length; y++)
            {
                var row = new List<Vertex>();
                for (var x = 0; x < matrix[y].Length; x++)
                {
                    var vertex = new Vertex()
                    {
                        Y = y,
                        X = x,
                        OriginalValue = matrix[y][x]
                    };
                    row.Add(vertex);
                }
                verticesMatrixList.Add(row);
            }

            var verticesMatrix = verticesMatrixList.Select(x => x.ToArray()).ToArray();

            var edges = new List<WDiEdge>();
            for (var y = 0; y < verticesMatrix.Length; y++)
            {
                var row = verticesMatrix[y];
                var sources = row.Take(row.Length - 1);
                var destinations = row.Skip(1);
                var rowEdges = sources.Zip(destinations, (source, destination) => new WDiEdge() { Source = source, Destination = destination, Weight = destination.OriginalValue });
                foreach (var rowEdge in rowEdges)
                {
                    rowEdge.Source.OutgoingEdges.Add(rowEdge);
                }
                
                if (y != verticesMatrix.Length - 1)
                {
                    var nextRow = verticesMatrix[y + 1];
                    var columnEdges = row.Zip(nextRow, (source, destination) => new WDiEdge() { Source = source, Destination = destination, Weight = destination.OriginalValue });

                    foreach (var columnEdge in columnEdges)
                    {
                        columnEdge.Source.OutgoingEdges.Add(columnEdge);
                    }
                }
            }

            var startVertex = new Vertex { Y = -1, X = -1 };
            var startingEdge = new WDiEdge { Source = startVertex, Destination = verticesMatrix[0][0], Weight = verticesMatrix[0][0].OriginalValue };
            startVertex.OutgoingEdges = new[] { startingEdge };

            var vertices = verticesMatrix.SelectMany(x => x).ToList();
            vertices.Insert(0, startVertex);

            var result = new Graph { Vertices = vertices };
            return result;
        }
    }
}
