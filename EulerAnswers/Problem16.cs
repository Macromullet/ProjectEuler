using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem16 : IAnswer
    {
        public string Answer()
        {
            var largeNumber = BigInteger.Pow(2, 1000);
            var largeNumberDigits = largeNumber.ToString().ToCharArray();
            var query = from largeNumberDigit in largeNumberDigits
                        let digit = int.Parse(largeNumberDigit.ToString())
                        select digit;

            return query.Sum().ToString();
        }
    }
}
