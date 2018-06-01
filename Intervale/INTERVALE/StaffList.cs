using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace INTERVALE
{
    class StaffList<T>
        where T : Employee
    {

        List<Employee> list;

        public StaffList()
        {
            list = new List<Employee>();
        }

        private void SaveInFile(string path)
        {
            StreamWriter f;

            try
            {
                f = new StreamWriter(new FileStream(@path + ".txt", FileMode.Create), Encoding.Default);

                foreach (Employee obj in list)
                {
                    try
                    {
                        if (((object)obj).GetType() == typeof(Employee))
                        {
                            f.WriteLine(obj.ToString("Работник"));
                        }
                        else if (((object)obj).GetType() == typeof(Manager))
                        {
                            f.WriteLine(obj.ToString("Менеджер"));
                        }
                        else if (((object)obj).GetType() == typeof(Others))
                        {
                            f.WriteLine(obj.ToString("Другие"));
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Error: {0}", e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: {0}", e.Message);
                    }
                }

                f.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        private void LoadFrFile(string path)
        {
            StreamReader f;

            try
            {
                f = new StreamReader(@path + ".txt", Encoding.Default);

                if (!f.EndOfStream)
                {
                    while (!f.EndOfStream)
                    {
                        bool acceptToAdd = true;
                        string[] datas = f.ReadLine().Split(';');

                        foreach (Employee obj in list)
                        {
                            if (obj.getId() == datas[1] || (obj.getSurname() == datas[2] && obj.getName() == datas[3] && obj.getPatronymic() == datas[4]))
                            {
                                acceptToAdd = false;
                                break;
                            }
                        }

                        if (acceptToAdd)
                        {
                            try
                            {
                                switch (datas[0])
                                {
                                    case "Работник":
                                        list.Add(new Employee(datas[1], datas[2], datas[3], datas[4], Convert.ToDateTime(datas[5]), Convert.ToDateTime(datas[6])));
                                        break;
                                    case "Менеджер":
                                        list.Add(new Manager(datas[1], datas[2], datas[3], datas[4], Convert.ToDateTime(datas[5]), Convert.ToDateTime(datas[6]), new List<string>(datas[7].Split(',').AsEnumerable<string>())));
                                        break;
                                    case "Другие":
                                        list.Add(new Others(datas[1], datas[2], datas[3], datas[4], Convert.ToDateTime(datas[5]), Convert.ToDateTime(datas[6]), datas[7]));
                                        break;
                                }
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Error: {0}", e.Message);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error: {0}", e.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Такой сотрудник уже существует: {0} {1} {2} {3}", datas[1], datas[2], datas[3], datas[4]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Добавлять нечего");
                }

                f.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void AddStaff()
        {
            LoadFrFile("input");
            SaveInFile("staff");
        }

        public void LoadStaff()
        {
            LoadFrFile("staff");
        }

        public void AddEmplInHand(int emplId, int managerId)
        {
            if (emplId > 0 && managerId > 0)
            {
                if (managerId != emplId)
                {
                    bool rightType = false;
                    foreach (Employee obj in list)
                    { 
                        if (Convert.ToInt32(obj.getId()) == emplId)
                        {
                            if (((object)obj).GetType() != typeof(Manager))
                            {
                                rightType = true;
                            }
                        }
                    }

                    if (rightType)
                    {
                        foreach (Employee obj in list)
                        {
                            if (Convert.ToInt32(obj.getId()) == managerId)
                            {
                                if (((object)obj).GetType() == typeof(Manager))
                                {
                                    var obj1 = (Manager)obj;
                                    obj1.AddEmpInHand(emplId);
                                    SaveInFile("staff");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Невозможно привязать сотрудника");
                    }
                }
                else
                {
                    Console.WriteLine("Номер менеджера не может быть равен номеру сотрудника");
                }
            }
            else
            {
                Console.WriteLine("Нумерация начинается с 1");
            }
        }

        public void DeleteStaff()
        {
            try
            {
                Console.Write("Введите ID сотрудника, которого необходимо удалить: ");
                int Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                foreach (Employee obj in list)
                {
                    if (Convert.ToInt32(obj.getId()) == Id)
                    {
                        list.Remove(obj);
                        break;
                    }
                }

                foreach(Employee obj in list)
                {
                    if (Convert.ToInt32(obj.getId()) != Id)
                    {
                        if (((object)obj).GetType() == typeof(Manager))
                        {
                            var obj1 = (Manager)obj;
                            obj1.DeleteEmpInHand(Id.ToString());
                            break;
                        }
                    }
                }
                SaveInFile("staff");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Error in delete staff: {0}", e.Message);
            }
        }

        public void ChangeStaffType(int staffId, int typeId)
        {
                    switch (typeId)
                    {
                        case 1:
                            for (int i = 0; i < list.Count; i++)
                            {
                                var obj = list[i];

                                if (Convert.ToInt32(obj.getId()) == staffId)
                                {
                                    if (((object)obj).GetType() != typeof(Employee))
                                    {
                                        string[] datas = obj.ToString().Split('\t');
                                        obj = new Employee(datas[0], datas[1], datas[2], datas[3], Convert.ToDateTime(datas[4]), Convert.ToDateTime(datas[5]));
                                        list[i] = obj;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Данный сотрудник уже является Работником");
                                        return;
                                    }
                                }
                            }
                            break;
                        case 2:
                            bool delFlag = true;
                            for (int i = 0; i < list.Count; i++)
                            {
                                var obj = list[i];

                                if (Convert.ToInt32(obj.getId()) == staffId)
                                {
                                    if (((object)obj).GetType() != typeof(Manager))
                                    {
                                        string[] datas = obj.ToString().Split('\t');
                                        obj = new Manager(datas[0], datas[1], datas[2], datas[3], Convert.ToDateTime(datas[4]), Convert.ToDateTime(datas[5]));
                                        list[i] = obj;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Данный сотрудник уже является Менеджером");
                                        return;
                                    }
                                }
                                else if (delFlag)
                                {
                                    if (((object)obj).GetType() == typeof(Manager))
                                    {
                                        var obj1 = (Manager)obj;
                                        obj1.DeleteEmpInHand(staffId.ToString());
                                        delFlag = false;
                                    }
                                }
                            }
                            break;
                        case 3:
                            for (int i = 0; i < list.Count; i++)
                            {
                                var obj = list[i];

                                if (Convert.ToInt32(obj.getId()) == staffId)
                                {
                                    if (((object)obj).GetType() != typeof(Others))
                                    {
                                        string[] datas = obj.ToString().Split('\t');
                                        obj = new Others(datas[0], datas[1], datas[2], datas[3], Convert.ToDateTime(datas[4]), Convert.ToDateTime(datas[5]));
                                        list[i] = obj;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Данный сотрудник уже является Другим");
                                        return;
                                    }
                                }
                            }
                            break;
                        default: Console.WriteLine("Типа сотрудника с таким номером нет"); break;
                    }

                    SaveInFile("staff");
                    return;
                }

        public void ShowList()
        {
            if (list.Count != 0)
            {
                Console.WriteLine("Работники:\n");
                ShowEmployee();
                Console.WriteLine();
                Console.WriteLine("Менеджеры:\n");
                ShowManager();
                Console.WriteLine();
                Console.WriteLine("Другие:\n");
                ShowOthers();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Список персонала пуст");
            }
        }

        public void ShowEmployee()
        {
            foreach (Employee obj in list)
            {
                if (((object)obj).GetType() == typeof(Employee))
                {
                    Console.WriteLine(obj.ToString());
                }
            }
        }

        public void ShowManager()
        {
            foreach (Employee obj in list)
            {
                if (((object)obj).GetType() == typeof(Manager))
                {
                    Console.WriteLine(obj.ToString());
                }
            }
        }

        public void ShowOthers()
        {
            foreach (Employee obj in list)
            {
                if (((object)obj).GetType() == typeof(Others))
                {
                    Console.WriteLine(obj.ToString());
                }
            }
        }

        public void SortSurname()
        {
            list.Sort(new SurnameCompare<Employee>());
        }

        public void SortEmplDate()
        {

            list.Sort(new EmplDateCompare<Employee>());
        }
    }
}
