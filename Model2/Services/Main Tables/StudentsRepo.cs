using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Models2 {
    public class StudentsRepo : IStudentsRepo {

        public SqlConnection Connection { get; }

        public StudentsRepo(SqlConnection connection)
        {
            Connection = connection;
        }



        public bool CreateTable()
        {
            string queryString =
                    "if object_id('Students') is null " +
                    "begin " +
                    "create table Students(" +
                        "StudentId int identity(1, 1) PRIMARY KEY," +
                        "NationalCode varchar(10) check(LEN(NationalCode) = 10) not null unique," +
                        "Name nvarchar(50) not null, " +
                        "Family nvarchar(50) not null," +
                        "FatherName nvarchar(50) not null," +
                        "EntryYear smallInt not null check(EntryYear > 1394)," +
                        "PhoneNumber varchar(11) check(LEN(PhoneNumber) = 11 and PhoneNumber like '0%')," +
                        "Address nvarchar(150)," +
                        "PostalCode varchar(10) check(LEN(PostalCode) = 10)," +
                        "Field nvarchar(50) not null," +
                        "Grade nvarchar(50) not null," +
                        "HeadTeachId int not null," +

                        "CONSTRAINT FK_Student FOREIGN KEY (HeadTeachId) REFERENCES HeadTeachs(HeadTeachId)" +
                    ")" +
                    "end";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool DropTable()
        {
            string queryString =
                    "drop table if exists Students";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Delete(int studentId)
        {
            string queryString =
                    $"delete from Students where StudentId = " +
                    $"{studentId}";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Delete(Student student)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Student st)
        {
            string queryString =

                    "insert into Students " +
                    "(" +
                            "NationalCode," +
                            "Name," +
                            "Family," +
                            "FatherName," +
                            "EntryYear," +
                            "PhoneNumber," +
                            "Address," +
                            "PostalCode," +
                            "Field," +
                            "Grade," +
                            "HeadTeachId" +
                    ") " +
                    "values" +
                    "(" +
                            $"'{st.NationalCode}', " +
                            $"N'{st.Name}', " +
                            $"N'{st.Family}', " +
                            $"N'{st.FatherName}', " +
                            $"{st.EntryYear}, " +
                            $"'{st.PhoneNumber}', " +
                            $"N'{st.Address}', " +
                            $"'{st.PostalCode}'," +
                            $"N'{st.Field}'," +
                            $"N'{st.Grade}'," +
                            $"{st.HeadTeachId}" +
                    ")";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Insert(string name, string family, string fatherName, string nationalCode, string phoneNumber, string address, short entryYear, string postalCode, string field, string grade, int headTeachId)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectAll()
        {
            string queryString = "Select * From Students";

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }

        public DataTable SelectById(int studentId)
        {
            string queryString = "Select * From Students Where StudentId = " + studentId;

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }

        public bool Update(int studentId, Student st)
        {
            string queryString =
                    $"update Students set " +
                        $"NationalCode = '{st.NationalCode}', " +
                        $"[Name] = N'{st.Name}', " +
                        $"Family = N'{st.Family}', " +
                        $"FatherName = N'{st.FatherName}', " +
                        $"EntryYear = {st.EntryYear}, " +
                        $"PhoneNumber = '{st.PhoneNumber}', " +
                        $"[Address]= N'{st.Address}', " +
                        $"PostalCode = '{st.PostalCode}'," +
                        $"Field = N'{st.Field}'," +
                        $"Grade = N'{st.Grade}'," +
                        $"HeadTeachId = {st.HeadTeachId}" +
                    $" where StudentId = " + studentId;

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Update(int studentId, string name, string family, string fatherName, string nationalCode, string phoneNumber, string address, short entryYear, string postalCode, string field, string grade, int headTeachId)
        {
            throw new NotImplementedException();
        }

        public DataTable Search(string searchStr)
        {
            string[] searchProp = searchStr.Split(' ');
            string queryString = "Select * From Students where ";

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
    }
}
