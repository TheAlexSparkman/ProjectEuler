using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.MaxSumPath
{
    public class MaxSumPathSolver
    {

        public long Solve(string triangle)
        {
            var rows = triangle
                .Split(new string[] { "\r\n" }, StringSplitOptions.None)
                .Select(
                    row
                        =>
                    row.Split(' ')
                        .Select(number => int.Parse(number))
                        .ToArray()
                    )
                .ToArray();

            // Translate this into a graph.
            // The edges will be represented by the numbers.
            // The vertices
            //   1. For the top row, the vertex will be above the number.
            //   2. For the rest of the rows, the vertices will be the space between each number.
            // Edge weights will be negated.
            // Apply shortest distance algorithm.

            var vertices = new List<List<Vertex>>();

            // adding vertices
            vertices.Add(new List<Vertex>()
            {
                new Vertex()
            });

            for (var i = 1; i < rows.Length; i++)
            {
                var newVerticesRow = new List<Vertex>();
                var row = rows[i];
                for (var j = 0; j < row.Length - 1; j++)
                    newVerticesRow.Add(new Vertex());
                vertices.Add(newVerticesRow);
            }

            {
                var newVerticesRow = new List<Vertex>();
                var row = rows[rows.Length - 1];
                for (var j = 0; j < row.Length; j++)
                    newVerticesRow.Add(new Vertex());
                vertices.Add(newVerticesRow);
            }

            // Adding edges
            vertices[0][0].Add(vertices[1][0], -rows[0][0]);

            for (int rowIndex = 1; rowIndex < vertices.Count - 1; rowIndex++)
            {
                var fromRow = vertices[rowIndex];
                var toRow = vertices[rowIndex + 1];
                var weightsRow = rows[rowIndex];

                for (int fromIndex = 0; fromIndex < fromRow.Count; fromIndex++)
                {
                    var fromVertex = fromRow[fromIndex];

                    var leftVertex = toRow[fromIndex];
                    var leftWeight = -weightsRow[fromIndex];

                    var rightVertex = toRow[fromIndex + 1];
                    var rightWeight = -weightsRow[fromIndex + 1];

                    fromVertex.Add(leftVertex, leftWeight);
                    fromVertex.Add(rightVertex, rightWeight);
                }
            }

            var root = vertices[0][0];

            Vertex.BellmanFord(
                vertices: vertices
                            .SelectMany(x => x)
                            .ToList(),
                edges: vertices
                            .SelectMany(x => x)
                            .SelectMany(x => x)
                            .ToList(),
                root: root
            );


            var negatedAnswer = vertices[vertices.Count - 1]
                .OrderBy(x => x._distance)
                .FirstOrDefault()
                ._distance;

            var answer = -negatedAnswer;

            return answer;
        }
    }
}
