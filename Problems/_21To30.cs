using Microsoft.Win32;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    [TestFixture]
    public class _21To30
    {
        [Test]
        public void Problem22()
        {
            const int aAlphaValue = ((byte)'A') - 1;
            Func<string, int> alphabeticalValue
                = (str) => str.Sum(c => ((byte)c) - aAlphaValue);

            var t = Directory.GetCurrentDirectory();

            var filename = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "names.txt");

            var sortedNameValues
                = File.ReadAllText(filename)
                    .Split(',')
                    .Select(x => x.Replace("\"", ""))
                    .OrderBy(x => x)
                    .Select(alphabeticalValue)
                    .ToArray();

            long sum = 0;
            for (int i = 0; i < sortedNameValues.Length; i++)
                sum += sortedNameValues[i] * (i + 1);

            Assert.That(sum, Is.EqualTo(871_198_282));

        }

        [Test]
        public void Problem24()
        {
            // What is the millionth lexicographic permutation of the digits 0-9?
            var digits = Enumerable.Range(0, 10).ToArray();
            var permutationMaxes = digits
                .OrderByDescending(x => x)
                .Select(x => Functions.Permutations(x, x))
                .ToArray();

            // The problem asks for the millionth.  We are using -1 to adjust
            // to 0 ranked lists.
            var targetPermutation = new BigInteger(1_000_000 - 1);

            var answer = new BigInteger[10];
            var remainders = new BigInteger[10];
            var unchosenList = digits.ToList();
            for (int i = 0; i < digits.Length; i++)
            {
                remainders[i] = targetPermutation % permutationMaxes[i];
                if (i == 0)
                {
                    answer[i] = unchosenList[(int)(targetPermutation / permutationMaxes[i])];
                }
                else
                {
                    answer[i] = unchosenList[(int)(remainders[i - 1] / permutationMaxes[i])];
                }
                unchosenList.Remove((int)(answer[i]));
            }

            Assert.That(string.Join("", answer), Is.EqualTo("2783915460"));
        }

        [Test]
        public void Problem25()
        {
            var sequence = Sequences.Fibonacci(new BigInteger(1), new BigInteger(1));

            var index = 0;
            foreach (var number in sequence)
            {
                index++;

                if (number.ToString().Length == 1000)
                    break;
            }

            Assert.That(index, Is.EqualTo(4_782));
        }

        [Test]
        public void Problem28()
        {
            var initial = 1;
            var final = 500;

            // top-left sum
            var topRightSum = 4 * Series.SumOfSquares(final) + 4 * Series.Arithemtic(final) + final * 1;
            var topLeftSum = topRightSum - 2 * Series.Arithemtic(final);
            var bottomLeftSum = topRightSum - 4 * Series.Arithemtic(final);
            var bottomRightSum = topRightSum - 6 * Series.Arithemtic(final);

            var middle = 1;

            var sum = middle + topRightSum + topLeftSum + bottomLeftSum + bottomRightSum;

            Assert.That(sum, Is.EqualTo(669171001));
        }

        [Test]
        public void Problem29()
        {
            // 2 <= a <= 100
            // 2 <= b <= 100
            // a ^ b
            // This produces ~10,000 terms.

            // Let the set A2 be the set of numbers a = 2
            // Let the set A4 be set of numbers a = 4
            // Let the set A8 be set of numbers a = 8

            // Sets A2 and A4 overlap, but have exclusive elements.
            // e.g. A2 where b = 2, or b is odd.
            //      A4 where 51 <= b <= 100

            // Sets A4 and A8 overlap
            // There is probably a neat trick to get around a brute
            // force approach, but this runs in less than 26ms

            var uniqueInts = new SortedSet<BigInteger>();
            for (BigInteger a = new BigInteger(2); a <= 100; a++)
            {
                for (int b = 2; b <= 100; b++)
                {
                    uniqueInts.Add(BigInteger.Pow(a, b));
                }
            }

            Assert.That(uniqueInts.Count, Is.EqualTo(9_183));
        }
    }
}
