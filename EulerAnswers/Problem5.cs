using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem5 : IAnswer
    {
        public string Answer()
        {
            var result = FindSmallestMultiple(80);
            return result.ToString();
        }

        private long FindSmallestMultiple(long value)
        {
            long result = 1;
            Dictionary<long, int> allPrimeCounts = new Dictionary<long, int>();
            for (int i = 2; i <= value; i++)
            {
                var primeCounts = FindPrimeCounts(i);
                foreach (var kvPair in primeCounts)
                {
                    if (!allPrimeCounts.ContainsKey(kvPair.Key))
                    {
                        allPrimeCounts.Add(kvPair.Key, kvPair.Value);
                    }
                    else if (allPrimeCounts[kvPair.Key] < kvPair.Value)
                    {
                        allPrimeCounts[kvPair.Key] = kvPair.Value;
                    }
                }
            }

            foreach (var kvPair in allPrimeCounts)
            {
                for (int i = 0; i < kvPair.Value; i++)
                {
                    result *= kvPair.Key;
                }
            }

            return result;
        }

        public static Dictionary<long, int> FindPrimeCounts(long number)
        {
            Dictionary<long, int> primeCounts = new Dictionary<long, int>();
            long workingNumber = number;

            while (workingNumber > 1)
            {
                for (long i = 2; i <= number; i++)
                {
                    long remainder;
                    var result = Math.DivRem(workingNumber, i, out remainder);
                    if (remainder != 0)
                    {
                        continue;
                    }

                    if (!primeCounts.ContainsKey(i))
                    {
                        primeCounts.Add(i, 1);
                    }
                    else
                    {
                        primeCounts[i] = primeCounts[i] + 1;
                    }

                    workingNumber = result;
                    break;
                }
            }

            return primeCounts;
        }
    }
}
