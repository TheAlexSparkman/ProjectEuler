using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problems
{
    [TestFixture]
    public class _1To10
    {
        [Test]
        public void Problem1()
        {
            var sum = 0;
            for (int i = 3; i < 1000; i += 3)
            {
                sum += i;
            }

            for (int i = 5; i < 1000; i += 5)
            {
                if (i % 3 != 0)
                    sum += i;
            }

            Console.WriteLine(sum);

            Assert.Pass();
        }

        [Test]
        public void Problem2()
        {
            long sum = 0;
            foreach (long term in Sequences.Fibonacci(1, 2))
            {
                if (term >= 4_000_000)
                    break;

                Console.WriteLine(term);
                if (term % 2 == 0)
                    sum += term;
            }

            Console.WriteLine(sum);
        }

        [Test]
        public void Problem3()
        {
            Console.WriteLine(Functions.LargestPrimeFactor(600_851_475_143));
        }

        [Test]
        public void Problem4()
        {
            int largestPalindrome = 1;
            for (int i = 999; 99 <= i; i--)
            {
                for (int j = 999; 99 <= j; j--)
                {
                    var product = i * j;
                    if (Functions.IsPalindrome(product))
                    {
                        largestPalindrome = Math.Max(product, largestPalindrome);
                    }
                }
            }

            Console.WriteLine(largestPalindrome);
        }

        [Test]
        public void Problem5()
        {
            var num = 2520;
            while (true)
            {
                if (Functions.IsDivisibleBy1To20(num))
                {
                    Console.WriteLine(num);
                    break;
                }
                num += 2;
            }
        }

        [Test]
        public void Problem6()
        {
            var answer = Functions.SquareOfSequenceSum(1, 100) - Functions.SumOfSquares(100);
            Assert.That(answer, Is.EqualTo(25164150));
        }

        [Test]
        public void Problem7()
        {
            var answer
                = Sequences.PrimeNumbers()
                    .Skip(10_000)
                    .First();

            Assert.That(answer, Is.EqualTo(104743));
        }

        [Test]
        public void Problem8()
        {
            var thousandDigitNumber =
@"73167176531330624919225119674426574742355349194934
96983520312774506326239578318016984801869478851843
85861560789112949495459501737958331952853208805511
12540698747158523863050715693290963295227443043557
66896648950445244523161731856403098711121722383113
62229893423380308135336276614282806444486645238749
30358907296290491560440772390713810515859307960866
70172427121883998797908792274921901699720888093776
65727333001053367881220235421809751254540594752243
52584907711670556013604839586446706324415722155397
53697817977846174064955149290862569321978468622482
83972241375657056057490261407972968652414535100474
82166370484403199890008895243450658541227588666881
16427171479924442928230863465674813919123162824586
17866458359124566529476545682848912883142607690042
24219022671055626321111109370544217506941658960408
07198403850962455444362981230987879927244284909188
84580156166097919133875499200524063689912560717606
05886116467109405077541002256983155200055935729725
71636269561882670428252483600823257530420752963450"
                .Replace("\r\n", "");

            long largestProduct = 0;
            for (int i = 0; i < thousandDigitNumber.Length - 12; i++)
            {
                var thirteenDigits = thousandDigitNumber
                    .Substring(i, 13)
                    .Select(x => long.Parse(x.ToString()));

                long product = 1;
                foreach (long num in thirteenDigits)
                {
                    product *= num;
                }

                largestProduct = Math.Max(largestProduct, product);
            }

            Assert.That(largestProduct, Is.EqualTo(23514624000));
        }

        [Test]
        public void Problem9()
        {
            for (long c = 998; 1 <= c; c--)
            {
                for (long b = 1; b < c && b + c <= 999; b++)
                {
                    long a = 1000 - b - c;
                    if (a >= b)
                        continue;

                    if ((a * a + b * b) == c * c)
                    {
                        long answer = a * b * c;
                        Assert.That(answer, Is.EqualTo(31_875_000));
                        return;
                    }
                }
            }
        }

        [Test]
        public void Problem10()
        {
            long sum = 0;
            foreach (var prime in Sequences.PrimeNumbers())
            {
                if (prime >= 2_000_000)
                    break;
                sum += prime;
            }

            long answer = sum;
            Assert.That(answer, Is.EqualTo(142_913_828_922));
        }

    }
}
