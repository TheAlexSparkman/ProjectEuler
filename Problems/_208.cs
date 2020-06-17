using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    [TestFixture]
    public class _208
    {
        [Test]
        public void Problem208()
        {
            // How many paths of length 70, return it to its start position?
            // Each path of length 70 has a decision at each step, with two options.
            // This means there are 2^70 paths.  A naive approach will not be
            // able to solve this problem.
            // A path can be represented by a 70-bit number.

            // The paths of length 5 that return it to its starting position are 2.
            // - Are there any common characteristics of these two paths?
            //   - The paths are: 00000 and 11111.
            //   - What is the bit representation of the problem's example path?
            //     0100011110101011110110111
            //     - How many 0s? 9
            //     - How many 1s? 16
            //     - 
            //     - If you remove the 01 pairs, and then count the consecutive bits
            //       that are the same, this gives you a potential.  If this potential
            //       is equal to a p % 5 == 0, maybe it would equate to a return?
            //       01--01+++010101+++01+01++
            //       - 01 = 7
            //       -  - = 2
            //       -  + = 7
            //     - Contradictive point:
            //       01010101010101010101010101010111111

            //paths of 5: 32
            //paths of 5 that return to its starting position: 2
            //Left turns -Right turns = 5
            //    This group had 1 paths that returned to the starting position.
            //    This group had 1 paths total
            //Left turns -Right turns = -5
            //    This group had 1 paths that returned to the starting position.
            //    This group had 1 paths total


            //paths of 10: 1024
            //paths of 10 that return to its starting position: 12
            //Left turns -Right turns = 10
            //    This group had 1 paths that returned to the starting position.
            //    This group had 1 paths total
            //Left turns -Right turns = 0
            //    This group had 10 paths that returned to the starting position.
            //    This group had 252 paths total
            //Left turns -Right turns = -10
            //    This group had 1 paths that returned to the starting position.
            //    This group had 1 paths total


            //paths of 15: 32768
            //paths of 15 that return to its starting position: 188
            //Left turns -Right turns = 15
            //    This group had 1 paths that returned to the starting position.
            //    This group had 1 paths total
            //Left turns -Right turns = 5
            //    This group had 93 paths that returned to the starting position.
            //    This group had 3003 paths total
            //Left turns -Right turns = -5
            //    This group had 93 paths that returned to the starting position.
            //    This group had 3003 paths total
            //Left turns -Right turns = -15
            //    This group had 1 paths that returned to the starting position.
            //    This group had 1 paths total


            //paths of 20: 1048576
            //paths of 20 that return to its starting position: 3400
            //Left turns -Right turns = 20
            //    This group had 1 paths that returned to the starting position.
            //    This group had 1 paths total
            //Left turns -Right turns = 10
            //    This group had 484 paths that returned to the starting position.
            //    This group had 15504 paths total
            //Left turns -Right turns = 0
            //    This group had 2430 paths that returned to the starting position.
            //    This group had 184756 paths total
            //Left turns -Right turns = -10
            //    This group had 484 paths that returned to the starting position.
            //    This group had 15504 paths total
            //Left turns -Right turns = -20
            //    This group had 1 paths that returned to the starting position.
            //    This group had 1 paths total

            // What other questions can we ask?

            // What happens if we count the number of times a path reaches an
            // angle?
            var robot = new Robot();
            PathAngleCount(20);
        }

        /// <summary>
        /// This will return the number of possible combinations for a subsets of paths of x.
        /// These subsets are keyed by the sum of left decisions (1), and right decisions (-1).
        /// Only the subsets where the sum of left decisions and right deicisons is divisble by 10.
        /// 
        /// The answer to Combs(70) is still intractable.
        /// </summary>
        /// <param name="x"></param>
        public void Combs(int x)
        {

            BigInteger sum = new BigInteger(0);
            sum += Functions.Combinations(x, x / 2);

            for (int i = x / 2 + 5; i < x; i += 10)
            {
                sum += 2 * Functions.Combinations(x, i);
            }

            sum += 2;


            Console.WriteLine($"The number of subsets to explore: {sum}");
        }

        public void PathAngleCount(int length)
        {
            var robot = new Robot();
            var paths = Path(robot, length);

            paths
                .Where(x => x.Equals(robot))
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }


        public void Path(int length)
        {
            var robot = new Robot();

            Console.WriteLine($"paths of {length}: {1 << length}");
            var paths = Path(robot, length);
            Console.WriteLine($"paths of {length} that return to its starting position: {paths.Count(x => x.Equals(robot))}");

            paths
                .Where(x => robot.Equals(x))
                .GroupBy(x => x.Path.Count(y => y)-x.Path.Count(y => !y))
                .ToList()
                .ForEach(x => {
                    Console.WriteLine($"Left turns - Right turns = {x.Key}");
                    Console.WriteLine($"\tThis group had {x.Count()} paths that returned to the starting position.");
                    Console.WriteLine($"\tThis group had {paths.Count(y => x.Key == y.Path.Count(z => z) - y.Path.Count(z => !z))} paths total");
                });

            Console.WriteLine();
            Console.WriteLine();
        }

        public List<Robot> Path(Robot robot, int length)
        {
            if (length == 0)
                return new List<Robot>() { robot };
            else
            {
                var x = Path(robot.RotateLeft(), length - 1);
                x.AddRange(Path(robot.RotateRight(), length - 1));

                return x;
            }
        }
    }

    public class Robot : IEquatable<Robot>
    {
        public P Location { get; set; } = new P(1, 0);
        /// <summary>
        /// This represents the orientation of the robot.
        /// This is the angle from its current angle in degrees.
        /// </summary>
        public double Orientation { get; set; } = 90;

        public List<bool> Path { get; set; } = new List<bool>();


        public static readonly Dictionary<double, int> OrientationIndexMap = new Dictionary<double, int>() {
            { 90.0, 0 },
            { 162.0, 1 },
            { 234.0, 2 },
            { 306.0, 3 },
            {  18.0, 4 }
        };


        public int[] AngleCounts { get; } = new[] { 0, 0, 0, 0, 0 };

        public Robot RotateLeft()
            => Rotate(72.0);

        public Robot RotateRight()
            => Rotate(-72.0);

        internal Robot Rotate(double degrees)
        {
            // What are we going to rotate about?
            var radians = Orientation * Math.PI / 180.0;
            var radians2 = radians + (degrees > 0 ? (Math.PI / 2.0) : (3.0 * Math.PI / 2.0));

            var originOfRotation
                = Location
                - new P(
                    Math.Cos(radians2),
                    Math.Sin(radians2)
                );

            var framedLocation = Location - originOfRotation;

            var rotRadians = degrees * Math.PI / 180.0;
            var t = new P(
                framedLocation.X * Math.Cos(rotRadians) - framedLocation.Y * Math.Sin(rotRadians),
                framedLocation.X * Math.Sin(rotRadians) + framedLocation.Y * Math.Cos(rotRadians)
            );

            var newOrientation = (Orientation + degrees) % 360;

            var newRobot = new Robot()
            {
                Location = t + originOfRotation,
                Orientation = newOrientation < 0 ? newOrientation + 360 : newOrientation,
                Path = Path.ToList().Concat(new List<bool>() { degrees > 0 }).ToList()
            };

            newRobot.SetAngleCounts(AngleCounts, Orientation, degrees > 0);

            return newRobot;
        }

        public void SetAngleCounts(int[] angleCounts, double orientation, bool leftTurn)
        {
            for (int i = 0; i < angleCounts.Length; i++)
            {
                AngleCounts[i] = angleCounts[i];
            }

            AngleCounts[OrientationIndexMap[orientation]] += leftTurn ? 1 : -1;
        }

        public override string ToString()
            => $"[{Location}, {Orientation}, {string.Join("", Path.Select(x => x ? "1" : "0"))}][{string.Join(", ", AngleCounts)}]";

        public bool Equals(Robot other)
            => Orientation == other.Orientation && Location.Equals(other.Location);
    }

    public class P : IEquatable<P>
    {
        public P(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public static P operator +(P a, P b) => new P(a.X + b.X, a.Y + b.Y);
        public static P operator -(P a, P b) => new P(a.X - b.X, a.Y - b.Y);

        public override string ToString()
            => $"{X:F4}, {Y:F4}";

        public bool Equals(P other)
            => EqualsToTolerance(X, other.X) && EqualsToTolerance(Y, other.Y);

        public static bool EqualsToTolerance(double a, double b)
            => a - 0.01 <= b && b <= a + 0.01;
    }
}