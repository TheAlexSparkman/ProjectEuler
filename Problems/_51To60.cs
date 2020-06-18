using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    [TestFixture]
    public class _51To60
    {
        [Test]
        public void Problem56()
        {
            var digitalMax = 0;
            for (int a = 1; a < 100; a++)
            {
                for (int b = 1; b < 100; b++)
                {
                    var pow = BigInteger.Pow(a, b).ToString().Select(x => x - (byte)'0').Sum();
                    if (digitalMax < pow)
                        digitalMax = pow;
                }
            }

            Assert.That(digitalMax, Is.EqualTo(972));
        }

        [Test]
        public void Problem46()
        {
            var primes = new SortedSet<long>(Sequences.PrimesUnder(1_000_000));

            
        }
    }
}
