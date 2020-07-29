using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem19 : IAnswer
    {
        public string Answer()
        {
            DateTime startDate = new DateTime(1901, 1, 1);
            DateTime endDate = new DateTime(2000, 12, 31);
            int result = 0;
            for (DateTime currentDate = startDate; currentDate < endDate; currentDate = currentDate.AddDays(1))
            {
                if (currentDate.Day == 1 && currentDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    result++;
                }
            }

            return result.ToString();
        }
    }
}
