using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERVALE
{
    class SurnameCompare<T> : IComparer<T>
        where T : Employee
    {
        public int Compare(T x, T y)
        {
            return x.getSurname().CompareTo(y.getSurname());
        }
    }
}
