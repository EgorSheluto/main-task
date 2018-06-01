using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERVALE
{
    public class Manager : Employee
    {

        protected List<string> listOfEmpInHand;

        private Manager()
        {

        }

        public Manager(string Id, string Surname, string Name, string Patronymic, DateTime BornDate, DateTime EmplDate, List<string> listOfEmpInHand)
            : base(Id, Surname, Name, Patronymic, BornDate, EmplDate)
        {
            this.listOfEmpInHand = new List<string>(listOfEmpInHand);
        }

        public Manager(string Id, string Surname, string Name, string Patronymic, DateTime BornDate, DateTime EmplDate)
            : base(Id, Surname, Name, Patronymic, BornDate, EmplDate)
        {
            this.listOfEmpInHand = new List<string>();
        }

        public void AddEmpInHand(int indexId)
        {
            if (indexId != Convert.ToInt32(Id))
            {
                if (!listOfEmpInHand.Contains(indexId.ToString()))
                {
                    listOfEmpInHand.Add(indexId.ToString());
                }
            }
            else
            {
                Console.WriteLine("Нельзя добавить менеджера");
            }
        }

        public void DeleteEmpInHand(string Id)
        {
            listOfEmpInHand.Remove(Id);
        }

        public override string ToString()
        {
            string list = "";
            int i = 0;
            foreach (string item in listOfEmpInHand)
            {
                 if (i++ != listOfEmpInHand.Count - 1 && listOfEmpInHand.Count != 0)
                {
                    list += (item + ",");
                }
                else list += item;
            }

            return base.ToString() + "\t" + list;
        }

        public override string ToString(string NameStaff)
        {
            string list = "";
            int i = 0;
            foreach (string item in listOfEmpInHand)
	        {
                if (i++ != listOfEmpInHand.Count - 1 && listOfEmpInHand.Count != 0)
                {
                    list += (item + ",");
                }
                else list += item;

            }

            return base.ToString(NameStaff) + ";" + list;
        }
    }
}
