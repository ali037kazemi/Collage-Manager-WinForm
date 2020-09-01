using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Models2 {
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
                        "Id int primary key identity," +
                        "MainCourseId int not null," +
                        "PrerequisitesCourseId int not null," +

                        "CONSTRAINT FK_Main_Course FOREIGN KEY (MainCourseId) REFERENCES Courses(CourseId)," +
                        "CONSTRAINT FK_Pre_Course FOREIGN KEY (PrerequisitesCourseId) REFERENCES Courses(CourseId)" +
                    ")" +
                    "end";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool DropTable()
        {
            string queryString =
                    "drop table if exists PrerequisitesCourses";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Delete(int id)
        {
            string queryString =
                    $"delete from PrerequisitesCourses where Id = " +
                    $"{id}";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
        }

        public bool Delete(PreCourse preCourse)
        {
            throw new NotImplementedException();
        }

        public bool Insert(PreCourse pc)
        {
            string queryString =

                    "insert into PrerequisitesCourses " +
                    "(" +
                            "MainCourseId," +
                            "PrerequisitesCourseId" +
                    ") " +
                    "values" +
                    "(" +
                            $"'{pc.MainCourseId}', " +
                            $"{pc.RequiredCourseId}" +
                    ")";

            return ExtensionMethods.ExecuteCommand(queryString, Connection);
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
