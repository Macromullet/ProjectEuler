using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem14 : IAnswer
    {
        public string Answer()
        {
            var collatzCounts = from number in Enumerable.Range(1, 1000000)
                                select new { Number = number, Count = CollatzCount(number) };

            return collatzCounts.OrderByDescending(item=>item.Count).First().Number.ToString();
        }

        private long CollatzEven(long evenNumber)
        {
            return evenNumber / 2;
        }

        private long CollatzOdd(long oddNumber)
        {
            return (3 * oddNumber) + 1;
        }

        private Dictionary<long, int> _CollatzCounts = new Dictionary<long, int>();
        private int CollatzCount(long number)
        {
            int collatzCount;
            if (_CollatzCounts.TryGetValue(number, out collatzCount))
            {
                return collatzCount;
            }

            if (number == 1)
            {
                collatzCount = 1;
                _CollatzCounts.Add(number, collatzCount);
                return collatzCount;
            }

            if (number < 0)
            {
                System.Diagnostics.Debugger.Break();
            }

            bool isOdd = (number & 1) == 1;
            long nextNumber;
            if (isOdd)
            {
                nextNumber = CollatzOdd(number);
            }
            else
            {
                nextNumber = CollatzEven(number);
            }

            collatzCount = 1 + CollatzCount(nextNumber);
            _CollatzCounts.Add(number, collatzCount);
            return collatzCount;
        }
    }
}
