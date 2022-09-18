using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems.Problem81
{
    [TestFixture]
    public class SolverTests
    {
        private Solver _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Solver();
        }

        [Test]
        public void ShouldFindMinimalPathSum()
        {
            var matrix = _sut.ParseMatrixFromString(Mother.MatrixFromProblem);

            var graph = _sut.ParseGraphFromMatrix(matrix);
            var start = graph.Vertices.First();
            var end = graph.Vertices.Last();

            var actual = _sut.FindMinimalPathSum(graph, start, end);

            Assert.That(actual, Is.EqualTo(427_337));
        }

        [Test]
        public void ShouldFindMinimalPathSumGivenExampleProblem()
        {
            var matrix = _sut.ParseMatrixFromString(Mother.MatrixFromExampleProblem);

            var graph = _sut.ParseGraphFromMatrix(matrix);
            var start = graph.Vertices.First();
            var end = graph.Vertices.Last();

            var actual = _sut.FindMinimalPathSum(graph, start, end);

            Assert.That(actual, Is.EqualTo(2_427));
        }

        [Test]
        public void ShouldParseMatrixFromString()
        {
            var stringMatrix = Mother._2x2StringMatrix;
            var expected = Mother._2x2Matrix;

            var actual = _sut.ParseMatrixFromString(stringMatrix);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldParseGraphFromMatrix()
        {
            var matrix = Mother._2x2Matrix;

            var startVertex = new Vertex { Y = -1, X = -1, OriginalValue = 0 };
            var vertexY0X0 = new Vertex { Y = 0, X = 0, OriginalValue = 1 };
            var vertexY0X1 = new Vertex { Y = 0, X = 1, OriginalValue = 2 };
            var vertexY1X0 = new Vertex { Y = 1, X = 0, OriginalValue = 3 };
            var vertexY1X1 = new Vertex { Y = 1, X = 1, OriginalValue = 4 };
            var expectedVertices = new[]
            {
                startVertex,
                vertexY0X0, vertexY0X1,
                vertexY1X0, vertexY1X1
            };

            var expectedEdges = new []
            {
                new WDiEdge { Source = vertexY0X0, Destination = vertexY0X1, Weight = vertexY0X1.OriginalValue },
                new WDiEdge { Source = vertexY0X0, Destination = vertexY1X0, Weight = vertexY1X0.OriginalValue },
                new WDiEdge { Source = vertexY0X1, Destination = vertexY1X1, Weight = vertexY1X1.OriginalValue },
                new WDiEdge { Source = vertexY1X0, Destination = vertexY1X1, Weight = vertexY1X1.OriginalValue }
            };
            vertexY0X0.OutgoingEdges = new List<WDiEdge> { expectedEdges[0], expectedEdges[1] };
            vertexY0X1.OutgoingEdges = new List<WDiEdge> { expectedEdges[2] };
            vertexY1X0.OutgoingEdges = new List<WDiEdge> { expectedEdges[3] };

            startVertex.OutgoingEdges = new[] { new WDiEdge { Source = startVertex, Destination = vertexY0X0, Weight = vertexY0X0.OriginalValue } };

            var actual = _sut.ParseGraphFromMatrix(matrix);

            Assert.That(actual.Vertices.ToList(), Is.EqualTo(expectedVertices.ToList()));
            var actualVertexEdgeTuples = actual.Vertices.SelectMany(vertex => vertex.OutgoingEdges.Select(edge => (vertex, edge)));
            var expectedVertexEdgeTuples = expectedVertices.SelectMany(vertex => vertex.OutgoingEdges.Select(edge => (vertex, edge)));
            Assert.That(actualVertexEdgeTuples, Is.EqualTo(expectedVertexEdgeTuples));
        }
    }
}
