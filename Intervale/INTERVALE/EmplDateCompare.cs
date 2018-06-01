using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERVALE
{
    class EmplDateCompare<T> : IComparer<T>
        where T : Employee
    {
        public int Compare(T x, T y)
        {
            return x.getEmplDate().CompareTo(y.getEmplDate());
        }
    }
}
