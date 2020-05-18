using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class Series
    {
        public static long Arithemtic(long n)
            => n * (n + 1) / 2;

        public static long SumOfSquares(long n)
            => n * (n + 1) * (2 * n + 1)
                /
                6;
    }
}
