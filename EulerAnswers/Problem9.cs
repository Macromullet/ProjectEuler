using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem9 : IAnswer
    {
        public string Answer()
        {
            foreach (var triplet in FindPythagoreanTriplets(200000))
            {
                if (triplet.Item1 + triplet.Item2 + triplet.Item3 == 1000)
                {
                    var result = triplet.Item1 * triplet.Item2 * triplet.Item3;
                    return result.ToString();
                }
            }
            return "Not Found";
        }

        private IEnumerable<Tuple<int, int, int>> FindPythagoreanTriplets(int value)
        {
            foreach (var square in FindSquares(value))
            {
                foreach (var triplet in FindTriplets(square))
                {
                    yield return Tuple.Create(triplet.Item1, triplet.Item2, square);
                }
            }
        }

        private IEnumerable<int> FindSquares(int value)
        {
            for (int i = 1; i < value; i++)
            {
                var squareOfI = i * i;
                yield return i;
                if (squareOfI >= value)
                {
                    break;
                }
            }
        }

        private IEnumerable<Tuple<int, int>> FindTriplets(int square)
        {
            var squared = square * square;
            for (int i = 1; i < square - 1; i++)
            {
                for (int j = i + 1; j < square; j++)
                {
                    if (((i * i) + (j * j)) == squared)
                    {
                        yield return Tuple.Create(i, j);
                    }
                }
            }
        }
    }
}
