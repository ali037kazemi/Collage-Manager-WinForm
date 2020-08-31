using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Models {
    public class StudentCoursesRepo : IStudentCoursesRepo {

        public SqlConnection Connection { get; }

        public StudentCoursesRepo(SqlConnection connection)
        {
            Connection = connection;
        }



        public bool CreateTable()
        {
            string queryString =
                    "if object_id('StudentCourses') is null " +
                    "begin " +
                    "create table StudentCourses(" +
                        "StudentId int not null," +
                        "CourseId int not null," +

                        "CONSTRAINT FK_Student_SC FOREIGN KEY (StudentId) REFERENCES Students(StudentId)," +
                        "CONSTRAINT FK_Course_SC FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)" +
                    ")" +
                    "end";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(StudentCourse studentCourse)
        {
            throw new NotImplementedException();
        }

        public bool DropTable()
        {
            throw new NotImplementedException();
        }

        public bool Insert(StudentCourse studentCourse)
        {
            throw new NotImplementedException();
        }

        public bool Insert(int studentId, int courseId)
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

        public bool Update(int id, StudentCourse studentCourse)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, int studentId, int courseId)
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

        public DataTable SelectByCourseId(int courseId)
        {
            throw new NotImplementedException();
        }
    }
}
