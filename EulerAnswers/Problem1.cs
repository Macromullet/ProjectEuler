using System.Linq;
using System.Numerics;

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

        private BigInteger AnswerSlow(int n)
        {
            BigInteger result = 0;
            var items = Enumerable.Range(1, n).Where(item => item % 3 == 0 || item % 5 == 0);
            foreach (var item in items)
            {
                result = result + item;
            }
            return result;
        }

        private BigInteger AnswerFast(int n)
        {
            var threes = NaturalSeriesSum(n, 3);
            var fives = NaturalSeriesSum(n, 5);
            var fifteens = NaturalSeriesSum(n, 15);
            return (threes + fives) - fifteens;
        }

        private BigInteger NaturalSeriesSum(BigInteger n, BigInteger increment)
        {
            BigInteger remainder;
            var term = BigInteger.DivRem(n, increment, out remainder);
            return NaturalSeriesSum(term) * increment;
        }

        private BigInteger NaturalSeriesSum(BigInteger n)
        {
            return (n * (n + 1)) / 2;
        }
    }
}
