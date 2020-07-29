using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EulerAnswers
{
    public class Problem22 : IAnswer
    {
        public string Answer()
        {
            var names = EulerAnswers.Properties.Resources.p022_names;
            var namesList = names.Split(',').ToList();
            namesList.Sort();
            long totalForEntireFile = 0;
            for (int i = 0; i < namesList.Count; i++)
            {
                var nameOffset = i + 1;
                if (nameOffset == 938)
                {
                    System.Diagnostics.Debugger.Break();
                }
                var name = namesList[i].AsSpan();
                var aValue = (byte)'A';
                int nameValue = 0;
                for (int charOffset = 1; charOffset < name.Length - 1; charOffset++)
                {
                    var distanceFromA = ((byte)name[charOffset] - aValue) + 1;
                    nameValue += distanceFromA;
                }
                var nameTotal = nameOffset * nameValue;
                totalForEntireFile += nameTotal;
            }

            return totalForEntireFile.ToString();
        }
    }
}
