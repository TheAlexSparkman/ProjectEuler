using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public void Problem58()
        {
            long bottom_right, bottom_left, top_left, top_right;

            long primeCount = 8;
            long total = 13;
            long i = 5;

            while (true)
            {
                bottom_right = (2 * i - 1) * (2 * i - 1);
                bottom_left = bottom_right - 2 * i;
                top_left = bottom_right - 4 * i;
                top_right = bottom_right - 6 * i;

                if (Functions.IsPrime_WithMemoized(bottom_left))
                    primeCount++;

                if (Functions.IsPrime_WithMemoized(top_left))
                    primeCount++;

                if (Functions.IsPrime_WithMemoized(top_right))
                    primeCount++;

                total += 4;

                if (primeCount * 10 < total)
                    break;

                i++;
            }

            Console.WriteLine(2 * i - 1);

        }
    }
}
