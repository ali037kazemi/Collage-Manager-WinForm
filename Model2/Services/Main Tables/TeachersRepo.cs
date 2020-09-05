using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Models2 {
    public class TeachersRepo : ITeachersRepo {
        public SqlConnection Connection { get; }

        public TeachersRepo(SqlConnection connection)
        {
            Connection = connection;
        }



        public bool CreateTable()
        {
            string queryString =
                    "if object_id('Teachers') is null " +
                    "begin " +
                    "create table Teachers(" +
                        "TeacherId int identity(1, 1) PRIMARY KEY," +
                        "NationalCode varchar(10) check(LEN(NationalCode) = 10) not null unique," +
                        "Name nvarchar(50) not null, " +
                        "Family nvarchar(50) not null," +
                        "FatherName nvarchar(50) not null," +
                        "PhoneNumber varchar(11) check(LEN(PhoneNumber) = 11)," +
                        "Address nvarchar(150)," +
                        "Degree nvarchar(150)" +
                    ")" +
                    "end";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool DropTable()
        {
            string queryString =
                    "drop table if exists Teachers";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Delete(int teacherId)
        {
            string queryString =
                    $"delete from Teachers where TeacherId = " +
                    $"{teacherId}";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Delete(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Teacher t)
        {
            string queryString =

                    "insert into Teachers " +
                    "(" +
                            "NationalCode," +
                            "Name," +
                            "Family," +
                            "FatherName," +
                            "PhoneNumber," +
                            "Address," +
                            "Degree" +
                    ") " +
                    "values" +
                    "(" +
                            $"'{t.NationalCode}', " +
                            $"N'{t.Name}', " +
                            $"N'{t.Family}', " +
                            $"N'{t.FatherName}', " +
                            $"'{t.PhoneNumber}', " +
                            $"N'{t.Address}', " +
                            $"N'{t.Degree}'" +
                    ")";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Insert(string name, string family, string fatherName, string nationalCode, string phoneNumber, string address, string degree)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectAll()
        {
            string queryString = "Select * From Teachers";

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }

        public DataTable SelectById(int teacherId)
        {
            string queryString = "Select * From Teachers Where TeacherId = " + teacherId;

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }

        public bool Update(int teacherId, Teacher t)
        {
            string queryString =
                    $"update Teachers set " +
                        $"NationalCode = '{t.NationalCode}', " +
                        $"Name = N'{t.Name}', " +
                        $"Family = N'{t.Family}', " +
                        $"FatherName = N'{t.FatherName}', " +
                        $"PhoneNumber = '{t.PhoneNumber}', " +
                        $"Address = N'{t.Address}', " +
                        $"Degree = N'{t.Degree}'" +
                    $"where TeacherId = " + teacherId;

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Update(int teacherId, string name, string family, string fatherName, string nationalCode, string phoneNumber, string address, string degree)
        {
            throw new NotImplementedException();
        }

        public DataTable Search(string searchStr)
        {
            string[] searchProp = searchStr.Split(' ');
            string queryString = "Select * From Teachers where ";

            for (int i = 0; i < searchProp.Length; i++)
            {
                string str = searchProp[i];
                queryString += $" Name like '%{str}%' or Family like '%{str}%' " + " or ";
            }
            if (searchProp.Length > 0)
            {
                queryString = queryString.Substring(0, queryString.Length - 4);
            }

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }

        public DataTable SelectAllStudents(int teacherId)
        {
            string queryString =
                        "select s.* " +
                        "from StudentTeachers st " +
                        "Join Teachers t " +
                        "On t.TeacherId = st.TeacherId " +
                        "Join Students s " +
                        "On s.StudentId = st.StudentId " +
                        "Where t.TeacherId = " + teacherId;

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }

        public DataTable SelectAllCourses(int teacherId)
        {
            string queryString =
                        "select c.* " +
                        "from ExistingCourses e " +
                        "Join Courses c " +
                        "On c.CourseId = e.CourseId " +
                        "Join Teachers t " +
                        "On t.TeacherId = e.TeacherId " +
                        "Where t.TeacherId = " + teacherId;

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }
    }
}
