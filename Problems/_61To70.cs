using NUnit.Framework;
using Problems.MaxSumPath;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    [TestFixture]
    public class _61To70
    {
        [Test]
        public void Problem67()
        {
            var solver = new MaxSumPathSolver();
            var filename = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "p067_triangle.txt");
            var triangle = File.ReadAllText(filename);

            var answer = solver.Solve(triangle);
            Assert.That(answer, Is.EqualTo(7_273));
        }
    }
}
