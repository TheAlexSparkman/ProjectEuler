using NUnit.Framework;
using Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    [TestFixture]
    public class _628
    {
        [Test]
        [TestCase(3, 2)]
        [TestCase(4, 12)]
        [TestCase(5, 70)]
        [TestCase(6, 464)]
        [TestCase(7, 3498)]
        [TestCase(8, 29572)]
        public void Problem628(int n, int expectedLayouts)
        {
            var allPossiblePawnLayouts = Functions.Factorial(n);

            var layoutsWithPawnInBottomLeft = Functions.Factorial(n - 1);
            var layoutsWithPawnInTopRight = layoutsWithPawnInBottomLeft;

            var layoutsWithPawnInBottomLeftAndTopRight = Functions.Factorial(n - 2);

            var compatibleLayouts
                = allPossiblePawnLayouts
                - layoutsWithPawnInBottomLeft
                - layoutsWithPawnInTopRight
                + layoutsWithPawnInBottomLeftAndTopRight;

            var layoutsThatCannotBeCrossed = LayoutsThatCannotBeCrossed(n);

            var workingLayouts
                = compatibleLayouts
                    - layoutsThatCannotBeCrossed;

            Assert.That(workingLayouts, Is.EqualTo(new BigInteger(expectedLayouts)));
        }

        [Test]
        [TestCase(3, 2)]
        [TestCase(4, 12)]
        [TestCase(5, 70)]
        [TestCase(6, 464)]
        [TestCase(7, 3498)]
        [TestCase(8, 29572)]
        public void x(int n, int expectedLayouts)
        {
            var fullSequence = string.Join("", Enumerable.Range(1, n).Select(x => x.ToString()));

            var starters = Enumerable
                .Range(1, n - 2)
                .Select(x => fullSequence.Substring(x));
            var enders = Enumerable
                .Range(2, n - 2)
                .Select(x => fullSequence.Substring(0, x));
            var validPermutations = Sequences
                .PermutationsOf(n)
                .Select(x => x.ToString())
                .Where(x => !x.StartsWith($"{n}"))
                .Where(x => !x.EndsWith("1"))
                .Where(x => x != fullSequence)
                .Where(x => !starters.Any(starter => x.StartsWith(starter)))
                .Where(x => !enders.Any(enders => x.EndsWith(enders)))
                .ToList();

            TestContext.Out.WriteLine(validPermutations.Count);

            //foreach (var permutation in validPermutations)
            //{
            //    TestContext.Out.WriteLine(permutation);
            //}

            Assert.That(validPermutations, Has.Exactly(expectedLayouts).Items);
        }

        [TestCase(3, 2)]
        [TestCase(4, 12)]
        [TestCase(5, 70)]
        [TestCase(6, 464)]
        [TestCase(7, 3498)]
        [TestCase(8, 29572)]
        public void Problem628a(int n, int expectedLayouts)
        {
            var workingLayouts = (n*n - 3*n + 1) * Functions.Factorial(n - 2) + 2 * Functions.Factorial(n / 2 - 2) + n / 2 - 2;

            Assert.That(workingLayouts, Is.EqualTo(new BigInteger(expectedLayouts)));
        }

        public BigInteger LayoutsThatCannotBeCrossed(int n)
        {
            BigInteger sum = 1;
            for (int x = 2; x <= n / 2; x++)
            {
                sum += 2 * (Functions.Factorial(n - x) - Functions.Factorial(n - x - 1)) - 1;
            }

            return sum;
        }
    }
}
