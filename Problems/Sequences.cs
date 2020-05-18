﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class Sequences
    {

        public static IEnumerable<long> Fibonacci(long firstTerm, long secondTerm)
        {
            yield return firstTerm;
            yield return secondTerm;

            long temp;
            while (true)
            {
                yield return firstTerm + secondTerm;
                temp = secondTerm;
                secondTerm = firstTerm + secondTerm;
                firstTerm = temp;
            }
        }

        public static IEnumerable<BigInteger> Fibonacci(BigInteger firstTerm, BigInteger secondTerm)
        {
            yield return firstTerm;
            yield return secondTerm;

            BigInteger temp;
            while (true)
            {
                yield return firstTerm + secondTerm;
                temp = secondTerm;
                secondTerm = firstTerm + secondTerm;
                firstTerm = temp;
            }
        }

        public static IEnumerable<long> PrimeNumbers()
        {
            yield return 2;
            yield return 3;
            yield return 5;
            yield return 7;
            yield return 11;
            long i = 11;
            while (true)
            {
                i += 2;
                if (Functions.IsPrime(i))
                    yield return i;
            }
        }

        public static IEnumerable<long> TriangleNumbers()
        {
            long sum = 0;
            long i = 1;
            while (true)
            {
                yield return sum += i;
                i++;
            }
        }
        public static List<long> UniqueDivisors(long number)
            => Divisors(number)
                .Distinct()
                .ToList();

        private static IEnumerable<long> Divisors(long number)
        {
            long sqrt = (long)Math.Floor(Math.Sqrt(number));
            yield return 1;
            for (long i = 2; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    yield return i;
                    foreach (var factor in Divisors(number / i))
                        yield return factor;
                    yield return number / i;

                    break;
                }
            }
            yield return number;
        }

        public static IEnumerable<long> PrimesUnder(long n)
        {
            // Sieve of Eratosthenes.
            var isComposite = new bool[n];
            var sqrtOfN = (long)Math.Floor(Math.Sqrt(n));

            long i;
            for (i = 2; i <= sqrtOfN; i++)
            {
                if (!isComposite[i])
                    for (long j = 0; i * i + j * i < n; j++)
                        isComposite[i * i + i * j] = true;

                if (!isComposite[i])
                    yield return i;
            }

            for (; i < n; i++)
            {
                if (!isComposite[i])
                    yield return i;
            }
        }
    }
}
