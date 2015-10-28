using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem67 : IAnswer
    {
        public string Answer()
        {
            string numbers = EulerAnswers.Properties.Resources.triangle;
            var grid = Problem11.ParseGrid<int>(numbers, "\n", int.Parse);
            Problem18.UpdateMaxPathSums(grid);
            var result = grid[0][0];
            return result.ToString();
        }
    }
}
