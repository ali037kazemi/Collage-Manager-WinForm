using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Models2 {
    public class CoursesRepo : ICoursesRepo {

        public SqlConnection Connection { get; }

        public CoursesRepo(SqlConnection connection)
        {
            Connection = connection;
        }



        public bool CreateTable()
        {
            string queryString =
                    "if object_id('Courses') is null " +
                    "begin " +
                    "create table Courses(" +
                        "CourseId int identity(1, 1) PRIMARY KEY," +
                        "Title nvarchar(50) not null, " +
                        "Credit tinyInt not null," +
                        "CreditType bit not null," + // True for takhasosi, False for omumi
                        "HeadTeachId int not null FOREIGN KEY (HeadTeachId) REFERENCES HeadTeachs(HeadTeachId)" +
                    ")" +
                    "end";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool DropTable()
        {
            string queryString =
                    "drop table if exists Courses";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Delete(int courseId)
        {
            string queryString =
                    $"delete from Courses where CourseId = " +
                    $"{courseId}";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Delete(Course course)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Course c)
        {
            int type = c.CreditType ? 1 : 0;
            string queryString =

                    "insert into Courses " +
                    "(" +
                            "Title," +
                            "Credit," +
                            "CreditType," +
                            "HeadTeachId" +
                    ") " +
                    "values" +
                    "(" +
                            $"N'{c.Title}', " +
                            $"{c.Credit}, " +
                            $"{type}," +
                            $"{c.HeadTeachId}" +
                    ")";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Insert(string title, byte credit, bool creditType, int headTeachId)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectAll()
        {
            string queryString = "Select * From Courses";

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }

        public DataTable SelectById(int courseId)
        {
            string queryString = "Select * From Courses Where CourseId = " + courseId;

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }

        public DataTable Search(string searchStr)
        {
            string[] searchProp = searchStr.Split(' ');
            string queryString = "Select * From Courses where ";

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

        public bool Update(int courseId, Course c)
        {
            int type = c.CreditType ? 1 : 0;
            string queryString =
                     $"update Courses set " +
                        $"Title = N'{c.Title}', " +
                        $"Credit = {c.Credit}, " +
                        $"CreditType = {type}," +
                        $"HeadTeachId = {c.HeadTeachId}" +
                     $"where CourseId = " + courseId;

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Update(int courseId, string title, byte credit, bool creditType, int headTeachId)
        {
            throw new NotImplementedException();
        }
    }
}
