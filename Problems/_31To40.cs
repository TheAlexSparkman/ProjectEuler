﻿using NUnit.Framework;
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
    }
}
