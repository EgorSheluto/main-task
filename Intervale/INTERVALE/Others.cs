using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERVALE
{
    class Others : Employee
    {

        protected string info;

        private Others()
        {

        }

        public Others(string Id, string Surname, string Name, string Patronymic, DateTime BornDate, DateTime EmplDate, string info) 
            : base(Id, Surname, Name, Patronymic, BornDate, EmplDate)
        {
            this.info = info;
        }

        public Others(string Id, string Surname, string Name, string Patronymic, DateTime BornDate, DateTime EmplDate)
            : base(Id, Surname, Name, Patronymic, BornDate, EmplDate)
        {
            this.info = null;
        }

        public override string ToString()
        {
            return base.ToString() + "\t" + info;
        }

        public override string ToString(string NameStaff)
        {
            return base.ToString(NameStaff) + ";" + info;
        }
    }
}
