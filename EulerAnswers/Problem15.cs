using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem15 : IAnswer
    {
        public string Answer()
        {
            var result = Lattice(20, 20);
            return result.ToString();
        }

        private BigInteger Lattice(int left, int right)
        {
            BigInteger numerator = 1;
            for (int i = left + right; i > left; i--)
            {
                numerator *= i;
            }

            BigInteger denominator = 1;
            for (int j = 1; j <= right; j++)
            {
                denominator *= j;
            }

            return numerator / denominator;
        }
    }
}
