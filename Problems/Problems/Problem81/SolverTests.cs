using NUnit.Framework;

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
            _sut.FindMinimalPathSum(null);
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

            var vertexY0X0 = new Vertex() { Y = 0, X = 0, OriginalValue = 1 };
            var vertexY0X1 = new Vertex() { Y = 0, X = 1, OriginalValue = 2 };
            var vertexY1X0 = new Vertex() { Y = 1, X = 0, OriginalValue = 3 };
            var vertexY1X1 = new Vertex() { Y = 1, X = 1, OriginalValue = 4 };
            var expectedVertices = new Vertex[][]
            {
                new [] { vertexY0X0, vertexY0X1 },
                new [] { vertexY1X0, vertexY1X1 },
            };
            var expectedEdges = new []
            {
                new WDiEdge { Source = vertexY0X0, Destination = vertexY0X1, Weight = vertexY0X1.OriginalValue },
                new WDiEdge { Source = vertexY0X0, Destination = vertexY1X0, Weight = vertexY1X0.OriginalValue },
                new WDiEdge { Source = vertexY0X1, Destination = vertexY1X1, Weight = vertexY1X1.OriginalValue },
                new WDiEdge { Source = vertexY1X0, Destination = vertexY1X1, Weight = vertexY1X1.OriginalValue }
            };

            var actual = _sut.ParseGraphFromMatrix(matrix);

            for (var i = 0; i < actual.Vertices.Length; i++)
            {
                Assert.That(actual.Vertices[i], Is.EqualTo(expectedVertices[i]));
            }
            Assert.That(actual.Edges, Is.EqualTo(expectedEdges));
        }
    }
}
