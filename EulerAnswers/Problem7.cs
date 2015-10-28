using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem7 : IAnswer
    {
        public string Answer()
        {
            var prime = NthPrime(10001);
            return prime.ToString();
        }

        private long NthPrime(int n)
        {
            return Primes.UpTo(1000000).ElementAt(n-1);
        }
    }
}
