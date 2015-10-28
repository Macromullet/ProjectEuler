using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem1 : IAnswer
    {
        public string Answer()
        {
            int number = 99999999;
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var result = AnswerSlow(number);
            stopwatch.Stop();
            var elapsedSlow = stopwatch.ElapsedMilliseconds;

            stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var fast = AnswerFast(number);
            stopwatch.Stop();
            var elapsedFast = stopwatch.ElapsedMilliseconds;
            return result.ToString();
        }

        private BigInteger AnswerSlow(int max)
        {
            BigInteger result = 0;
            var items = Enumerable.Range(1, max).Where(item => item % 3 == 0 || item % 5 == 0);
            foreach (var item in items)
            {
                result = result + item;
            }
            return result;
        }

        private BigInteger AnswerFast(int max)
        {
            var threes = NaturalSeriesSum(max, 3);
            var fives = NaturalSeriesSum(max, 5);
            var fifteens = NaturalSeriesSum(max, 15);
            return (threes + fives) - fifteens;
        }

        private BigInteger NaturalSeriesSum(BigInteger max, BigInteger increment)
        {
            BigInteger remainder;
            var term = BigInteger.DivRem(max, increment, out remainder);
            return NaturalSeriesSum(term) * increment;
        }

        private BigInteger NaturalSeriesSum(BigInteger n)
        {
            return (n * (n + 1)) / 2;
        }
    }
}
