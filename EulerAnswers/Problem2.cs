using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem2 : IAnswer
    {
        public string Answer()
        {
            return FibonacciNumbers().Where(item => item % 2 == 0).TakeWhile(item => item < 4000000).Sum().ToString();
        }

        private IEnumerable<long> FibonacciNumbers()
        {
            long n0 = 1;
            yield return n0;
            long n1 = 1;
            yield return n1;

            while (true)
            {
                var temp = n0 + n1;
                n0 = n1;
                n1 = temp;

                yield return temp;
            }
        }
    }
}
