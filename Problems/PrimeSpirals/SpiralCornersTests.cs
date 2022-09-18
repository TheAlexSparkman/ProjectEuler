using NUnit.Framework;

namespace Problems.PrimeSpirals
{
    [TestFixture]
    public class SpiralCornersTests
    {
        [Test]
        [TestCase(2, 9, 7, 5, 3)]
        [TestCase(3, 25, 21, 17, 13)]
        [TestCase(4, 49, 43, 37, 31)]
        public void ShouldConstruct(long i, long expectedBottomRight, long expectedBottomLeft, long expectedTopLeft, long expectedTopRight)
        {
            var actual = new SpiralCorners(i);

            Assert.That(actual.BottomRight, Is.EqualTo(expectedBottomRight));
            Assert.That(actual.BottomLeft, Is.EqualTo(expectedBottomLeft));
            Assert.That(actual.TopLeft, Is.EqualTo(expectedTopLeft));
            Assert.That(actual.TopRight, Is.EqualTo(expectedTopRight));
        }
    }
}
