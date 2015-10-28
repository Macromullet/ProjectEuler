using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem17 : IAnswer
    {
        public string Answer()
        {
            var query = from number in Enumerable.Range(1, 1000)
                        let numberAsString = NumberAsString(number)
                        select numberAsString;

            var numberLengths = from number in query
                                let trimmedNumber = number.Replace(" ", "").Replace("-", "")
                                select trimmedNumber.Length;

            var totalLength = numberLengths.Sum();

            return totalLength.ToString();
        }

        private string NumberAsString(int number)
        {
            if (number < 20)
            {
                return BuildBaseOneNumber(number);
            }

            var baseTwoRemainder = number % 100;

            string baseFourNumber = null;
            string baseThreeNumber = null;
            string baseTwoNumber = null;
            string baseOneNumber = null;
            var numberDigits = number.ToString().ToCharArray();
            for (int i = 0; i < numberDigits.Length; i++)
            {
                var digit = int.Parse(numberDigits[i].ToString());
                int exponent = numberDigits.Length - i;
                switch (exponent)
                {
                    case 1:
                        baseOneNumber = BuildBaseOneNumber(digit);
                        break;
                    case 2:
                        baseTwoNumber = BuildBaseTwoNumber(digit, baseTwoRemainder);
                        break;
                    case 3:
                        baseThreeNumber = BuildBaseThreeNumber(digit);
                        break;
                    case 4:
                        baseFourNumber = BuildBaseFourNumber(digit);
                        break;
                }
            }

            StringBuilder result = new StringBuilder();
            if (baseFourNumber != null)
            {
                result.Append(baseFourNumber);
            }
            if (baseThreeNumber != null)
            {
                if (result.Length > 0)
                {
                    result.Append(" and ");
                }
                result.Append(baseThreeNumber);
            }
            if (baseTwoNumber != null)
            {
                if (result.Length > 0)
                {
                    result.Append(" and ");
                }
                result.Append(baseTwoNumber);
            }
            if (baseOneNumber != null)
            {
                if (baseTwoNumber != null)
                {
                    if (baseTwoRemainder >= 20)
                    {
                        result.Append("-");
                    }
                    else
                    {
                        baseOneNumber = null;
                    }
                }
                else if (result.Length > 0)
                {
                    result.Append(" and ");
                }
                result.Append(baseOneNumber);
            }
            return result.ToString();
        }

        private string BuildBaseOneNumber(int number)
        {
            switch (number)
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                case 10:
                    return "ten";
                case 11:
                    return "eleven";
                case 12:
                    return "twelve";
                case 13:
                    return "thirteen";
                case 14:
                    return "fourteen";
                case 15:
                    return "fifteen";
                case 16:
                    return "sixteen";
                case 17:
                    return "seventeen";
                case 18:
                    return "eighteen";
                case 19:
                    return "nineteen";
                default:
                    return null;
            }
        }

        private string BuildBaseTwoNumber(int number, int baseTwoRemainder)
        {
            switch (number)
            {
                case 1:
                    return BuildBaseOneNumber(baseTwoRemainder);
                case 2:
                    return "twenty";
                case 3:
                    return "thirty";
                case 4:
                    return "forty";
                case 5:
                    return "fifty";
                case 6:
                    return "sixty";
                case 7:
                    return "seventy";
                case 8:
                    return "eighty";
                case 9:
                    return "ninety";
                default:
                    return null;
            }
        }

        private string BuildBaseThreeNumber(int number)
        {
            var baseOneNumber = BuildBaseOneNumber(number);
            if (baseOneNumber == null)
            {
                return null;
            }
            return baseOneNumber + " hundred";
        }

        private string BuildBaseFourNumber(int number)
        {
            var baseOneNumber = BuildBaseOneNumber(number);
            if (baseOneNumber == null)
            {
                return null;
            }
            return baseOneNumber + " thousand";
        }
    }
}
