using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Models2 {
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
                        "Id int primary key identity," +
                        "StudentId int not null," +
                        "CourseId int not null," +

                        "CONSTRAINT FK_Student_SC FOREIGN KEY (StudentId) REFERENCES Students(StudentId)," +
                        "CONSTRAINT FK_Course_SC FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)" +
                    ")" +
                    "end";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool DropTable()
        {
            string queryString =
                    "drop table if exists StudentCourses";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Delete(int id)
        {
            string queryString =
                    $"delete from StudentCourses where Id = " +
                    $"{id}";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Delete(StudentCourse studentCourse)
        {
            throw new NotImplementedException();
        }

        public bool Insert(StudentCourse sc)
        {
            string queryString =

                    "insert into StudentCourses " +
                    "(" +
                            "StudentId," +
                            "CourseId" +
                    ") " +
                    "values" +
                    "(" +
                            $"'{sc.StudentId}', " +
                            $"{sc.CourseId}" +
                    ")";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Insert(int studentId, int courseId)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectAll()
        {
            string queryString =
                    "select sc.Id , sc.StudentId , s.Name , s.Family , sc.CourseId , c.Title " +
                    "from StudentCourses sc " +
                    "Join Courses c " +
                    "On c.CourseId = sc.CourseId " +
                    "Join Students s " +
                    "On s.StudentId = sc.StudentId";

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }

        public DataTable SelectById(int id)
        {
            string queryString =
                    "select sc.Id , sc.StudentId , s.Name , s.Family , sc.CourseId , c.Title " +
                    "from StudentCourses sc " +
                    "Join Courses c " +
                    "On c.CourseId = sc.CourseId " +
                    "Join Students s " +
                    "On s.StudentId = sc.StudentId " +
                    "where sc.Id = " + id;

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }

        public bool Update(int id, StudentCourse sc)
        {
            string queryString =
                    $"update StudentCourses set " +
                        $"StudentId = '{sc.StudentId}', " +
                        $"CourseId = {sc.CourseId} " +
                    $" where Id = " + id;

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
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
            string queryString =
                    "select sc.Id , sc.StudentId , s.Name , s.Family , sc.CourseId , c.Title " +
                    "from StudentCourses sc " +
                    "Join Courses c " +
                    "On c.CourseId = sc.CourseId " +
                    "Join Students s " +
                    "On s.StudentId = sc.StudentId " +
                    "where sc.StudentId = " + studentId;

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }

        public DataTable SelectByCourseId(int courseId)
        {
            string queryString =
                    "select sc.Id , sc.StudentId , s.Name , s.Family , sc.CourseId , c.Title " +
                    "from StudentCourses sc " +
                    "Join Courses c " +
                    "On c.CourseId = sc.CourseId " +
                    "Join Students s " +
                    "On s.StudentId = sc.StudentId " +
                    "where sc.CourseId = " + courseId;

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }
    }
}
