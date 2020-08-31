using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Models {
    public class ExistingCoursesRepo : IExistingCoursesRepo {

        public SqlConnection Connection { get; }

        public ExistingCoursesRepo(SqlConnection connection)
        {
            Connection = connection;
        }



        public bool CreateTable()
        {
            string queryString =
                    "if object_id('ExistingCourses') is null " +
                    "begin " +
                    "create table ExistingCourses(" +
                        "TeacherId int not null," +
                        "CourseId int not null," +

                        "CONSTRAINT FK_Exsting_Teacher FOREIGN KEY (TeacherId) REFERENCES Teachers(TeacherId)," +
                        "CONSTRAINT FK_Exsting_Course FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)" +
                    ")" +
                    "end";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ExistingCourse existingCourse)
        {
            throw new NotImplementedException();
        }

        public bool DropTable()
        {
            throw new NotImplementedException();
        }

        public bool Insert(ExistingCourse existingCourse)
        {
            throw new NotImplementedException();
        }

        public bool Insert(int teacherId, int courseId)
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

        public DataTable Search(string search)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Course course)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, int teacherId, int courseId)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectByTeacherId(int teacherId)
        {
            string queryString =
                    $"select e.TeacherId , t.Name , t.Family , c.* " +
                    $"from ExistingCourses e " +
                    $"Join Teachers t " +
                    $"On t.TeacherId = e.TeacherId " +
                    $"Join Courses c " +
                    $"On c.CourseId = e.CourseId " +
                    $"Where e.TeacherId = {teacherId}";

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }

        public DataTable SelectByCourseId(int courseId)
        {
            string queryString =
                    $"select e.TeacherId , t.Name , t.Family , c.* " +
                    $"from ExistingCourses e " +
                    $"Join Teachers t " +
                    $"On t.TeacherId = e.TeacherId " +
                    $"Join Courses c " +
                    $"On c.CourseId = e.CourseId " +
                    $"Where e.CourseId = {courseId}";

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }
    }
}
