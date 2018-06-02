using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERVALE
{
    class Constants
    {
        public const string SQL_CREATE_TABLE_EMPLOYEE = ("CREATE TABLE [IF NOT EXISTS] Employee (ID INT NOT NULL,"+
            "Surname VARCHAR(50) NOT NULL,"+
            "Name VARCHAR(20) NOT NULL," +
            "Patronymic VARCHAR(50) NOT NULL," +
            "BornDate DATE NOT NULL," +
            "EmplDate DATE NOT NULL," +
            "PRIMARY KEY (ID));");

        public const string SQL_CREATE_TABLE_MANAGER = ("CREATE TABLE [IF NOT EXISTS] Manager (ID INT NOT NULL," +
            "Surname VARCHAR(50) NOT NULL," +
            "Name VARCHAR(20) NOT NULL," +
            "Patronymic VARCHAR(50) NOT NULL," +
            "BornDate DATE NOT NULL," +
            "EmplDate DATE NOT NULL," +
            "PRIMARY KEY (ID));");

        public const string SQL_CREATE_TABLE_OTHER = ("CREATE TABLE [IF NOT EXISTS] Other (ID INT NOT NULL," +
            "Surname VARCHAR(50) NOT NULL," +
            "Name VARCHAR(20) NOT NULL," +
            "Patronymic VARCHAR(50) NOT NULL," +
            "BornDate DATE NOT NULL," +
            "EmplDate DATE NOT NULL," +
            "Description VARCHAR(50)," +
            "PRIMARY KEY (ID));");

        public const string SQL_CREATE_TABLE_MANAGER_LIST_OF_STAFF = ("CREATE TABLE [IF NOT EXISTS] Manager_list_of_staff " + 
            "(ID INT NOT NULL AUTO_INCREMENT," +
            "ID_Manager INT NOT NULL," +
            "ID_Staff INT NOT NULL," +
            "PRIMARY KEY (ID));");

        public const string SQL_DROP_ALL_TABLES = ("DROP TABLE test_db.Employee, test_db.Manager, test_db.Other, test_db.Manager_list_of_staff;");

        public const string SQL_INSERT_EMPLOYEE = "INSERT INTO Employee VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}')";

        public const string SQL_INSERT_MANAGER = "INSERT INTO Manager VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}')";

        public const string SQL_INSERT_OTHER = "INSERT INTO Other VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')";

        public const string SQL_INSERT_MANAGER_LIST_OF_STAFF = "INSERT INTO Manager_list_of_staff (ID_Manager, ID_Staff) VALUES ({0}, {1})";
    }
}
