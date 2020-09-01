using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Models2 {
    public class StudentTeacherRepo : IStudentTeacherRepo {

        public SqlConnection Connection { get; }

        public StudentTeacherRepo(SqlConnection connection)
        {
            Connection = connection;
        }



        public bool CreateTable()
        {
            string queryString =
                    "if object_id('StudentTeachers') is null " +
                    "begin " +
                    "create table StudentTeachers(" +
                        "Id int primary key identity," +
                        "StudentId int not null," +
                        "TeacherId int not null," +

                        "FOREIGN KEY (TeacherId) REFERENCES Teachers(TeacherId)," +
                        "FOREIGN KEY (StudentId) REFERENCES Students(StudentId)" +
                    ")" +
                    "end";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool DropTable()
        {
            string queryString =
                    "drop table if exists StudentTeachers";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Delete(int id)
        {
            string queryString =
                    $"delete from StudentTeachers where Id = " +
                    $"{id}";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Delete(StudentTeacher studentTeacher)
        {
            throw new NotImplementedException();
        }

        public bool Insert(StudentTeacher st)
        {
            string queryString =

                    "insert into StudentTeachers " +
                    "(" +
                            "StudentId," +
                            "TeacherId" +
                    ") " +
                    "values" +
                    "(" +
                            $"'{st.StudentId}', " +
                            $"{st.TeacherId}" +
                    ")";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Insert(int studentId, int teacherId)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectAll()
        {
            string queryString =
                    "select st.Id , st.TeacherId , t.Name , t.Family , st.StudentId , s.Name , s.Family " +
                    "from StudentTeachers st " +
                    "Join Teachers t " +
                    "On t.TeacherId = st.TeacherId " +
                    "Join Students s " +
                    "On s.StudentId = st.StudentId";

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }

        public DataTable SelectById(int id)
        {
            string queryString =
                    "select st.Id , st.TeacherId , t.Name , t.Family , st.StudentId , s.Name , s.Family " +
                    "from StudentTeachers st " +
                    "Join Teachers t " +
                    "On t.TeacherId = st.TeacherId " +
                    "Join Students s " +
                    "On s.StudentId = st.StudentId " +
                    "where st.Id = " + id;

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }

        public bool Update(int id, StudentTeacher st)
        {
            string queryString =
                    $"update StudentTeachers set " +
                        $"StudentId = '{st.StudentId}', " +
                        $"TeacherId = {st.TeacherId} " +
                    $" where Id = " + id;

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Update(int id, int studentId, int teacherId)
        {
            string queryString =
                    $"update StudentTeachers set " +
                        $"StudentId = '{studentId}', " +
                        $"TeacherId = {teacherId} " +
                    $" where Id = " + id;

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public DataTable Search(string search)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectByStudentId(int studentId)
        {
            string queryString =
                    "select st.Id , st.TeacherId , t.Name , t.Family , st.StudentId , s.Name , s.Family " +
                    "from StudentTeachers st " +
                    "Join Teachers t " +
                    "On t.TeacherId = st.TeacherId " +
                    "Join Students s " +
                    "On s.StudentId = st.StudentId " +
                    "where st.StudentId = " + studentId;

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }

        public DataTable SelectByTeacherId(int teacherId)
        {
            string queryString =
                    "select st.Id , st.TeacherId , t.Name , t.Family , st.StudentId , s.Name , s.Family " +
                    "from StudentTeachers st " +
                    "Join Teachers t " +
                    "On t.TeacherId = st.TeacherId " +
                    "Join Students s " +
                    "On s.StudentId = st.StudentId " +
                    "where st.TeacherId = " + teacherId;

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }
    }
}
