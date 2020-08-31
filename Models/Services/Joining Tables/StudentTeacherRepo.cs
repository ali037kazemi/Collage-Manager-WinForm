using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Models {
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
                        "StudentId int not null," +
                        "TeacherId int not null," +

                        "FOREIGN KEY (TeacherId) REFERENCES Teachers(TeacherId)," +
                        "FOREIGN KEY (StudentId) REFERENCES Students(StudentId)" +
                    ")" +
                    "end";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(StudentTeacher studentTeacher)
        {
            throw new NotImplementedException();
        }

        public bool DropTable()
        {
            throw new NotImplementedException();
        }

        public bool Insert(StudentTeacher studentTeacher)
        {
            throw new NotImplementedException();
        }

        public bool Insert(int studentId, int teacherId)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectAll()
        {
            throw new NotImplementedException();
        }

        public DataTable SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, StudentTeacher studentTeacher)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, int studentId, int teacherId)
        {
            throw new NotImplementedException();
        }

        public DataTable Search(string search)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectByStudentId(int studentId)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectByTeacherId(int teacherId)
        {
            throw new NotImplementedException();
        }
    }
}
