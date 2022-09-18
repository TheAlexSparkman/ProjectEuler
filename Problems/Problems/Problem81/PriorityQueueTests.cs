using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems.Problem81
{
    [TestFixture]
    public class PriorityQueueTests
    {
        private PriorityQueue<long, string> _sut;

        [Test]
        public void ShouldPush()
        {
            var initialPriorityQueue = new []
            {
                new KeyValuePair<long, string>( 4, "4" ),
                new KeyValuePair<long, string>( 2, "2" ),
                new KeyValuePair<long, string>( 1, "1" ),
                new KeyValuePair<long, string>( 3, "3" ),
                new KeyValuePair<long, string>( 4, "4" )
            };
            _sut = CreatePriorityQueue(initialPriorityQueue);

            Assert.DoesNotThrow(() => _sut.Push(-1, "-1"));
            var actual = _sut.Pop();

            Assert.That(actual, Is.EqualTo("-1"));
        }

        [Test]
        public void ShouldPop()
        {
            var initialPriorityQueue = new []
            {
                new KeyValuePair<long, string>( 4, "4" ),
                new KeyValuePair<long, string>( 2, "2" ),
                new KeyValuePair<long, string>( 1, "1" ),
                new KeyValuePair<long, string>( 3, "3" ),
                new KeyValuePair<long, string>( 4, "4" )
            };
            _sut = CreatePriorityQueue(initialPriorityQueue);

            var actual = _sut.Pop();

            Assert.That(actual, Is.EqualTo("1"));
        }

        [Test]
        public void ShouldPopGivenOneValue()
        {
            var initialPriorityQueue = new []
            {
                new KeyValuePair<long, string>(1, "1")
            };
            _sut = CreatePriorityQueue(initialPriorityQueue);

            var actual = _sut.Pop();

            Assert.That(actual, Is.EqualTo("1"));
        }

        [Test]
        public void ShouldPopGivenMultipleEquivalentValues()
        {
            var initialPriorityQueue = new[]
            {
                new KeyValuePair<long, string>(1, "1"),
                new KeyValuePair<long, string>(2, "2"),
                new KeyValuePair<long, string>(3, "3"),
                new KeyValuePair<long, string>(1, "1"),
                new KeyValuePair<long, string>(2, "2"),
                new KeyValuePair<long, string>(3, "3")
            };
            _sut = CreatePriorityQueue(initialPriorityQueue);
            var expected = new[] { "1", "1", "2", "2", "3", "3" };

            var actual = new List<string>();
            actual.Add(_sut.Pop());
            actual.Add(_sut.Pop());
            actual.Add(_sut.Pop());
            actual.Add(_sut.Pop());
            actual.Add(_sut.Pop());
            actual.Add(_sut.Pop());

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldNotPopGivenEmpty()
        {
            _sut = new PriorityQueue<long, string>();

            Assert.Throws<InvalidOperationException>(() => _sut.Pop());
        }

        [Test]
        public void ShouldReprioritize()
        {
            var initialPriorityQueue = new[]
            {
                new KeyValuePair<long, string>(1, "a"),
                new KeyValuePair<long, string>(1, "b"),
            };
            _sut = CreatePriorityQueue(initialPriorityQueue);

            _sut.Reprioritize(1, 2, "a");
            var popResult1 = _sut.Pop();
            var popResult2 = _sut.Pop();

            Assert.That(popResult1, Is.EqualTo("b"));
            Assert.That(popResult2, Is.EqualTo("a"));
        }

        [Test]
        public void ShouldReprioritizeGivenNewPriorityValueGroupAlreadyExists()
        {
            var initialPriorityQueue = new[]
            {
                new KeyValuePair<long, string>(1, "a"),
                new KeyValuePair<long, string>(2, "b"),
            };
            _sut = CreatePriorityQueue(initialPriorityQueue);

            _sut.Reprioritize(1, 2, "a");
            var popResult1 = _sut.Pop();
            var popResult2 = _sut.Pop();

            Assert.That(popResult1, Is.EqualTo("b"));
            Assert.That(popResult2, Is.EqualTo("a"));
        }

        private PriorityQueue<long, string> CreatePriorityQueue(IEnumerable<KeyValuePair<long, string>> initialPriorityQueue)
        {
            var priorityQueue = new PriorityQueue<long, string>();
            foreach (var (priority, value) in initialPriorityQueue)
            {
                priorityQueue.Push(priority, value);
            }
            return priorityQueue;
        }
    }
}
