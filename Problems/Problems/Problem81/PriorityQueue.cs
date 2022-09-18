using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems.Problem81
{
    public class PriorityQueue<TPriority, TValue>
    {
        private readonly SortedList<TPriority, List<TValue>> _sortedList;

        public PriorityQueue()
        {
            _sortedList = new SortedList<TPriority, List<TValue>>();
        }

        public PriorityQueue(IEnumerable<KeyValuePair<TPriority, TValue>> initialPriorityQueue)
        {
            var groupedItems = initialPriorityQueue
                .GroupBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Select(x => x.Value).ToList());

            _sortedList = new SortedList<TPriority, List<TValue>>(groupedItems);
        }

        public void Push(TPriority priority, TValue value)
        {
            if (_sortedList.ContainsKey(priority))
            {
                _sortedList[priority].Add(value);
            }
            else
            {
                var valuesGroup = new List<TValue> { value };
                _sortedList.Add(priority, valuesGroup);
            }
        }

        public TValue Pop()
        {
            var (_, group) = _sortedList.First();

            var value = group.First();
            group.RemoveAt(0);
            if (!group.Any())
            {
                _sortedList.RemoveAt(0);
            }

            return value;
        }

        public void Reprioritize(TPriority oldPriority, TPriority newPriority, TValue value)
        {
            var oldValueGroup = _sortedList[oldPriority];
            oldValueGroup.Remove(value);
            if (!oldValueGroup.Any())
            {
                _sortedList.Remove(oldPriority);
            }

            Push(newPriority, value);
        }

        public bool Any() => _sortedList.Any();
    }
}
