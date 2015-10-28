using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem3 : IAnswer
    {
        public string Answer()
        {
            var primes = FindPrimes(600851475143);
            return primes.Max().ToString();
        }

        public static IEnumerable<long> FindPrimes(long number)
        {
            for (long i = 2; i < number; i++)
            {
                long remainder;
                var result = Math.DivRem(number, i, out remainder);
                if (remainder != 0)
                {
                    continue;
                }

                yield return i;
                number = result;
            }

            if (number > 0)
            {
                yield return number;
            }
        }
    }
}
