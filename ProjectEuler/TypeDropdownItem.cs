using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class TypeDropdownItem
    {
        private static readonly string _NameSuffix = "Problem";

        public string Name { get; private set; }
        public int Order { get; private set; }
        public Type Type { get; private set; }

        public TypeDropdownItem(Type type)
        {
            Type = type;
            Name = type.Name;
            if (Name.StartsWith(_NameSuffix))
            {
                string numberPart = Name.Substring(_NameSuffix.Length, Name.Length - _NameSuffix.Length);
                int tempNumber;
                if (int.TryParse(numberPart, out tempNumber))
                {
                    Order = tempNumber;
                }
            }
        }
    }
}
