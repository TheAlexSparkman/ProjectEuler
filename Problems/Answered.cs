﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    [TestFixture]
    public class Answered
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

        [Test]
        public void Problem11()
        {
            short[,] grid = new short[,] {
                { 08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08 },
                { 49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00 },
                { 81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65 },
                { 52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91 },
                { 22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80 },
                { 24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50 },
                { 32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70 },
                { 67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21 },
                { 24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72 },
                { 21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95 },
                { 78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92 },
                { 16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57 },
                { 86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58 },
                { 19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40 },
                { 04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66 },
                { 88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69 },
                { 04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36 },
                { 20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16 },
                { 20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54 },
                { 01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48 }
            };

            // traversals ways = 3 (horizontal, vertical, diagonal)
            // product = 3

            long largestProduct = 0;
            // vertical traversal
            for (int y = 0; y < grid.GetLength(0) - 3; y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    long product = 1;
                    for (int offset = 0; offset < 4; offset++)
                    {
                        product *= grid[y + offset, x];

                        largestProduct= Math.Max(largestProduct, product);
                    }
                }
            }

            // horizontal traversal
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1) - 3; x++)
                {
                    long product = 1;
                    for (int offset = 0; offset < 4; offset++)
                    {
                        product *= grid[y, x + offset];

                        largestProduct = Math.Max(largestProduct, product);
                    }
                }
            }

            // top-left to bottom-right diagonal traversals
            for (int y = 0; y < grid.GetLength(0) - 3; y++)
            {
                for (int x = 0; x < grid.GetLength(1) - 3; x++)
                {
                    long product = 1;
                    for (int offset = 0; offset < 4; offset++)
                    {
                        product *= grid[y + offset, x + offset];

                        largestProduct = Math.Max(largestProduct, product);
                    }
                }
            }

            // bottom-left to top-right diagonal traversals
            for (int y = 3; y < grid.GetLength(0) - 3; y++)
            {
                for (int x = 0; x < grid.GetLength(1) - 3; x++)
                {
                    long product = 1;
                    for (int offset = 0; offset < 4; offset++)
                    {
                        product *= grid[y - offset, x + offset];

                        largestProduct = Math.Max(largestProduct, product);
                    }
                }
            }

            Assert.That(largestProduct, Is.EqualTo(70_600_674));
        }

        [Test]
        public void Problem12()
        {

        }
    }
}
