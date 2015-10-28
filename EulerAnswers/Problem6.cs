using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem6 : IAnswer
    {
        public string Answer()
        {
            var result = SumOfSquaresMinusSquareOfSum(100);
            return result.ToString();
        }

        private long SumOfSquaresMinusSquareOfSum(long value)
        {
            return SquareOfSum(value) - SumOfSquares(value);
        }

        private long SquareOfSum(long value)
        {
            var infiniteSum = (value * (value + 1)) / 2;
            return infiniteSum * infiniteSum;
        }

        private long SumOfSquares(long value)
        {
            return (value * (value + 1) * ((2 * value) + 1)) / 6;
        }
    }
}
