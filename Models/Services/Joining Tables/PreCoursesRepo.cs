using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Models {
    public class PreCoursesRepo : IPreCoursesRepo {

        public SqlConnection Connection { get; }

        public PreCoursesRepo(SqlConnection connection)
        {
            Connection = connection;
        }



        public bool CreateTable()
        {
            string queryString =
                    "if object_id('PrerequisitesCourses') is null " +
                    "begin " +
                    "create table PrerequisitesCourses(" +
                        "MainCourseId int not null," +
                        "PrerequisitesCourseId int not null," +

                        "CONSTRAINT FK_Main_Course FOREIGN KEY (MainCourseId) REFERENCES Courses(CourseId)," +
                        "CONSTRAINT FK_Pre_Course FOREIGN KEY (PrerequisitesCourseId) REFERENCES Courses(CourseId)" +
                    ")" +
                    "end";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(PreCourse preCourse)
        {
            throw new NotImplementedException();
        }

        public bool DropTable()
        {
            throw new NotImplementedException();
        }

        public bool Insert(PreCourse preCourse)
        {
            throw new NotImplementedException();
        }

        public bool Insert(int mainCourseId, int requiredCourseId)
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

        public bool Update(int id, Course course)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, int mainCourseId, int requiredCourseId)
        {
            throw new NotImplementedException();
        }

        public DataTable Search(string search)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectByMainCourseId(int mainCourseId)
        {
            string queryString =
                    $"select c.MainCourseId , m.Title , c.PrerequisitesCourseId , p.Title " +
                    $"from PrerequisitesCourses c " +
                    $"Join Courses m " +
                    $"On m.CourseId = c.MainCourseId " +
                    $"Join Courses p " +
                    $"On p.CourseId = c.PrerequisitesCourseId" +
                    $"Where c.MainCourseId = {mainCourseId}";

            return ExtensionMethods.ExecuteReadCommand(queryString, Connection);
        }
    }
}
