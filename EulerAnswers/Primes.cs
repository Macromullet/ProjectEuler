using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public static class Primes
    {
        public static IEnumerable<int> UpTo(int value)
        {
            bool[] numbers = new bool[value];
            for (int i = 2; i < value; i++)
            {
                int currentNumber = i;
                if (!numbers[currentNumber])
                {
                    yield return currentNumber;
                }

                while (currentNumber < value)
                {
                    numbers[currentNumber] = true;
                    currentNumber += i;
                }
            }
        }
    }
}
