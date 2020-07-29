using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem20 : IAnswer
    {
        public string Answer()
        {
            BigInteger result = 1;
            for (var i = 1; i <= 100; i++)
            {
                result *= i;
            }

            int summedCharacters = 0;
            var resultCharacters = result.ToString().AsSpan();
            for (int i=0;i<resultCharacters.Length;i++)
            {
                var value = int.Parse(resultCharacters.Slice(i, 1));
                summedCharacters += value;
            }

            return summedCharacters.ToString();
        }
    }
}
