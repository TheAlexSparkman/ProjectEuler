using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class Functions
    {
        public static long LargestPrimeFactor(long number)
        {
            long sqrt = (long)Math.Floor(Math.Sqrt(number));
            for (long i = sqrt; i >= 2; i--)
            {
                if (number % i == 0)
                {
                    var largerFactor = number / i;
                    if (IsPrime(largerFactor))
                        return largerFactor;
                    else if (IsPrime(i))
                        return i;
                }
            }

            return number;
        }

        public static bool IsPrime(long number)
            => LargestPrimeFactor(number) == number;

        public static bool IsPalindrome(int num)
            => IsPalindrome(num.ToString());

        public static bool IsPalindrome(string str)
        {
            if (str.Length == 1)
                return true;

            string left;
            string right;
            if (str.Length % 2 == 1)
            {
                left = str.Substring(0, str.Length / 2);
                right = str.Substring(str.Length / 2 + 1);
            }
            else
            {
                left = str.Substring(0, str.Length / 2);
                right = str.Substring(str.Length / 2);
            }

            for (int i = 0; i < left.Length; i++)
            {
                if (left[i] != right[right.Length - i - 1])
                    return false;
            }

            return true;
        }

        public static bool IsDivisibleBy1To20(long num)
        {
            for (var i = 2; i <= 20; i++)
            {
                if (num % i != 0)
                    return false;
            }

            return true;
        }

        public static long SumOfSquares(long num)
        {
            long sum = 0;
            for (int i = 1; i <= num; i++)
            {
                sum += i * i;
            }

            return sum;
        }

        public static long SquareOfSequenceSum(long start, long end)
        {
            long sum = 0;
            for (long i = start; i <= end; i++)
            {
                sum += i;
            }

            return sum * sum;
        }

        public static long NextCollatz(long number)
            =>
                number % 2 == 0
                    ? number / 2
                    : 3 * number + 1;

        public static BigInteger Factorial(long number)
        {
            var result = new BigInteger(1);
            for (var i = 1; i <= number; i++)
                result *= i;

            return result;
        }

        public static BigInteger Permutations(long n, long r)
            => Factorial(n) / Factorial(n - r);

        public static BigInteger Combinations(long n, long r)
            => Permutations(n, r) / Factorial(r);

        public static long TriangleNumber(long n)
            => n * (n + 1) / 2;
        public static long PentagonalNumber(long n)
            => n * (3 * n - 1) / 2;
        public static long HexagonalNumber(long n)
            => n * (2 * n - 1);


        public static double[] FindRoots(double a, double b, double c)
        => new double[] {
            (-b + Math.Sqrt(b * b - 4 * a * c))
                /
                (2 * a),
            (-b - Math.Sqrt(b * b - 4 * a * c))
                /
                (2 * a)
        };
    }
}
