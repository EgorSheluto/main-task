using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERVALE
{
    public class Employee
    {

        protected string Id;

        protected string Surname;
        protected string Name;
        protected string Patronymic;

        protected DateTime BornDate;
        protected DateTime EmplDate;

        protected Employee()
        {

        }

        public Employee(string Id, string Surname, string Name, string Patronymic, DateTime BornDate, DateTime EmplDate)
        {
            this.Id = Id;
            this.Surname = Surname;
            this.Name = Name;
            this.Patronymic = Patronymic;
            this.BornDate = BornDate;
            this.EmplDate = EmplDate;
        }

        public string getSurname()
        {
            return this.Surname;
        }

        public string getName()
        {
            return this.Name;
        }

        public string getPatronymic()
        {
            return this.Patronymic;
        }

        public DateTime getEmplDate()
        {
            return this.EmplDate;
        }

        public string getId()
        {
            return Id;
        }

        public override string ToString()
        {
            return Id + "\t" + Surname + "\t" + Name + "\t" + Patronymic + "\t" + BornDate.ToShortDateString() + "\t" + EmplDate.ToShortDateString();
        }

        virtual public string ToString(string NameStaff)
        {
            return NameStaff + ";" + Id + ";" + Surname + ";" + Name + ";" + Patronymic + ";" + BornDate.ToShortDateString() + ";" + EmplDate.ToShortDateString();
        }
    }
}
