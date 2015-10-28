using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem18 : IAnswer
    {
        private string _Numbers =
@"75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";

        public string Answer()
        {
            var grid = Problem11.ParseGrid<int>(_Numbers, int.Parse);
            UpdateMaxPathSums(grid);
            var result = grid[0][0];
            return result.ToString();
        }

        public static void UpdateMaxPathSums(int[][] grid)
        {
            for (int i = grid.Length - 1; i > 0; i--)
            {
                var line = grid[i];
                var previousLine = grid[i - 1];
                for (int j = 0; j < line.Length - 1; j++)
                {
                    previousLine[j] = previousLine[j] + Math.Max(line[j], line[j + 1]);
                }
            }
        }
    }
}
