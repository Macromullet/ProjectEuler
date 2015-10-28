using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem12 : IAnswer
    {
        public string Answer()
        {
            for (int i=2; i < int.MaxValue; i++)
            {
                var triangularNumber = FindTriangularNumber(i);
                var divisorCount = FindDivisorCount(triangularNumber);
                if (divisorCount > 500)
                {
                    return divisorCount.ToString();
                }
            }

            return "Not Found";
        }

        private long FindTriangularNumber(long number)
        {
            var result = (number * (number + 1)) / 2;
            return result;
        }

        private int FindDivisorCount(long number)
        {
            var primeCounts = Problem5.FindPrimeCounts(number);
            int result = 1;
            foreach (var keyValuePair in primeCounts)
            {
                result *= (keyValuePair.Value + 1);
            }

            return result;
        }
    }
}
