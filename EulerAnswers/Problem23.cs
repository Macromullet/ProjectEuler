using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem23 : IAnswer
    {
        public string Answer()
        {
            var max = 28_123;
            int[] sums = new int[max];
            for (int baseValue = 1; baseValue < max; baseValue++)
            {
                for (int multiple = 2; multiple < max; multiple++)
                {
                    var product = baseValue * multiple;
                    if (product > baseValue && product < max)
                    {
                        sums[product] += baseValue;
                    }
                    else
                    {
                        break; // short circuit here
                    }
                }
            }

            HashSet<int> allNumbers = new HashSet<int>(Enumerable.Range(1, max));
            for (int i = 1; i < max; i++)
            {
                if (sums[i] > i)
                {
                    // abundant
                    for (int j = 1; j < max; j++)
                    {
                        if (sums[j] > j)
                        {
                            // abundant
                            var sumOfAbundants = i + j;
                            allNumbers.Remove(sumOfAbundants);
                        }
                    }
                }
            }

            var sum = allNumbers.Sum();
            return sum.ToString();
        }
    }
}
