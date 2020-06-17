using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    [TestFixture]
    public class _41To50
    {
        [Test]
        public void Problem41()
        {
            var primesUnder1B = new SortedSet<long>(
                    Sequences
                        .PrimesUnder(1_000_000)
                        .ToList()
                );

            var sum = new BigInteger(0);
            for (int i = 1; i <= 9; i++)
            {
                sum += Functions.Permutations(i, i);
            }
            Console.WriteLine(sum);
        }

        [Test]
        public void Problem48()
        {
            var sum = new BigInteger(0);
            for (int i = 1; i <= 1000; i++)
            {
                sum += BigInteger.Pow(new BigInteger(i), i);
            }

            Assert.That(sum % BigInteger.Pow(10, 10), Is.EqualTo(new BigInteger(9_110_846_700)));
        }

        [Test]
        public void Problem49()
        {
            var bitMask = Enumerable.Range(0, 10)
                .Select(i => 0b111 << (i * 3))
                .ToArray();
            Func<long, long> getPermutationKey = (long number) => {
                long key = 0, digitSum;
                short digit;
                for (long modulus = 10, divisor = 1; divisor < number; modulus *= 10, divisor *= 10)
                {
                    digit = (short) ((number % modulus) / divisor);

                    // extract
                    digitSum = (key & bitMask[digit]);
                    // increment
                    digitSum += 1 << (digit * 3);
                    // set
                    key = key & ~bitMask[digit];
                    key = key | digitSum;
                }

                return key;
            };

            var permutationKeyToExclude = getPermutationKey(1487);

            var permutationDictionary = Sequences
                .PrimesUnder(10_000)
                .Where(x => x >= 1000)
                .GroupBy(x => getPermutationKey(x))
                .ToDictionary(x => x.Key, x => x.ToList())
                .Where(x => x.Key != permutationKeyToExclude && x.Value.Count >= 3)
                .ToDictionary(x => x.Key, x => x.Value);

            Func<List<long>, string> findAnswer = (List<long> numbers) =>
            {
                for (int y = 0; y < numbers.Count; y++)
                {
                    long numberForY = numbers[y];
                    for (int x = y + 1; x < numbers.Count; x++)
                    {
                        long numberForX = numbers[x];
                        long xyDifference = numberForX - numberForY;

                        for (int z = x + 1; z < numbers.Count; z++)
                        {
                            long numberForZ = numbers[z];
                            long zxDifference = numberForZ - numberForX;
                            if (xyDifference == zxDifference)
                                return $"{numberForY}{numberForX}{numberForZ}";
                            else if (zxDifference > xyDifference)
                                break;
                        }
                    }
                }

                return null;
            };


            foreach (var kvp in permutationDictionary)
            {
                var potentialAnswer = findAnswer(kvp.Value);
                if (potentialAnswer != null)
                {
                    Assert.That(potentialAnswer, Is.EqualTo(2969_6299_9629.ToString()));
                    break;
                }
            }


            Console.WriteLine();
        }

        [Test]
        public void Problem50()
        {
            // Assumptions:
            //   We are looking for a sequence that is 21 terms or longer.  This sequence does not
            //     contain 2.
            //   If the sequence contains 2, then it must also contain an odd number of primes above 2.
            //     e.g. the sequence length must be even.
            //   If the sequence does not contain 2, then it must contain an even number of primes above 2.
            //     e.g. the sequence length must be odd.
            //   Each sequence is going to sum to a number that is greater than the greatest number in
            //     the sequence.
            //     Given that there are ~79,000 primes under 1,000,000, there is at least one prime, pS,
            //       where a series of primes adds to pS, and each prime of the sequence is less than pS.
            //       That means there are at least 79,000 (79,000 + 1) / 2 evaluations.

            // Other observations:
            //   pS - p1 = p0
            //   pS - p2 - p1 = p0
            //   pS - p3 - p2 - p1 = p0

            // Not every even length sequence starting from 2 is prime:
            //   2
            //   3 => 5
            //   5 => 10
            //   7 => 17
            //   11 => 28
            //   13 => 41
            //   17 => 58
            //   19 => 77

            var primesUnder1M = Sequences.PrimesUnder(1_000_000)
                .ToArray();

            var primesLookup = new SortedSet<long>(primesUnder1M);

            //var firstAboveHalf = new long[primesUnder1M.Length];


            //for (int i = primesUnder1M.Length - 1; i >= 1; i--)
            //{
            //    var prime = primesUnder1M[i];
            //    var halfOfPrime = prime / 2;

            //    for (
            //        long j
            //            = i == primesUnder1M.Length - 1
            //                ? i - 1
            //                : firstAboveHalf[i + 1];
            //        j >= 0;
            //        j--
            //    ) {
            //        if (primesUnder1M[j] < halfOfPrime)
            //        {
            //            firstAboveHalf[i] = j + 1;
            //            break;
            //        }
            //    }

            //    Console.WriteLine(string.Join(", ", i, firstAboveHalf[i], prime, primesUnder1M[firstAboveHalf[i]]));
            //}

            long max = 0;
            long maxPrime = 0;
            for (int i = 0; i < primesUnder1M.Length; i++)
            {
                var sum = primesUnder1M[i];
                for (int j = i + 1; j < primesUnder1M.Length; j++)
                {
                    sum += primesUnder1M[j];

                    if (sum >= 1_000_000)
                    {
                        break;
                    }

                    if (primesLookup.Contains(sum))
                    {
                        if (max < j - i + 1)
                        {
                            max = j - i + 1;
                            maxPrime = sum;
                        }
                    }
                }
            }

            Assert.That(maxPrime, Is.EqualTo(997_651));
        }
    }
}
