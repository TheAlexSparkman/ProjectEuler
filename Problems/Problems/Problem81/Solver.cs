using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Problems.Problem81.Domain;

namespace ProjectEuler.Problems.Problem81
{
    public class Solver
    {
        public long FindMinimalPathSum(long[][] matrix)
        {
            throw new NotImplementedException();
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
            var vertices = new List<List<Vertex>>();
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
                vertices.Add(row);
            }

            var verticesMatrix = vertices.Select(x => x.ToArray()).ToArray();

            var edges = new List<WDiEdge>();
            for (var y = 0; y < verticesMatrix.Length; y++)
            {
                var row = verticesMatrix[y];
                var sources = row.Take(row.Length - 1);
                var destinations = row.Skip(1);
                var rowEdges = sources.Zip(destinations, (source, destination) => new WDiEdge() { Source = source, Destination = destination, Weight = destination.OriginalValue });
                edges.AddRange(rowEdges);
                
                if (y != verticesMatrix.Length - 1)
                {
                    var nextRow = verticesMatrix[y + 1];
                    var columnEdges = row.Zip(nextRow, (source, destination) => new WDiEdge() { Source = source, Destination = destination, Weight = destination.OriginalValue });
                    edges.AddRange(columnEdges);
                }
            }

            var result = new Graph()
            {
                Vertices = verticesMatrix,
                Edges = edges
            };
            return result;
        }
    }
}
