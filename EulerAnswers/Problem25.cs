using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem25 : IAnswer
    {
        public string Answer()
        {
            var results = FibonacciNumbers().Zip(Enumerable.Range(1, int.MaxValue), (item1, item2) => Tuple.Create(item1, item2));
            foreach (var number in results)
            {
                var numberAsString = number.Item1.ToString();
                if (numberAsString.Length == 1000)
                {
                    return number.Item2.ToString();
                }
            }
            return "Not Found";
        }

        private IEnumerable<BigInteger> FibonacciNumbers()
        {
            BigInteger n0 = 1;
            yield return n0;
            BigInteger n1 = 1;
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
