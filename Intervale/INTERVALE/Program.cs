using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERVALE
{
    class Program
    {
        static StaffList<Employee> Staff;
        static void Main(string[] args)
        {
            Staff = new StaffList<Employee>();
            Staff.LoadStaff();
            while (userAnswer());

            return;
        }

        static bool userAnswer()
        {
            string questUser = "1 - Список персонала\n" + "2 - Добавление\n" + "3 - Удаление\n" + "4 - Изменение типа сотрудника\n" + "5 - Привязать сотрудника к менеджеру\n" + "6 - Сортировать список по фамилиям\n" + "7 - Сортировать список по датам принятия на работу\n" + "8 - Выход\n\n";
            Console.Write(questUser + "Выбор действия: ");
            int i = Convert.ToInt32(Console.ReadLine());

            switch (i)
            {
                case 1: Staff.ShowList(); break;
                case 2: Staff.AddStaff(); break;
                case 3: Staff.DeleteStaff(); break;
                case 4:
                    Console.Write("Введите ID Работника: ");
                    int Id = Convert.ToInt32(Console.ReadLine());
                    string questType = "\n1 - Работник\n" + "2 - Менеджер\n" + "3 - Другие\n"; 
                    Console.Write(questType + "Введите номер типа сотрудника: ");
                    int indexType = Convert.ToInt32(Console.ReadLine());
                    if (Id > 0)
                    {
                        Staff.ChangeStaffType(Id, indexType);
                    }
                    else Console.WriteLine("Введен неправильный индекс");
                    break;
                case 5:
                    Console.Write("Введите ID сотрудника и ID менеджера: ");
                    int emp = Convert.ToInt32(Console.ReadLine());
                    int man = Convert.ToInt32(Console.ReadLine());
                    Staff.AddEmplInHand(emp, man);
                    break;
                case 6: Staff.SortSurname(); break;
                case 7: Staff.SortEmplDate(); break;
                case 8: return false;  
                default:
                    Console.WriteLine("Всего 8 вариантов ответа!");
                    break;
            }

            return true;
        }
    }
}
