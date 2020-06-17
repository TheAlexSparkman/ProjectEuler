using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    [TestFixture]
    public class _31To40
    {
        [Test]
        public void Problem34()
        {
            var factorials = new long[10];
            factorials[0] = 1;
            for (int i = 1; i < factorials.Length; i++)
                factorials[i] = factorials[i - 1] * i;


            var sum = 0;
            for (int i = 10; i < 10_000_000; i++)
            {
                var factSum = i.ToString()
                    .Select(x => (byte)x - (byte)'0')
                    .Select(x => factorials[x])
                    .Sum();

                if (factSum == i)
                    sum += i;
            }

            Assert.That(sum, Is.EqualTo(40_730));
        }

        [Test]
        public void Problem35()
        {

            var primesUnder1M = new SortedSet<long>(
                Sequences
                    .PrimesUnder(1_000_000)
                    .ToList()
            );


            long count = 13; // 13 under 100 according to problem definition.
            foreach (var prime in primesUnder1M.Where(x => x >= 100))
            {
                var allRotationsWereFound = true;

                var primeStr = prime.ToString();
                for (int rotationNo = 0; rotationNo < primeStr.Length - 1; rotationNo++)
                {
                    primeStr = primeStr.Substring(primeStr.Length - 1) + primeStr.Substring(0, primeStr.Length - 1);
                    if (!primesUnder1M.Contains(long.Parse(primeStr)))
                    {
                        allRotationsWereFound = false;
                        break;
                    }
                }


                if (allRotationsWereFound)
                {
                    count++;
                }
            }

            Assert.That(count, Is.EqualTo(55));
        }

        [Test]
        public void Problem36()
        {
            var sum = 0;

            // even length palindrome checks:
            for (int i = 1; i <= 999; i++)
            {
                {
                    var reversed = string.Join("", i.ToString().Reverse());
                    var palindrome = int.Parse(reversed + i.ToString());

                    var base2 = Convert.ToString(palindrome, 2);
                    if (Functions.IsPalindrome(palindrome) && Functions.IsPalindrome(base2))
                    {
                        sum += palindrome;
                        Console.WriteLine($"{palindrome} -> {base2}");
                    }
                }

                if (i < 10)
                {
                    var reversed = string.Join("", i.ToString().Reverse());
                    var palindrome = int.Parse(reversed + "0000" + i.ToString());

                    var base2 = Convert.ToString(palindrome, 2);
                    if (Functions.IsPalindrome(palindrome) && Functions.IsPalindrome(base2))
                    {
                        sum += palindrome;
                        Console.WriteLine($"{palindrome} -> {base2}");
                    }
                }
                if (i < 100)
                {
                    var reversed = string.Join("", i.ToString().Reverse());
                    var palindrome = int.Parse(reversed + "00" + i.ToString());

                    var base2 = Convert.ToString(palindrome, 2);
                    if (Functions.IsPalindrome(palindrome) && Functions.IsPalindrome(base2))
                    {
                        sum += palindrome;
                        Console.WriteLine($"{palindrome} -> {base2}");
                    }
                }
            }

            // odd length palindrome checks greater than 99.
            for (int i = 1; i <= 99; i++)
            {
                var reversed = string.Join("", i.ToString().Reverse());
                for (int middle = 0; middle < 10; middle++)
                {
                    var palindrome = int.Parse(reversed + middle.ToString() + i.ToString());

                    var base2 = Convert.ToString(palindrome, 2);
                    if (Functions.IsPalindrome(palindrome) && Functions.IsPalindrome(base2))
                    {
                        sum += palindrome;
                        Console.WriteLine($"{palindrome} -> {base2}");
                    }
                }

                if (i < 10)
                {
                    for (int middle = 0; middle < 10; middle++)
                    {
                        var palindrome = int.Parse(reversed + "0" + middle.ToString() + "0" + i.ToString());

                        var base2 = Convert.ToString(palindrome, 2);
                        if (Functions.IsPalindrome(palindrome) && Functions.IsPalindrome(base2))
                        {
                            sum += palindrome;
                            Console.WriteLine($"{palindrome} -> {base2}");
                        }
                    }
                }
            }

            // single length palindrome checks less than 10.
            for (int i = 1; i < 10; i++)
            {
                var palindrome = i;

                var base2 = Convert.ToString(palindrome, 2);
                if (Functions.IsPalindrome(base2))
                {
                    sum += palindrome;
                    Console.WriteLine($"{palindrome} -> {base2}");
                }
            }

            Assert.That(sum, Is.EqualTo(872_187));
        }

        [Test]
        public void Problem37()
        {
            var primesUnder1M = new SortedSet<long>(
                Sequences
                    .PrimesUnder(1_000_000)
                    .ToList()
            );

            long count = 0;
            long sum = 0;
            foreach (var prime in primesUnder1M.Where(x => x > 10))
            {
                var allTruncatesWereFound = true;
                var modulus = 1_000_000;
                while (prime > 0 && modulus > 1)
                {
                    if (!primesUnder1M.Contains(prime % modulus))
                    {
                        allTruncatesWereFound = false;
                        break;
                    }
                    else
                    {
                        modulus = modulus / 10;
                    }
                }

                var divisor = 10;
                while (prime > 0 && divisor < prime)
                {
                    if (!primesUnder1M.Contains(prime / divisor))
                    {
                        allTruncatesWereFound = false;
                        break;
                    }
                    else
                    {
                        divisor = divisor * 10;
                    }
                }

                if (allTruncatesWereFound)
                {
                    count++;
                    sum += prime;
                }
            }

            Console.WriteLine(count);
            Console.WriteLine(sum);
        }

        [Test]
        public void Problem39()
        {
            int[] perimeters = new int[1001];
            var max = 0;
            var maxPerimeter = -1;
            for (int a = 1; a < 1000; a++)
            {
                for (int b = a + 1; b < 1000; b++)
                {
                    var c = Math.Sqrt(a * a + b * b);
                    if (Math.Floor(c) == c)
                    {
                        var p = a + b + (int)c;
                        if (p <= 1000)
                        {
                            perimeters[p]++;

                            if (maxPerimeter == -1 || max < perimeters[p])
                            {
                                maxPerimeter = p;
                                max = perimeters[p];
                            }
                        }
                    }
                }
            }

            Assert.That(maxPerimeter, Is.EqualTo(840));
        }
    }
}
