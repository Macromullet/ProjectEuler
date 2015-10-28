using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem10 : IAnswer
    {
        public string Answer()
        {
            long result = 0;
            foreach (var prime in Primes.UpTo(2000000))
            {
                result += prime;
            }
            return result.ToString();
        }
    }
}
