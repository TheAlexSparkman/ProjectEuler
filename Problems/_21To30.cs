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
    }
}
