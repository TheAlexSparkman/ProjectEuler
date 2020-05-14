using System;
using System.Collections.Generic;
using System.Linq;
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
        {
            var numStr = num.ToString();

            if (numStr.Length % 2 != 0)
                return false;

            var left = numStr.Substring(0, numStr.Length / 2);
            string right;

            var builder = new StringBuilder();
            for (int i = numStr.Length - 1; numStr.Length / 2 <= i; i--)
            {
                builder.Append(numStr[i]);
            }
            right = builder.ToString();

            return left == right;
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
    }
}
