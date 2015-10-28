using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem4 : IAnswer
    {
        public string Answer()
        {
            var largestPalindrome = FindLargestPalindrome(100, 999);
            return largestPalindrome.ToString();
        }

        private long FindLargestPalindrome(long min, long max)
        {
            long maxFoundPalindrome = -1;
            for (long i = max; i > min; i--)
            {
                for (long j = max; j > min; j--)
                {
                    long product = i * j;
                    if (product <= maxFoundPalindrome)
                    {
                        break;
                    }

                    if (IsPalindromic(product))
                    {
                        maxFoundPalindrome = product;
                    }
                }
            }

            return maxFoundPalindrome;
        }

        private bool IsPalindromic(long product)
        {
            var characters = product.ToString().ToCharArray();
            var length = characters.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (characters[i] != characters[length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
