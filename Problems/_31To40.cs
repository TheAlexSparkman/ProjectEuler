using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    }
}
