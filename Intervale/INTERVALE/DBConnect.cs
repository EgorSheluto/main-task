using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace INTERVALE
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBConnect()
        {
            Initialize();
            CreateTables();
        }

        private void Initialize()
        { 
            server = "localhost";
            database = "test_db";
            uid = "root";
            password = "";
            string connectionString = "";
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Can't connect to server. Contact administrator");
                        break;
                    case 1:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private void CreateTables()
        { 
            if (this.OpenConnection() == true)
            {
                MySqlCommand command = new MySqlCommand(Constants.SQL_CREATE_TABLE_EMPLOYEE + "\n" + Constants.SQL_CREATE_TABLE_MANAGER + "\n" + Constants.SQL_CREATE_TABLE_OTHER + "\n" + Constants.SQL_CREATE_TABLE_MANAGER_LIST_OF_STAFF, connection);

                command.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        public void InsertEmployee(string obj)
        {
            if (this.OpenConnection() == true)
            {
                string[] datas = obj.Split('\t');

                MySqlCommand command = new MySqlCommand(String.Format(@Constants.SQL_INSERT_EMPLOYEE, datas[0], datas[1], datas[2], datas[3], datas[4], datas[5]), connection);

                command.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        public void InsertManager(string obj)
        {
            if (this.OpenConnection() == true)
            {
                string[] datas = obj.Split('\t');

                MySqlCommand command = new MySqlCommand(String.Format(@Constants.SQL_INSERT_MANAGER, datas[0], datas[1], datas[2], datas[3], datas[4], datas[5]), connection);

                command.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        public void InsertOther(string obj)
        {
            if (this.OpenConnection() == true)
            {
                string[] datas = obj.Split('\t');

                MySqlCommand command = new MySqlCommand(String.Format(@Constants.SQL_INSERT_MANAGER, datas[0], datas[1], datas[2], datas[3], datas[4], datas[5], datas[6]), connection);

                command.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        public void InsertManager_list_of_staff(string obj)
        {
            if (this.OpenConnection() == true)
            {
                string idManager = obj.Split('\t')[0];
                string[] datas = obj.Split('\t')[6].Split(',');

                for (int i = 0; i < datas.Length; i++)
                {
                    MySqlCommand command = new MySqlCommand(String.Format(@Constants.SQL_INSERT_MANAGER_LIST_OF_STAFF, Convert.ToInt32(idManager), Convert.ToInt32(datas[i])), connection);

                    command.ExecuteNonQuery();
                }

                this.CloseConnection();
            }
        }

        public void DropTables()
        { 
            if (this.OpenConnection() == true)
            {
                MySqlCommand command = new MySqlCommand(Constants.SQL_DROP_ALL_TABLES, connection);

                command.ExecuteNonQuery();

                this.CloseConnection();    
            }
        }
    }
}
