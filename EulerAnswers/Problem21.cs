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
    public class Problem21 : IAnswer
    {
        public string Answer()
        {
            var max = 10_000;
            int[] amicableNumbers = new int[max];
            HashSet<int> matchingNumbers = new HashSet<int>();
            for (int baseValue = 1; baseValue < max; baseValue++)
            {
                for (int multiple = 2; multiple < max; multiple++)
                {
                    var product = baseValue * multiple;
                    if (product > baseValue && product < max)
                    {
                        amicableNumbers[product] += baseValue;
                    }
                    else
                    {
                        break; // short circuit here
                    }
                }

                var thisNumber = amicableNumbers[baseValue];
                if (thisNumber < 1)
                {
                    continue;
                }
                if (thisNumber > max)
                {
                    continue;
                }
                var otherNumber = amicableNumbers[thisNumber];
                if (otherNumber > max)
                {
                    continue;
                }
                if (otherNumber != thisNumber &&
                    amicableNumbers[otherNumber] == thisNumber)
                {
                    matchingNumbers.Add(thisNumber);
                    matchingNumbers.Add(otherNumber);
                }
            }
            var total = matchingNumbers.Sum();
            return total.ToString();
        }
    }
}
